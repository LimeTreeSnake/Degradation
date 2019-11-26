using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Degradation
{
    public class Alert_WeaponDamaged : Alert
    {
        private IEnumerable<Pawn> ColonistWeaponsDegraded {
            get {
                List<Map> maps = Find.Maps;
                for (int i = 0; i < maps.Count; i++) {
                    if (maps[i].IsPlayerHome) {
                        foreach (Pawn p in maps[i].mapPawns.FreeColonistsSpawned) {
                            bool degrading = false;
                            foreach (Thing thing in p.equipment.AllEquipmentListForReading) {
                                if (thing.HitPoints / thing.MaxHitPoints < SettingsHelper.LatestVersion.AlertWeaponValue / 100f)
                                    degrading = true;
                                if (degrading)
                                    yield return p;
                            }
                        }
                    }
                }
            }
        }
        public override string GetExplanation() {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Pawn idleColonist in ColonistWeaponsDegraded) {
                stringBuilder.AppendLine("    " + idleColonist.LabelShort.CapitalizeFirst());
            }
            return "WeaponDegradeWarningDesc".Translate(stringBuilder.ToString());
        }
        public override string GetLabel() {
            return "WeaponDegradeWarning".Translate(ColonistWeaponsDegraded.Count().ToStringCached());
        }
        public override AlertReport GetReport() {
            if (SettingsHelper.LatestVersion.AlertWeapon)
                return AlertReport.CulpritsAre(ColonistWeaponsDegraded);
            return false;
        }
    }
}
