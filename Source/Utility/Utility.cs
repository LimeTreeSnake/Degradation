using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Degradation.Utility {
    public static class Utility {
        private static List<Pawn> pawnWithWornoutWeapons = new List<Pawn>();
        public static bool JamCheck(Thing thing) {
            if (Rand.Value + 0.2f > thing.HitPoints / thing.MaxHitPoints) {
                return QualityCheck(thing);
            }
            return false;
        }
        public static bool QualityCheck(Thing thing) {
            if (thing.TryGetQuality(out QualityCategory qc))
                switch (qc) {
                    case QualityCategory.Awful: {
                            if (Settings.SettingsHelper.LatestVersion.Awful != 0 && Rand.Value < Settings.SettingsHelper.LatestVersion.Awful / 100f) {
                                return true;
                            }
                            break;
                        }
                    case QualityCategory.Poor: {
                            if (Settings.SettingsHelper.LatestVersion.Poor != 0 && Rand.Value < Settings.SettingsHelper.LatestVersion.Poor / 100f) {
                                return true;
                            }
                            break;
                        }
                    case QualityCategory.Normal: {
                            if (Settings.SettingsHelper.LatestVersion.Normal != 0 && Rand.Value < Settings.SettingsHelper.LatestVersion.Normal / 100f) {
                                return true;
                            }
                            break;
                        }
                    case QualityCategory.Good: {
                            if (Settings.SettingsHelper.LatestVersion.Good != 0 && Rand.Value < Settings.SettingsHelper.LatestVersion.Good / 100f) {
                                return true;
                            }
                            break;
                        }
                    case QualityCategory.Excellent: {
                            if (Settings.SettingsHelper.LatestVersion.Excellent != 0 && Rand.Value < Settings.SettingsHelper.LatestVersion.Excellent / 100f) {
                                return true;
                            }
                            break;
                        }
                    case QualityCategory.Masterwork: {
                            if (Settings.SettingsHelper.LatestVersion.Masterwork != 0 && Rand.Value < Settings.SettingsHelper.LatestVersion.Masterwork / 100f) {
                                return true;
                            }
                            break;
                        }
                    case QualityCategory.Legendary: {
                            if (Settings.SettingsHelper.LatestVersion.Legendary != 0 && Rand.Value < Settings.SettingsHelper.LatestVersion.Legendary / 100f) {
                                return true;
                            }
                            break;
                        }
                    default: {
                            break;
                        }
                }
            return false;
        }
        public static void Degrade(Thing thing, Pawn pawn) {
            thing.TakeDamage(new DamageInfo(DamageDefOf.Deterioration, 1));
            if (thing.Destroyed && PawnUtility.ShouldSendNotificationAbout(pawn) && !pawn.Dead) {
                pawn.jobs.ClearQueuedJobs();
                Messages.Message(GenText.CapitalizeFirst("MessageWornApparelDeterioratedAway".Translate(GenLabel.ThingLabel(thing.def, thing.Stuff), pawn)), pawn, MessageTypeDefOf.NegativeEvent);
            }
        }
        public static List<Pawn> WornoutWeapons {
            get {
                pawnWithWornoutWeapons.Clear();
                foreach (Pawn item in PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep) {
                    if (!item.Downed && item.equipment?.Primary?.HitPoints < Settings.SettingsHelper.LatestVersion.Alert) {
                        pawnWithWornoutWeapons.Add(item);
                    }
                }
                return pawnWithWornoutWeapons;
            }
        }
    }
}
