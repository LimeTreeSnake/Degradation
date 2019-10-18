
using Verse;
using RimWorld;
using Harmony;

namespace Degradation {
    public static class Utility {
        public static bool Eligable(Verb __instance) {
            if (__instance.CasterIsPawn && !__instance.CasterPawn.AnimalOrWildMan() && !__instance.caster.def.IsBuildingArtificial && __instance.CasterPawn.equipment != null && __instance.CasterPawn.equipment.Primary != null) {
                return true;
            }
            return false;
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
        /// <summary>
        /// Check wether the item should degrade.
        /// </summary>
        /// <param name="item">The item in question</param>
        /// <param name="chance">The chance that the item degrades.</param>
        /// <returns></returns>
        public static int DegradeCheck(Thing item, float chance) {
            if (item.MaxHitPoints <= 1 || item.HitPoints <= 0 || item.def.useHitPoints == false || chance == 0) {
                return 0;
            }
            float x = chance;
            if (SettingsHelper.LatestVersion.qualityMatters) {
                x = QualityCheck(item, chance);
            }
            return GenMath.RoundRandom(x >= 100f ? 100f : x);
        }
        /// <summary>
        /// Degrades an item
        /// </summary>
        /// <param name="item">The item in question</param>
        /// <param name="pawn">The pawn with the item</param>
        /// <param name="damageIncrease">Extra damage</param>
        /// <param name="random">If damage should be randomized</param>
        public static void Degrade(Thing item, Pawn pawn, float damageIncrease, bool random) {
            float damage = random && damageIncrease >= 1 
                ? Rand.Range(1, damageIncrease)
                : damageIncrease;
            if (damage > 0) {
                item.TakeDamage(new DamageInfo(DamageDefOf.Deterioration, damage));
            }
            if(item != null && item.Destroyed && PawnUtility.ShouldSendNotificationAbout(pawn) && !pawn.Dead) {
                pawn.jobs.ClearQueuedJobs();
                string str = "MessageWornApparelDeterioratedAway".Translate(GenLabel.ThingLabel(item.def, item.Stuff), pawn);
                str = str.CapitalizeFirst();
                Messages.Message(str, pawn, MessageTypeDefOf.NegativeEvent);
            }
        }
        public static bool JamCheck(Thing item, float maxPercentage) {
            float percentage = (maxPercentage / 100f) * ((1f - item.HitPoints) / item.MaxHitPoints);
            return DegradeCheck(item, percentage) > 0;
        }
        public static void Fire<T>(T __instance, float degradationRate, float damageIncrease, bool useRandom, bool __result = true, bool useAlternateFormula = false) where T : Verb {
            if (degradationRate > 0f) {
                if (SettingsHelper.LatestVersion.minigunExcemption && __instance.CasterPawn.equipment.Primary.def.defName == "Gun_Minigun") {
                    return;
                }
                if (__result) {
                    if (!SettingsHelper.LatestVersion.npcdegrade) {
                        if (!__instance.CasterPawn.IsColonistPlayerControlled) {
                            return;
                        }
                    }
                    float num = degradationRate;
                    if (useAlternateFormula) {
                        int x = Traverse.Create(__instance).Property("ShotsPerBurst").GetValue<int>();
                        num = degradationRate * (1f + (SettingsHelper.LatestVersion.bulletMattersDamage * (float)x) / 100f);
                    }
                    if (DegradeCheck(__instance.CasterPawn.equipment.Primary, num / 100f) > 0) {
                        Degrade(__instance.CasterPawn.equipment.Primary, __instance.CasterPawn, damageIncrease, useRandom);
                    }
                }
            }
        }


    }
}
