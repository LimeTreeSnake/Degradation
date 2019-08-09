using Harmony;
using RimWorld;
using Verse;
using System.Collections.Generic;

namespace Equipment_Deterioration {
    [StaticConstructorOnStartup]
    internal static class HarmonyEquipmentDeterioration {
        static HarmonyEquipmentDeterioration() {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("rimworld.limetreesnake.equipmentdeterioration");
            harmonyInstance.Patch(AccessTools.Method(typeof(Pawn_ApparelTracker), "ApparelTrackerTickRare"), new HarmonyMethod(typeof(HarmonyEquipmentDeterioration).GetMethod("ApparelTrackerTickRare_PreFix")), null);
            harmonyInstance.Patch(AccessTools.Method(typeof(Verb_MeleeAttack), "TryCastShot"), null, new HarmonyMethod(typeof(HarmonyEquipmentDeterioration).GetMethod("TryCastShot_Melee_PostFix")), null);
            harmonyInstance.Patch(AccessTools.Method(typeof(Verb_Shoot), "WarmupComplete"), null, new HarmonyMethod(typeof(HarmonyEquipmentDeterioration).GetMethod("WarmupComplete_Ranged_PostFix")), null);
        }

        public static bool ApparelTrackerTickRare_PreFix(Pawn_ApparelTracker __instance) {
            //Log.Message(__instance.pawn + " Detoriates ");
            if (!SettingsHelper.LatestVersion.npcDeteriorate || !__instance.pawn.Spawned) {
                return !SettingsHelper.LatestVersion.removeVanillaSettings;
            }
            int ticksGame = Find.TickManager.TicksGame;
            int wearoutTick = Traverse.Create(__instance).Field("lastApparelWearoutTick").GetValue<int>();
            if (wearoutTick < 0) {
                if (SettingsHelper.LatestVersion.removeVanillaSettings) {
                    Traverse.Create(__instance).Field("lastApparelWearoutTick").SetValue(ticksGame);
                }
            }

            if (ticksGame - wearoutTick >= 60000) {
                //Apparell
                DailyDegrade(__instance.pawn.apparel.WornApparel,
                    __instance.pawn,
                    SettingsHelper.LatestVersion.detoriationApparellRate,
                    SettingsHelper.LatestVersion.damageIncreaseApparell,
                    SettingsHelper.LatestVersion.damageIncreaseRandomApparell);
                //Equipment
                DailyDegrade(__instance.pawn.equipment.AllEquipmentListForReading,
                    __instance.pawn,
                    SettingsHelper.LatestVersion.detoriationEquipmentRate,
                    SettingsHelper.LatestVersion.damageIncreaseEquipment,
                    SettingsHelper.LatestVersion.damageIncreaseRandomEquipment);
                //Items
                DailyDegrade(__instance.pawn.inventory.innerContainer.InnerListForReading,
                    __instance.pawn,
                    SettingsHelper.LatestVersion.detoriationInventoryRate,
                    SettingsHelper.LatestVersion.damageIncreaseItem,
                    SettingsHelper.LatestVersion.damageIncreaseRandomItem);

                //If the vanilla deterioration is off, make sure the lastApparelWearoutTick is updated.
                if (SettingsHelper.LatestVersion.removeVanillaSettings) {
                    Traverse.Create(__instance).Field("lastApparelWearoutTick").SetValue(ticksGame);
                }
            }
            return !SettingsHelper.LatestVersion.removeVanillaSettings;
        }

        public static void TryCastShot_Melee_PostFix(Verb __instance, bool __result) {
            if (!SettingsHelper.LatestVersion.npcDeteriorate) {
                if (!__instance.CasterPawn.IsColonistPlayerControlled) {
                    return;
                }
            }
            Fire(__instance,
                    SettingsHelper.LatestVersion.detoriationMeleeUsedRate,
                    SettingsHelper.LatestVersion.damageIncreaseRangedWeapon,
                    SettingsHelper.LatestVersion.damageIncreaseRandomMeleeWeapon,
                    __result
                    );
        }
        public static void WarmupComplete_Ranged_PostFix(Verb __instance) {
            if (!SettingsHelper.LatestVersion.npcDeteriorate) {
                if (!__instance.CasterPawn.IsColonistPlayerControlled) {
                    return;
                }
            }
            Fire(__instance,
                SettingsHelper.LatestVersion.detoriationRangedUsedRate,
                SettingsHelper.LatestVersion.damageIncreaseRangedWeapon,
                SettingsHelper.LatestVersion.damageIncreaseRandomRangedWeapon,
                true,
                SettingsHelper.LatestVersion.bulletMatters
                );
        }

        public static void DailyDegrade<T>(List<T> items, Pawn pawn, float deteriorateRate, float damageIncrease, bool useRandom) where T : Thing {
            for (int i = 0; i < items.Count; i++) {
                if (DeteriorateCheck(items[i], deteriorateRate / 100f) > 0) {
                    Deteriorate(items[i], pawn, damageIncrease, useRandom);
                }
            }
        }
        public static void Fire<T>(T __instance, float deteriorationRate, float damageIncrease, bool useRandom, bool __result = true, bool useAlternateFormula = false) where T : Verb {
            if (deteriorationRate > 0f) {
                if (__instance.CasterIsPawn && __result) {
                    if (!SettingsHelper.LatestVersion.npcDeteriorate) {
                        if (!__instance.CasterPawn.IsColonistPlayerControlled) {
                            return;
                        }
                    }
                    float num = deteriorationRate;
                    if (useAlternateFormula) {
                        int x = Traverse.Create(__instance).Field("ShotsPerBurst").GetValue<int>();
                        num = deteriorationRate * (1 + (SettingsHelper.LatestVersion.bulletMattersDamage * x) / 100);
                    }
                    if (!__instance.CasterPawn.AnimalOrWildMan() && __instance.CasterPawn.equipment.Primary != null) {
                        if (DeteriorateCheck(__instance.CasterPawn.equipment.Primary, num / 100f) > 0) {
                            Deteriorate(__instance.CasterPawn.equipment.Primary, __instance.CasterPawn, damageIncrease, useRandom);
                        }
                    }
                }
            }
        }

        public static float QualityCheck(Thing item, float input) {
            if (item.TryGetQuality(out QualityCategory quality)) {
                switch (quality) {
                    case QualityCategory.Awful: {
                            return input * SettingsHelper.LatestVersion.awful;
                        }
                    case QualityCategory.Poor: {
                            return input * SettingsHelper.LatestVersion.poor;
                        }
                    case QualityCategory.Normal: {
                            return input * SettingsHelper.LatestVersion.normal;
                        }
                    case QualityCategory.Good: {
                            return input * SettingsHelper.LatestVersion.good;
                        }
                    case QualityCategory.Excellent: {
                            return input * SettingsHelper.LatestVersion.excellent;
                        }
                    case QualityCategory.Masterwork: {
                            return input * SettingsHelper.LatestVersion.masterwork;
                        }
                    case QualityCategory.Legendary: {
                            return input * SettingsHelper.LatestVersion.legendary;
                        }
                }
            }
            return input;
        }
        public static int DeteriorateCheck(Thing item, float chance) {
            if (item.MaxHitPoints <= 1 || item.HitPoints <= 0 || item.def.useHitPoints == false) {
                return 0;
            }
            else {
                if (SettingsHelper.LatestVersion.qualityMatters) {
                    float x = QualityCheck(item, chance);
                    return GenMath.RoundRandom(x >= 100f ? 100f : x);
                }
                else {
                    return GenMath.RoundRandom(chance);
                }
            }
        }
        public static void Deteriorate(Thing item, Pawn pawn, float damageIncrease, bool random) {
            float damage = random && damageIncrease != 1
                ? Rand.Range(1, damageIncrease)
                : damageIncrease;
            //Log.Message("Item: " + item.def.defName + " on Pawn: " + pawn.Name + " Took " + damage + " damage.");
            if (damage > item.HitPoints && PawnUtility.ShouldSendNotificationAbout(pawn) && !pawn.Dead) {
                string str = "MessageWornApparelDeterioratedAway".Translate(GenLabel.ThingLabel(item.def, item.Stuff), pawn);
                str = str.CapitalizeFirst();
                Messages.Message(str, pawn, MessageTypeDefOf.NegativeEvent);
            }
            item.TakeDamage(new DamageInfo(DamageDefOf.Deterioration, damage));
        }
    }
}