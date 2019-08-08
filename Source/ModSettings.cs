using Verse;
using UnityEngine;

namespace Equipment_Deterioration {
    internal class DeteriorationSettings : ModSettings {

        #region Fields
        private static readonly bool base_removeVanillaSettings = true;

        private static readonly float base_detoriationApparellRate = 25f;
        private static readonly float base_detoriationEquipmentRate = 25f;
        private static readonly float base_detoriationInventoryRate = 25f;
        private static readonly float base_detoriationRangedUsedRate = 5f;
        private static readonly float base_detoriationMeleeUsedRate = 15f;

        private static readonly float base_damageIncreaseApparell = 1;
        private static readonly bool base_damageIncreaseRandomApparell = false;

        private static readonly float base_damageIncreaseEquipment = 1;
        private static readonly bool base_damageIncreaseRandomEquipment = false;

        private static readonly float base_damageIncreaseItem = 1;
        private static readonly bool base_damageIncreaseRandomItem = false;

        private static readonly float base_damageIncreaseRangedWeapon = 1;
        private static readonly bool base_damageIncreaseRandomRangedWeapon = false;

        private static readonly float base_damageIncreaseMeleeWeapon = 1;
        private static readonly bool base_damageIncreaseRandomMeleeWeapon = false;


        private static readonly bool base_qualityMatters = false;

        private static readonly float base_awful = 3f;
        private static readonly float base_poor = 2f;
        private static readonly float base_normal = 1f;
        private static readonly float base_good = 0.9f;
        private static readonly float base_excellent = 0.7f;
        private static readonly float base_masterwork = 0.5f;
        private static readonly float base_legendary = 0.3f;
        #endregion Fields

        #region Properties
        public float detoriationApparellRate = base_detoriationApparellRate;
        public float detoriationEquipmentRate = base_detoriationEquipmentRate;
        public float detoriationInventoryRate = base_detoriationInventoryRate;
        public float detoriationRangedUsedRate = base_detoriationRangedUsedRate;
        public float detoriationMeleeUsedRate = base_detoriationMeleeUsedRate;

        public bool removeVanillaSettings = base_removeVanillaSettings;

        public float damageIncreaseApparell = base_damageIncreaseApparell;
        public bool damageIncreaseRandomApparell = base_damageIncreaseRandomApparell;

        public float damageIncreaseEquipment = base_damageIncreaseEquipment;
        public bool damageIncreaseRandomEquipment = base_damageIncreaseRandomEquipment;

        public float damageIncreaseItem = base_damageIncreaseItem;
        public bool damageIncreaseRandomItem = base_damageIncreaseRandomItem;

        public float damageIncreaseRangedWeapon = base_damageIncreaseRangedWeapon;
        public bool damageIncreaseRandomRangedWeapon = base_damageIncreaseRandomRangedWeapon;

        public float damageIncreaseMeleeWeapon = base_damageIncreaseMeleeWeapon;
        public bool damageIncreaseRandomMeleeWeapon = base_damageIncreaseRandomMeleeWeapon;
        
        public bool qualityMatters = base_qualityMatters;

        public float awful = base_awful;
        public float poor = base_poor;
        public float normal = base_normal;
        public float good = base_good;
        public float excellent = base_excellent;
        public float masterwork = base_masterwork;
        public float legendary = base_legendary;
        #endregion Properties

        public override void ExposeData() {
            base.ExposeData();
            Scribe_Values.Look(ref removeVanillaSettings, "RemoveVanillaSettings", base_removeVanillaSettings);
            Scribe_Values.Look(ref detoriationApparellRate, "DetoriationApparellRate", base_detoriationApparellRate);
            Scribe_Values.Look(ref detoriationEquipmentRate, "DetoriationEquipmentRate", base_detoriationEquipmentRate);
            Scribe_Values.Look(ref detoriationInventoryRate, "DetoriationInventoryRate", base_detoriationInventoryRate);
            Scribe_Values.Look(ref detoriationRangedUsedRate, "DetoriationRangedUsedRate", base_detoriationRangedUsedRate);
            Scribe_Values.Look(ref detoriationMeleeUsedRate, "DetoriationMeleeUsedRate", base_detoriationMeleeUsedRate);


            Scribe_Values.Look(ref damageIncreaseApparell, "DamageIncreaseApparell", base_damageIncreaseApparell);
            Scribe_Values.Look(ref damageIncreaseRandomApparell, "DamageIncreaseRandomApparell", base_damageIncreaseRandomApparell);

            Scribe_Values.Look(ref damageIncreaseEquipment, "DamageIncreaseEquipment", base_damageIncreaseEquipment);
            Scribe_Values.Look(ref damageIncreaseRandomEquipment, "DamageIncreaseRandomEquipment", base_damageIncreaseRandomEquipment);

            Scribe_Values.Look(ref damageIncreaseItem, "DamageIncreaseItem", base_damageIncreaseItem);
            Scribe_Values.Look(ref damageIncreaseRandomItem, "DamageIncreaseRandomItem", base_damageIncreaseRandomItem);

            Scribe_Values.Look(ref damageIncreaseRangedWeapon, "DamageIncreaseRangedWeapon", base_damageIncreaseRangedWeapon);
            Scribe_Values.Look(ref damageIncreaseRandomRangedWeapon, "DamageIncreaseRandomRangedWeapon", base_damageIncreaseRandomRangedWeapon);

            Scribe_Values.Look(ref damageIncreaseMeleeWeapon, "DamageIncreaseMeleeWeapon", base_damageIncreaseMeleeWeapon);
            Scribe_Values.Look(ref damageIncreaseRandomMeleeWeapon, "DamageIncreaseRandomMeleeWeapon", base_damageIncreaseRandomMeleeWeapon);

            Scribe_Values.Look(ref qualityMatters, "QualityMatters", base_qualityMatters);
            Scribe_Values.Look(ref awful, "Awful", base_awful);
            Scribe_Values.Look(ref poor, "Poor", base_poor);
            Scribe_Values.Look(ref normal, "Normal", base_normal);
            Scribe_Values.Look(ref good, "Good", base_good);
            Scribe_Values.Look(ref excellent, "Excellent", base_excellent);
            Scribe_Values.Look(ref masterwork, "Masterwork", base_masterwork);
            Scribe_Values.Look(ref legendary, "Legendary", base_legendary);
        }
    }

    internal static class SettingsHelper {
        public static DeteriorationSettings LatestVersion;
    }


    public class ModMain : Mod {
        private DeteriorationSettings deteriorationSettings;
        public ModMain(ModContentPack content) : base(content) {
            deteriorationSettings = GetSettings<DeteriorationSettings>();
            SettingsHelper.LatestVersion = deteriorationSettings;
        }

        public override string SettingsCategory() {
            return "Equipment Deterioration";
        }

        public static Vector2 scrollPosition = Vector2.zero;

        public override void DoSettingsWindowContents(Rect inRect) {
            inRect.yMin += 20;
            inRect.yMax -= 20;
            Listing_Standard list = new Listing_Standard();
            Rect rect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
            Rect rect2 = new Rect(0f, 0f, inRect.width - 16f, inRect.height * 2 + 400f);
            Widgets.BeginScrollView(rect, ref scrollPosition, rect2, true);
            list.Begin(rect2);

            list.CheckboxLabeled("Remove vanilla deterioration", ref deteriorationSettings.removeVanillaSettings, "Apparrel on pawns in vanilla Rimworld have a 40% chance of losing 1 durability each day. Check this box if you want this feature removed. If you decide to have this option off, then there is a chance to have multiple deteriorations per day.");
            list.Gap();

            list.CheckboxLabeled("Quality Matters", ref deteriorationSettings.qualityMatters, string.Format("This mode ensures that your items will have their chance at taking damage depend on the quality of said item."));
            if (deteriorationSettings.qualityMatters) {
                list.Label(string.Format("These values can be changed to either increase or decrease damage done to that have quality."));
                list.Label(string.Format("A lower value means less chance for items taking deterioration damage."));
                list.Label(string.Format("{0} awful", deteriorationSettings.awful));
                deteriorationSettings.awful = Mathf.Round(list.Slider(deteriorationSettings.awful, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} poor", deteriorationSettings.poor));
                deteriorationSettings.poor = Mathf.Round(list.Slider(deteriorationSettings.poor, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} normal", deteriorationSettings.normal));
                deteriorationSettings.normal = Mathf.Round(list.Slider(deteriorationSettings.normal, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} good", deteriorationSettings.good));
                deteriorationSettings.good = Mathf.Round(list.Slider(deteriorationSettings.good, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} excellent", deteriorationSettings.excellent));
                deteriorationSettings.excellent = Mathf.Round(list.Slider(deteriorationSettings.excellent, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} masterwork", deteriorationSettings.masterwork));
                deteriorationSettings.masterwork = Mathf.Round(list.Slider(deteriorationSettings.masterwork, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} legendary", deteriorationSettings.legendary));
                deteriorationSettings.legendary = Mathf.Round(list.Slider(deteriorationSettings.legendary, 0f, 100f) * 100f) / 100f;
                list.Gap();
            }
            list.GapLine();
            list.Gap();
            list.Label(string.Format("{0}% chance per day for apparell worn to take deterioration damage", deteriorationSettings.detoriationApparellRate), 20,
                 "Determines the chance of which apparell worn by pawns deteriorate.");
            deteriorationSettings.detoriationApparellRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationApparellRate, 0f, 100f) * 100f) / 100f;
            list.Label(string.Format("{0}% chance per day for equipment worn to take deterioration damage", deteriorationSettings.detoriationEquipmentRate), 20,
                "Determines the chance of which items equipped by pawns deteriorate.");
            deteriorationSettings.detoriationEquipmentRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationEquipmentRate, 0f, 100f) * 100f) / 100f;
            list.Label(string.Format("{0}% chance per day for items carried to take deterioration damage", deteriorationSettings.detoriationInventoryRate), 20,
                "Determines the chance of which items carried in inventory deteriorate.");
            deteriorationSettings.detoriationInventoryRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationInventoryRate, 0f, 100f) * 100f) / 100f; ;
            list.Label(string.Format("{0}% chance for Ranged weapons firing upon something to take deterioration damage", deteriorationSettings.detoriationRangedUsedRate), 20,
                "Determines the chance of which Ranged weapons used deteriorate.");
            deteriorationSettings.detoriationRangedUsedRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationRangedUsedRate, 0f, 100f) * 100f) / 100f;
            list.Label(string.Format("{0}% chance for Melee weapons used to smash to take deterioration damage", deteriorationSettings.detoriationMeleeUsedRate), 20,
                "Determines the chance of which Melee weapons used deteriorate");
            deteriorationSettings.detoriationMeleeUsedRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationMeleeUsedRate, 0f, 100f) * 100f) / 100f;
            list.Gap();
            list.GapLine();
            list.Gap();
            list.Label(string.Format("apparell worn deterioration damage - ({0})", deteriorationSettings.damageIncreaseApparell));
            deteriorationSettings.damageIncreaseApparell = (int)list.Slider(deteriorationSettings.damageIncreaseApparell, 1f, 10f);
            list.CheckboxLabeled("Randomize damage done to equipment", ref deteriorationSettings.damageIncreaseRandomApparell,
                string.Format("With this setting on, the damage done to equipment worn will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseApparell));

            list.Gap();
            list.GapLine();
            list.Label(string.Format("equipment worn deterioration damage - ({0})", deteriorationSettings.damageIncreaseEquipment));
            deteriorationSettings.damageIncreaseEquipment = (int)list.Slider(deteriorationSettings.damageIncreaseEquipment, 1f, 10f);
            list.CheckboxLabeled("Randomize damage done to equipment", ref deteriorationSettings.damageIncreaseRandomEquipment,
                string.Format("With this setting on, the damage done to equipment worn will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseEquipment));

            list.Gap();
            list.GapLine();
            list.Label(string.Format("Items carried deterioration damage - ({0})", deteriorationSettings.damageIncreaseItem));
            deteriorationSettings.damageIncreaseItem = (int)list.Slider(deteriorationSettings.damageIncreaseItem, 1f, 10f);
            list.CheckboxLabeled("Randomize damage done to items", ref deteriorationSettings.damageIncreaseRandomItem,
                string.Format("With this setting on, the damage done to items carried will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseItem));

            list.Gap();
            list.GapLine();
            list.Label(string.Format("Ranged weapons deterioration damage - ({0})", deteriorationSettings.damageIncreaseRangedWeapon));
            deteriorationSettings.damageIncreaseRangedWeapon = (int)list.Slider(deteriorationSettings.damageIncreaseRangedWeapon, 1f, 10f);
            list.CheckboxLabeled("Randomize damage done to ranged weapons", ref deteriorationSettings.damageIncreaseRandomRangedWeapon,
                 string.Format("With this setting on, the damage done to the ranged weapon when firing will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseRangedWeapon));

            list.Gap();
            list.GapLine();
            list.Label(string.Format("Melee weapons deterioration damage - ({0})", deteriorationSettings.damageIncreaseMeleeWeapon));
            deteriorationSettings.damageIncreaseMeleeWeapon = (int)list.Slider(deteriorationSettings.damageIncreaseMeleeWeapon, 1f, 10f);
            list.CheckboxLabeled("Randomize damage done to melee weapons", ref deteriorationSettings.damageIncreaseRandomMeleeWeapon,
                string.Format("With this setting on, the damage done to the melee weapon when used will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseMeleeWeapon));

            list.GapLine();
            list.End();
            Widgets.EndScrollView();

            deteriorationSettings.Write();
        }
    }
}
