using Verse;
using UnityEngine;

namespace Equipment_Deterioration
{
    internal class DeteriorationSettings : ModSettings
    {
        public float detoriationRate = base_detoriationRate;

        private static readonly float base_detoriationRate = 0.25f;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref detoriationRate, "DetoriationRate", base_detoriationRate);
        }
    }

    internal static class SettingsHelper
    {
        public static DeteriorationSettings latest;
    }

    public class ModMain : Mod
    {
        private DeteriorationSettings deteriorationSettings;
        public ModMain(ModContentPack content) : base(content)
        {
            deteriorationSettings = GetSettings<DeteriorationSettings>();
            SettingsHelper.latest = deteriorationSettings;
        }

        public override string SettingsCategory()
        {
            return "Equipment Deterioration";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Rect rect = inRect.TopHalf();
            deteriorationSettings.detoriationRate = Widgets.HorizontalSlider(rect.TopHalf().ContractedBy(5f), deteriorationSettings.detoriationRate, 0f, 1f, middleAlignment: true, "Deterioration Rate " + deteriorationSettings.detoriationRate * 100f + "\n Determines the chance of which items carried detoriates by 1 point each day.", "0%", "100%");

            deteriorationSettings.Write();
        }
    }
}
