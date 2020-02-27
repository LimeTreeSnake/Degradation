using RimWorld;
using Verse;

namespace Degradation.Alerts {
    public class Alert_Degradation : Alert {
		public Alert_Degradation() {
			defaultPriority = AlertPriority.High;
		}
		public override string GetLabel() {
			return Language.Language.DegradeWarning;
		}
		public override TaggedString GetExplanation() {
			return Language.Language.DegradeWarningDesc;
		}
		public override AlertReport GetReport() {
			return AlertReport.CulpritsAre(Utility.Utility.WornoutWeapons);
		}
	}
}
