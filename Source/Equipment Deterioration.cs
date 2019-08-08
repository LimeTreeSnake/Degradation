using Harmony;
using RimWorld;
using Verse;

namespace Equipment_Deterioration {
    [StaticConstructorOnStartup]
    internal static class HarmonyEquipmentDeterioration {
        static HarmonyEquipmentDeterioration() {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("rimworld.limetreesnake.equipmentdeterioration");
            harmonyInstance.Patch(AccessTools.Method(typeof(Pawn_ApparelTracker), "ApparelTrackerTickRare"), new HarmonyMethod(typeof(HarmonyEquipmentDeterioration).GetMethod("ApparelTrackerTickRare_PreFix")), null);
            harmonyInstance.Patch(AccessTools.Method(typeof(Verb_MeleeAttack), "TryCastShot"), null, new HarmonyMethod(typeof(HarmonyEquipmentDeterioration).GetMethod("TryCastShot_Melee_PostFix")), null);
            harmonyInstance.Patch(AccessTools.Method(typeof(Verb_Shoot), "TryCastShot"), null, new HarmonyMethod(typeof(HarmonyEquipmentDeterioration).GetMethod("TryCastShot_Ranged_PostFix")), null);
        }

        private static bool IsLoaded(string mod) {
            return LoadedModManager.RunningModsListForReading.Any(x => x.Name == mod);
        }

        public static bool ApparelTrackerTickRare_PreFix(Pawn_ApparelTracker __instance) {
            if (__instance.pawn.IsColonistPlayerControlled) {
                //Log.Message(__instance.pawn.Name.ToStringFull + " " + __instance.pawn.IsColonistPlayerControlled);
                int ticksGame = Find.TickManager.TicksGame;
                int wearoutTick = Traverse.Create(__instance).Field("lastApparelWearoutTick").GetValue<int>();

                if (wearoutTick < 0)
                    if (SettingsHelper.LatestVersion.removeVanillaSettings)
                        Traverse.Create(__instance).Field("lastApparelWearoutTick").SetValue(ticksGame);

                if (ticksGame - wearoutTick >= 60000) {
                    //Apparell
                    //Log.Message(__instance.pawn.apparel.WornApparel.Count.ToString());
                    if (SettingsHelper.LatestVersion.detoriationApparellRate != 0) {
                        for (int i = 0; i < __instance.pawn.apparel.WornApparel.Count; i++) {
                            //Log.Message(__instance.pawn.apparel.WornApparel[i].def.defName);
                            if (DeteriorateCheck(__instance.pawn.apparel.WornApparel[i], SettingsHelper.LatestVersion.detoriationApparellRate / 100f) > 0) {
                                Deteriorate(__instance.pawn.apparel.WornApparel[i], __instance.pawn, SettingsHelper.LatestVersion.damageIncreaseApparell, SettingsHelper.LatestVersion.damageIncreaseRandomApparell);
                            }
                        }
                    }
                    //Equipment
                    //Log.Message(__instance.pawn.equipment.AllEquipmentListForReading.Count.ToString());
                    if (SettingsHelper.LatestVersion.detoriationEquipmentRate != 0) {
                        for (int i = 0; i < __instance.pawn.equipment.AllEquipmentListForReading.Count; i++) {
                            //Log.Message(__instance.pawn.equipment.AllEquipmentListForReading[i].def.defName);
                            if (DeteriorateCheck(__instance.pawn.equipment.AllEquipmentListForReading[i], SettingsHelper.LatestVersion.detoriationEquipmentRate / 100f) > 0) {
                                Deteriorate(__instance.pawn.equipment.AllEquipmentListForReading[i], __instance.pawn, SettingsHelper.LatestVersion.damageIncreaseEquipment, SettingsHelper.LatestVersion.damageIncreaseRandomEquipment);
                            }
                        }
                    }
                    //Items
                    //Log.Message(__instance.pawn.inventory.innerContainer.Count.ToString());
                    if (SettingsHelper.LatestVersion.detoriationInventoryRate != 0) {
                        for (int i = 0; i < __instance.pawn.inventory.innerContainer.Count; i++) {
                            //Log.Message(__instance.pawn.inventory.innerContainer[i].def.defName);
                            if (DeteriorateCheck(__instance.pawn.inventory.innerContainer[i], SettingsHelper.LatestVersion.detoriationInventoryRate / 100f) > 0) {
                                Deteriorate(__instance.pawn.inventory.innerContainer[i], __instance.pawn, SettingsHelper.LatestVersion.damageIncreaseItem, SettingsHelper.LatestVersion.damageIncreaseRandomItem);
                            }
                        }
                    }
                    //If the vanilla deterioration is off, make sure the lastApparelWearoutTick is updated.
                    if (SettingsHelper.LatestVersion.removeVanillaSettings) {
                        //Log.Message("last apparelWearoutTick");
                        Traverse.Create(__instance).Field("lastApparelWearoutTick").SetValue(ticksGame);
                    }
                }
            }
            return !SettingsHelper.LatestVersion.removeVanillaSettings;
        }
        public static void TryCastShot_Melee_PostFix(Verb_MeleeAttack __instance, bool __result) {
            if (!__instance.CasterIsPawn) {
                return;
            }
            if (!__instance.CasterPawn.AnimalOrWildMan() && __instance.CasterPawn.equipment.Primary != null) {
                if (DeteriorateCheck(__instance.CasterPawn.equipment.Primary, SettingsHelper.LatestVersion.detoriationMeleeUsedRate / 100f) > 0) {
                    Deteriorate(__instance.CasterPawn.equipment.Primary, __instance.CasterPawn, SettingsHelper.LatestVersion.damageIncreaseMeleeWeapon, SettingsHelper.LatestVersion.damageIncreaseRandomMeleeWeapon);
                }
            }
        }
        public static void TryCastShot_Ranged_PostFix(Verb_Shoot __instance) {
            if (!__instance.CasterIsPawn) {
                return;
            }
            if (!__instance.CasterPawn.AnimalOrWildMan() && __instance.CasterPawn.equipment.Primary != null) {
                if (DeteriorateCheck(__instance.CasterPawn.equipment.Primary, SettingsHelper.LatestVersion.detoriationRangedUsedRate / 100f) > 0) {
                    Deteriorate(__instance.CasterPawn.equipment.Primary, __instance.CasterPawn, SettingsHelper.LatestVersion.damageIncreaseRangedWeapon, SettingsHelper.LatestVersion.damageIncreaseRandomRangedWeapon);
                }
            }
        }

        public static float QualityCheck(Thing item, float input) {
            if (item.TryGetQuality(out QualityCategory quality)) {
                switch (quality) {
                    case QualityCategory.Awful: {
                            // Log.Message(SettingsHelper.LatestVersion.awful.ToString()+ "*" + input + "=" + input * SettingsHelper.LatestVersion.awful);
                            return input * SettingsHelper.LatestVersion.awful;
                        }
                    case QualityCategory.Poor: {
                            // Log.Message(SettingsHelper.LatestVersion.poor.ToString() + "*" + input + "=" + input * SettingsHelper.LatestVersion.poor);
                            return input * SettingsHelper.LatestVersion.poor;
                        }
                    case QualityCategory.Normal: {
                            // Log.Message(SettingsHelper.LatestVersion.normal.ToString() + "*" + input + "=" + input * SettingsHelper.LatestVersion.normal);
                            return input * SettingsHelper.LatestVersion.normal;
                        }
                    case QualityCategory.Good: {
                            // Log.Message(SettingsHelper.LatestVersion.good.ToString() + "*" + input + "=" + input * SettingsHelper.LatestVersion.good);
                            return input * SettingsHelper.LatestVersion.good;
                        }
                    case QualityCategory.Excellent: {
                            // Log.Message(SettingsHelper.LatestVersion.excellent.ToString() + "*" + input + "=" + input * SettingsHelper.LatestVersion.excellent);
                            return input * SettingsHelper.LatestVersion.excellent;
                        }
                    case QualityCategory.Masterwork: {
                            // Log.Message(SettingsHelper.LatestVersion.masterwork.ToString() + "*" + input + "=" + input * SettingsHelper.LatestVersion.masterwork);
                            return input * SettingsHelper.LatestVersion.masterwork;
                        }
                    case QualityCategory.Legendary: {
                            // Log.Message(SettingsHelper.LatestVersion.legendary.ToString() + "*" + input + "=" + input * SettingsHelper.LatestVersion.legendary);
                            return input * SettingsHelper.LatestVersion.legendary;
                        }
                }
            }
            return input;
        }
        public static void Deteriorate(Thing item, Pawn pawn, float damageIncrement, bool random) {

            float damage = random || damageIncrement != 1
                ? Rand.Range(1, damageIncrement)
                : damageIncrement;
            //Log.Message("Damage: " + damage);
            if (damage > item.HitPoints && PawnUtility.ShouldSendNotificationAbout(pawn) && !pawn.Dead) {
                string str = "MessageWornApparelDeterioratedAway".Translate(GenLabel.ThingLabel(item.def, item.Stuff), pawn);
                str = str.CapitalizeFirst();
                Messages.Message(str, pawn, MessageTypeDefOf.NegativeEvent);
            }
            item.TakeDamage(new DamageInfo(DamageDefOf.Deterioration, damage));
        }
        public static int DeteriorateCheck(Thing item, float chance) {
            if (item.MaxHitPoints == 0)
                return 0;
            //Log.Message("Deterioration check for: " + item + " Chance to deteriorate: " + chance);
            return SettingsHelper.LatestVersion.qualityMatters ?
                           GenMath.RoundRandom(QualityCheck(item, chance))
                           : GenMath.RoundRandom(chance);
        }
    }




}