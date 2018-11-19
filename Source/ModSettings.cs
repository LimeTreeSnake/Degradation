using Verse;
using UnityEngine;

namespace Equipment_Deterioration
{
    internal class DeteriorationSettings : ModSettings
    {
        public float detoriationDailyRate = base_detoriationDailyRate;
        public float detoriationRangedUsedRate = base_detoriationRangedUsedRate;
        public float detoriationMeleeUsedRate = base_detoriationMeleeUsedRate;

        private static readonly float base_detoriationDailyRate = 0.25f;
        private static readonly float base_detoriationRangedUsedRate = 0.05f;
        private static readonly float base_detoriationMeleeUsedRate = 0.15f;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref detoriationDailyRate, "DetoriationDailyRate", base_detoriationDailyRate);
            Scribe_Values.Look(ref detoriationRangedUsedRate, "DetoriationUsedRate", base_detoriationRangedUsedRate);
            Scribe_Values.Look(ref detoriationMeleeUsedRate, "DetoriationUsedRate", base_detoriationMeleeUsedRate);
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
            Rect rectTop = inRect.TopHalf();
            Rect rectBot = inRect.BottomHalf();

            Rect rect1 = rectTop.TopHalf();
            Rect rect2 = rectTop.BottomHalf();
            Rect rect3 = rectBot.TopHalf();
            Rect rect4 = rectBot.BottomHalf();

            deteriorationSettings.detoriationDailyRate = Widgets.HorizontalSlider(rect1.TopHalf().ContractedBy(5f), deteriorationSettings.detoriationDailyRate, 0f, 1f, middleAlignment: true, "Deterioration Daily Rate " + deteriorationSettings.detoriationDailyRate * 100f + "\n Determines the chance of which items carried detoriates by 1 point each day.", "0%", "100%");
            deteriorationSettings.detoriationRangedUsedRate = Widgets.HorizontalSlider(rect1.BottomHalf().ContractedBy(5f), deteriorationSettings.detoriationRangedUsedRate, 0f, 1f, middleAlignment: true, "Deterioration Ranged Use Rate " + deteriorationSettings.detoriationRangedUsedRate * 100f + "\n Determines the chance of which Ranged weapons used detoriates by 1 for each Shot.", "0%", "100%");
            deteriorationSettings.detoriationMeleeUsedRate = Widgets.HorizontalSlider(rect2.TopHalf().ContractedBy(5f), deteriorationSettings.detoriationMeleeUsedRate, 0f, 1f, middleAlignment: true, "Deterioration Melee Use Rate " + deteriorationSettings.detoriationMeleeUsedRate * 100f + "\n Determines the chance of which Melee weapons used detoriates by 1 for each Hit.", "0%", "100%");

            deteriorationSettings.Write();
        }
    }
}
