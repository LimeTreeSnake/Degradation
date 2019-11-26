
using Verse;
using RimWorld;
using Harmony;
using Verse.Sound;

namespace Degradation
{
    public static class Utility
    {
        public static bool Eligable(Verb __instance) {
            if (__instance.CasterIsPawn && !__instance.CasterPawn.AnimalOrWildMan() && !__instance.caster.def.IsBuildingArtificial && __instance.EquipmentSource != null) {
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
        /// <param name="chance">The chance that the item degrades in whole percent E.G 0f-100f.</param>
        /// <returns></returns>
        public static int DegradeCheck(Thing item, float chance) {
            if (item.MaxHitPoints <= 1 || item.HitPoints <= 0 || item.def.useHitPoints == false || chance == 0) {
                return 0;
            }
            float x = ((float)chance / 100f) * ((((float)item.HitPoints - (float)item.MaxHitPoints)) * -1f);
            if (x == 0)
                return 0;
            if (SettingsHelper.LatestVersion.qualityMatters) {
                x = QualityCheck(item, x);
            }
            x /= 100f;
            int res = GenMath.RoundRandom(x >= 1f ? 1f : x);
            return res;
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
            if (item != null && item.Destroyed && PawnUtility.ShouldSendNotificationAbout(pawn) && !pawn.Dead) {
                pawn.jobs.ClearQueuedJobs();
                string str = "MessageWornApparelDeterioratedAway".Translate(GenLabel.ThingLabel(item.def, item.Stuff), pawn);
                str = str.CapitalizeFirst();
                Messages.Message(str, pawn, MessageTypeDefOf.NegativeEvent);
            }
        }
        public static bool JamCheck(Thing item, Pawn pawn, float maxPercentage) {
            if (DegradeCheck(item, maxPercentage) > 0) {
                if (SettingsHelper.LatestVersion.jammingMattersBreakable)
                    Degrade(item, pawn, SettingsHelper.LatestVersion.damageIncreaseRangedWeapon, SettingsHelper.LatestVersion.damageIncreaseRandomRangedWeapon);
                if (item.def.soundInteract != null) {
                    item.def.soundInteract.PlayOneShot(new TargetInfo(pawn.Position, pawn.Map));
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Takes in a verb and executes degradation code if applicable.
        /// </summary>
        /// <typeparam name="T">Verb type</typeparam>
        /// <param name="__instance">The verb instance</param>
        public static void Fire<T>(T __instance) where T : Verb {
            if (!SettingsHelper.LatestVersion.npcdegrade) {
                if (!__instance.CasterPawn.IsColonistPlayerControlled) {
                    return;
                }
            }
            bool random;
            float rate;
            float damage;
            if (__instance.IsMeleeAttack) {
                rate = SettingsHelper.LatestVersion.degradationMeleeUsedRate;
                damage = SettingsHelper.LatestVersion.damageIncreaseMeleeWeapon;
                random = SettingsHelper.LatestVersion.damageIncreaseRandomMeleeWeapon;
            }
            else {
                if (SettingsHelper.LatestVersion.minigunExcemption && __instance.EquipmentSource.def.defName == "Gun_Minigun") {
                    return;
                }
                rate = SettingsHelper.LatestVersion.degradationRangedUsedRate;
                damage = SettingsHelper.LatestVersion.damageIncreaseRangedWeapon;
                random = SettingsHelper.LatestVersion.damageIncreaseRandomRangedWeapon;
                if (SettingsHelper.LatestVersion.bulletMatters) {
                    int x = Traverse.Create(__instance).Property("ShotsPerBurst").GetValue<int>();
                    rate += rate * (SettingsHelper.LatestVersion.bulletMattersDamage * (float)x / 100f);

                }
            }
            if (DegradeCheck(__instance.EquipmentSource, rate) > 0) {
                Degrade(__instance.EquipmentSource, __instance.CasterPawn, damage, random);
            }
        }
    }
}
