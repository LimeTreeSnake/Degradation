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


        private static readonly bool base_npcDeteriorate = false;
        private static readonly bool base_bulletMatters = false;
        private static readonly float base_bulletMattersDamage = 3;

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



        public bool bulletMatters = base_bulletMatters;
        public float bulletMattersDamage = base_bulletMattersDamage;

        public bool qualityMatters = base_qualityMatters;
        public bool npcDeteriorate = base_npcDeteriorate;


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

            Scribe_Values.Look(ref bulletMatters, "BulletMatters", base_bulletMatters);
            Scribe_Values.Look(ref bulletMattersDamage, "BulletMattersDamage", base_bulletMattersDamage);

            Scribe_Values.Look(ref npcDeteriorate, "NPCDeteriorate", base_npcDeteriorate);
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
            list.CheckboxLabeled("NPC stuff deteriorates too", ref deteriorationSettings.npcDeteriorate, string.Format("With this option on, NPC's equipment will deteriorate as well."));
            list.CheckboxLabeled("Bullet Matters", ref deteriorationSettings.bulletMatters, string.Format("This mode increases the deterioration chance for weapons that fire multiple bullets."));
            if (deteriorationSettings.bulletMatters) {
                list.Label(string.Format("{0} Percentual multiplier deterioration chance per bullet. (Hover for example)", deteriorationSettings.bulletMattersDamage), -1, string.Format("" +
                    "Example: You have a minigun that fires 24 rounds. " +
                    "\nEach round increases the chance for damage by {0}%. " +
                    "\nThe base detoriate chance for weapons fired is {1}%." + ". " +
                    "\nwhich means a " + deteriorationSettings.bulletMattersDamage * 24 + "% increased chance for damage." +
                    "\nGrand total of " + deteriorationSettings.detoriationRangedUsedRate * (1 + (SettingsHelper.LatestVersion.bulletMattersDamage * 24) / 100) + "%.", deteriorationSettings.bulletMattersDamage, deteriorationSettings.detoriationRangedUsedRate) + " chance for damage." +
                    "\n\nNotice: Values over 100% does not increase damage.");
                deteriorationSettings.bulletMattersDamage = Mathf.Round(list.Slider(deteriorationSettings.bulletMattersDamage, 1f, 100f) * 100f) / 100f;
                list.Gap();
            }
            list.CheckboxLabeled("Quality Matters", ref deteriorationSettings.qualityMatters, string.Format("This mode ensures that your items will have their chance at taking damage depend on the quality of said item if applicable."));
            if (deteriorationSettings.qualityMatters) {
                list.Label(string.Format("A lower value means less chance for items taking deterioration damage."));
                list.Label(string.Format("{0} Awful", deteriorationSettings.awful));
                deteriorationSettings.awful = Mathf.Round(list.Slider(deteriorationSettings.awful, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} Poor", deteriorationSettings.poor));
                deteriorationSettings.poor = Mathf.Round(list.Slider(deteriorationSettings.poor, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} Normal", deteriorationSettings.normal));
                deteriorationSettings.normal = Mathf.Round(list.Slider(deteriorationSettings.normal, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} Good", deteriorationSettings.good));
                deteriorationSettings.good = Mathf.Round(list.Slider(deteriorationSettings.good, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} Excellent", deteriorationSettings.excellent));
                deteriorationSettings.excellent = Mathf.Round(list.Slider(deteriorationSettings.excellent, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} Masterwork", deteriorationSettings.masterwork));
                deteriorationSettings.masterwork = Mathf.Round(list.Slider(deteriorationSettings.masterwork, 0f, 100f) * 100f) / 100f;
                list.Label(string.Format("{0} Legendary", deteriorationSettings.legendary));
                deteriorationSettings.legendary = Mathf.Round(list.Slider(deteriorationSettings.legendary, 0f, 100f) * 100f) / 100f;
                list.Gap();
            }
            list.GapLine();
            list.Gap();
            list.Label(string.Format("{0}% Chance per day for apparell worn to take deterioration damage", deteriorationSettings.detoriationApparellRate), 20,
                 "Determines the chance of which apparell worn by pawns deteriorate.");
            deteriorationSettings.detoriationApparellRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationApparellRate, 0f, 100f) * 100f) / 100f;
            list.Label(string.Format("{0}% Chance per day for equipment worn to take deterioration damage", deteriorationSettings.detoriationEquipmentRate), 20,
                "Determines the chance of which items equipped by pawns deteriorate.");
            deteriorationSettings.detoriationEquipmentRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationEquipmentRate, 0f, 100f) * 100f) / 100f;
            list.Label(string.Format("{0}% Chance per day for items carried to take deterioration damage", deteriorationSettings.detoriationInventoryRate), 20,
                "Determines the chance of which items carried in inventory deteriorate.");
            deteriorationSettings.detoriationInventoryRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationInventoryRate, 0f, 100f) * 100f) / 100f; ;
            list.Label(string.Format("{0}% Chance for Ranged weapons firing upon something to take deterioration damage", deteriorationSettings.detoriationRangedUsedRate), 20,
                "Determines the chance of which Ranged weapons used deteriorate.");
            deteriorationSettings.detoriationRangedUsedRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationRangedUsedRate, 0f, 100f) * 100f) / 100f;
            list.Label(string.Format("{0}% Chance for Melee weapons used to smash to take deterioration damage", deteriorationSettings.detoriationMeleeUsedRate), 20,
                "Determines the chance of which Melee weapons used deteriorate");
            deteriorationSettings.detoriationMeleeUsedRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationMeleeUsedRate, 0f, 100f) * 100f) / 100f;
            list.GapLine();

            list.Gap();
            list.Label(string.Format("({0}) Apparell worn deterioration damage", deteriorationSettings.damageIncreaseApparell));
            deteriorationSettings.damageIncreaseApparell = (int)list.Slider(deteriorationSettings.damageIncreaseApparell, 1f, 10f);
            list.Label(string.Format("({0}) Equipment worn deterioration damage", deteriorationSettings.damageIncreaseEquipment));
            deteriorationSettings.damageIncreaseEquipment = (int)list.Slider(deteriorationSettings.damageIncreaseEquipment, 1f, 10f);
            list.Label(string.Format("({0}) Items carried deterioration damage", deteriorationSettings.damageIncreaseItem));
            deteriorationSettings.damageIncreaseItem = (int)list.Slider(deteriorationSettings.damageIncreaseItem, 1f, 10f);
            list.Label(string.Format("({0}) Ranged weapons deterioration damage", deteriorationSettings.damageIncreaseRangedWeapon));
            deteriorationSettings.damageIncreaseRangedWeapon = (int)list.Slider(deteriorationSettings.damageIncreaseRangedWeapon, 1f, 10f);
            list.Label(string.Format("({0}) Melee weapons deterioration damage", deteriorationSettings.damageIncreaseMeleeWeapon));
            deteriorationSettings.damageIncreaseMeleeWeapon = (int)list.Slider(deteriorationSettings.damageIncreaseMeleeWeapon, 1f, 10f);
            list.GapLine();

            list.Gap();
            list.CheckboxLabeled("Randomize damage done to apparell", ref deteriorationSettings.damageIncreaseRandomApparell,
                string.Format("With this setting on, the damage done to apparell worn will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseApparell));
            list.CheckboxLabeled("Randomize damage done to equipment", ref deteriorationSettings.damageIncreaseRandomEquipment,
                string.Format("With this setting on, the damage done to equipment worn will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseEquipment));
            list.CheckboxLabeled("Randomize damage done to items", ref deteriorationSettings.damageIncreaseRandomItem,
                string.Format("With this setting on, the damage done to items carried will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseItem));
            list.CheckboxLabeled("Randomize damage done to ranged weapons", ref deteriorationSettings.damageIncreaseRandomRangedWeapon,
                  string.Format("With this setting on, the damage done to the ranged weapon when firing will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseRangedWeapon));
            list.CheckboxLabeled("Randomize damage done to melee weapons", ref deteriorationSettings.damageIncreaseRandomMeleeWeapon,
                string.Format("With this setting on, the damage done to the melee weapon when used will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseMeleeWeapon));
            list.GapLine();
            list.End();
            Widgets.EndScrollView();

            deteriorationSettings.Write();
        }
    }
}
