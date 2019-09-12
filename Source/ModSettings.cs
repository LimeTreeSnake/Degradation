using Verse;
using UnityEngine;

namespace Equipment_Deterioration {
    internal class DeteriorationSettings : ModSettings {

        #region Fields
        private static readonly bool base_removeVanillaSettings = true;
        private static readonly bool base_npcDeteriorate = false;

        private static readonly bool base_qualityMatters = false;
        private static readonly float base_awful = 3f;
        private static readonly float base_poor = 2f;
        private static readonly float base_normal = 1f;
        private static readonly float base_good = 0.9f;
        private static readonly float base_excellent = 0.7f;
        private static readonly float base_masterwork = 0.5f;
        private static readonly float base_legendary = 0.3f;

        private static readonly bool base_deteriorateApparell = true;
        private static readonly float base_detoriationApparellRate = 25f;
        private static readonly float base_damageIncreaseApparell = 1;
        private static readonly bool base_damageIncreaseRandomApparell = false;

        private static readonly bool base_deteriorateEquipment = true;
        private static readonly float base_detoriationEquipmentRate = 25f;
        private static readonly float base_damageIncreaseEquipment = 1;
        private static readonly bool base_damageIncreaseRandomEquipment = false;

        private static readonly bool base_deteriorateInventory = true;
        private static readonly float base_detoriationInventoryRate = 25f;
        private static readonly float base_damageIncreaseItem = 1;
        private static readonly bool base_damageIncreaseRandomItem = false;

        private static readonly bool base_deteriorateMelee = true;
        private static readonly float base_detoriationMeleeUsedRate = 15f;
        private static readonly float base_damageIncreaseMeleeWeapon = 1;
        private static readonly bool base_damageIncreaseRandomMeleeWeapon = false;

        private static readonly bool base_deteriorateRanged = true;
        private static readonly float base_detoriationRangedUsedRate = 5f;
        private static readonly float base_damageIncreaseRangedWeapon = 1;
        private static readonly bool base_damageIncreaseRandomRangedWeapon = false;
        private static readonly bool base_bulletMatters = false;
        private static readonly float base_bulletMattersDamage = 3;
        private static readonly bool base_jammingMatters = false;
        private static readonly bool base_jammingMattersBreakable = false;
        private static readonly float base_jammingMatterPercentage = 33;


        private static readonly bool base_minigunExcemption = true;

        #endregion Fields

        #region Properties
        public bool removeVanillaSettings = base_removeVanillaSettings;
        public bool npcDeteriorate = base_npcDeteriorate;

        public bool qualityMatters = base_qualityMatters;
        public float awful = base_awful;
        public float poor = base_poor;
        public float normal = base_normal;
        public float good = base_good;
        public float excellent = base_excellent;
        public float masterwork = base_masterwork;
        public float legendary = base_legendary;

        public bool deteriorateApparell = base_deteriorateApparell;
        public float detoriationApparellRate = base_detoriationApparellRate;
        public float damageIncreaseApparell = base_damageIncreaseApparell;
        public bool damageIncreaseRandomApparell = base_damageIncreaseRandomApparell;

        public bool deteriorateEquipment = base_deteriorateEquipment;
        public float detoriationEquipmentRate = base_detoriationEquipmentRate;
        public float damageIncreaseEquipment = base_damageIncreaseEquipment;
        public bool damageIncreaseRandomEquipment = base_damageIncreaseRandomEquipment;

        public bool deteriorateInventory = base_deteriorateInventory;
        public float detoriationInventoryRate = base_detoriationInventoryRate;
        public float damageIncreaseItem = base_damageIncreaseItem;
        public bool damageIncreaseRandomItem = base_damageIncreaseRandomItem;

        public bool deteriorateMelee = base_deteriorateMelee;
        public float detoriationMeleeUsedRate = base_detoriationMeleeUsedRate;
        public float damageIncreaseMeleeWeapon = base_damageIncreaseMeleeWeapon;
        public bool damageIncreaseRandomMeleeWeapon = base_damageIncreaseRandomMeleeWeapon;

        public bool deteriorateRanged = base_deteriorateRanged;
        public float detoriationRangedUsedRate = base_detoriationRangedUsedRate;
        public float damageIncreaseRangedWeapon = base_damageIncreaseRangedWeapon;
        public bool damageIncreaseRandomRangedWeapon = base_damageIncreaseRandomRangedWeapon;
        public bool bulletMatters = base_bulletMatters;
        public float bulletMattersDamage = base_bulletMattersDamage;
        public bool jammingMatters = base_jammingMatters;
        public bool jammingMattersBreakable = base_jammingMattersBreakable;
        public float jammingMattersPercentage = base_jammingMatterPercentage;


        public bool minigunExcemption = base_minigunExcemption;

        #endregion Properties

        public override void ExposeData() {
            base.ExposeData();
            Scribe_Values.Look(ref removeVanillaSettings, "RemoveVanillaSettings", base_removeVanillaSettings);
            Scribe_Values.Look(ref npcDeteriorate, "NPCDeteriorate", base_npcDeteriorate);

            Scribe_Values.Look(ref qualityMatters, "QualityMatters", base_qualityMatters);
            Scribe_Values.Look(ref awful, "Awful", base_awful);
            Scribe_Values.Look(ref poor, "Poor", base_poor);
            Scribe_Values.Look(ref normal, "Normal", base_normal);
            Scribe_Values.Look(ref good, "Good", base_good);
            Scribe_Values.Look(ref excellent, "Excellent", base_excellent);
            Scribe_Values.Look(ref masterwork, "Masterwork", base_masterwork);
            Scribe_Values.Look(ref legendary, "Legendary", base_legendary);

            Scribe_Values.Look(ref deteriorateApparell, "DeteriorateApparell", base_deteriorateApparell);
            Scribe_Values.Look(ref detoriationApparellRate, "DetoriationApparellRate", base_detoriationApparellRate);
            Scribe_Values.Look(ref damageIncreaseApparell, "DamageIncreaseApparell", base_damageIncreaseApparell);
            Scribe_Values.Look(ref damageIncreaseRandomApparell, "DamageIncreaseRandomApparell", base_damageIncreaseRandomApparell);

            Scribe_Values.Look(ref deteriorateEquipment, "DeteriorateEquipment", base_deteriorateEquipment);
            Scribe_Values.Look(ref detoriationEquipmentRate, "DetoriationEquipmentRate", base_detoriationEquipmentRate);
            Scribe_Values.Look(ref damageIncreaseEquipment, "DamageIncreaseEquipment", base_damageIncreaseEquipment);
            Scribe_Values.Look(ref damageIncreaseRandomEquipment, "DamageIncreaseRandomEquipment", base_damageIncreaseRandomEquipment);

            Scribe_Values.Look(ref deteriorateInventory, "DeteriorateInventory", base_deteriorateInventory);
            Scribe_Values.Look(ref detoriationInventoryRate, "DetoriationInventoryRate", base_detoriationInventoryRate);
            Scribe_Values.Look(ref damageIncreaseItem, "DamageIncreaseItem", base_damageIncreaseItem);
            Scribe_Values.Look(ref damageIncreaseRandomItem, "DamageIncreaseRandomItem", base_damageIncreaseRandomItem);

            Scribe_Values.Look(ref deteriorateMelee, "DeteriorateMelee", base_deteriorateMelee);
            Scribe_Values.Look(ref detoriationMeleeUsedRate, "DetoriationMeleeUsedRate", base_detoriationMeleeUsedRate);
            Scribe_Values.Look(ref damageIncreaseMeleeWeapon, "DamageIncreaseMeleeWeapon", base_damageIncreaseMeleeWeapon);
            Scribe_Values.Look(ref damageIncreaseRandomMeleeWeapon, "DamageIncreaseRandomMeleeWeapon", base_damageIncreaseRandomMeleeWeapon);

            Scribe_Values.Look(ref deteriorateRanged, "DeteriorateRanged", base_deteriorateRanged);
            Scribe_Values.Look(ref detoriationRangedUsedRate, "DetoriationRangedUsedRate", base_detoriationRangedUsedRate);
            Scribe_Values.Look(ref damageIncreaseRangedWeapon, "DamageIncreaseRangedWeapon", base_damageIncreaseRangedWeapon);
            Scribe_Values.Look(ref damageIncreaseRandomRangedWeapon, "DamageIncreaseRandomRangedWeapon", base_damageIncreaseRandomRangedWeapon);
            Scribe_Values.Look(ref bulletMatters, "BulletMatters", base_bulletMatters);
            Scribe_Values.Look(ref bulletMattersDamage, "BulletMattersDamage", base_bulletMattersDamage);
            Scribe_Values.Look(ref jammingMatters, "JammingMatters", base_jammingMatters);
            Scribe_Values.Look(ref jammingMattersBreakable, "JammingMattersBreakable", base_jammingMattersBreakable);
            Scribe_Values.Look(ref jammingMattersPercentage, "JammingMattersPercentage", base_jammingMatterPercentage);

            Scribe_Values.Look(ref minigunExcemption, "MinigunExcemption", base_minigunExcemption);
        }

        public void Reset() {
            removeVanillaSettings = base_removeVanillaSettings;
            npcDeteriorate = base_npcDeteriorate;

            qualityMatters = base_qualityMatters;
            awful = base_awful;
            poor = base_poor;
            normal = base_normal;
            excellent = base_excellent;
            good = base_good;
            masterwork = base_masterwork;
            legendary = base_legendary;

            deteriorateApparell = base_deteriorateApparell;
            detoriationApparellRate = base_detoriationApparellRate;
            damageIncreaseApparell = base_damageIncreaseApparell;
            damageIncreaseRandomApparell = base_damageIncreaseRandomApparell;

            deteriorateEquipment = base_deteriorateEquipment;
            detoriationEquipmentRate = base_detoriationEquipmentRate;
            damageIncreaseEquipment = base_damageIncreaseEquipment;
            damageIncreaseRandomEquipment = base_damageIncreaseRandomEquipment;

            deteriorateInventory = base_deteriorateInventory;
            detoriationInventoryRate = base_detoriationInventoryRate;
            damageIncreaseItem = base_damageIncreaseItem;
            damageIncreaseRandomItem = base_damageIncreaseRandomItem;

            deteriorateMelee = base_deteriorateMelee;
            detoriationMeleeUsedRate = base_detoriationMeleeUsedRate;
            damageIncreaseMeleeWeapon = base_damageIncreaseMeleeWeapon;
            damageIncreaseRandomMeleeWeapon = base_damageIncreaseRandomMeleeWeapon;

            deteriorateRanged = base_deteriorateRanged;
            detoriationRangedUsedRate = base_detoriationRangedUsedRate;
            damageIncreaseRangedWeapon = base_damageIncreaseRangedWeapon;
            damageIncreaseRandomRangedWeapon = base_damageIncreaseRandomRangedWeapon;
            bulletMatters = base_bulletMatters;
            bulletMattersDamage = base_bulletMattersDamage;
            jammingMatters = base_jammingMatters;
            jammingMattersBreakable = base_jammingMattersBreakable;
            jammingMattersPercentage = base_jammingMatterPercentage;
            minigunExcemption = base_minigunExcemption;
        }
    }

    internal static class SettingsHelper {
        public static DeteriorationSettings LatestVersion;

        public static void Reset() {
            LatestVersion.Reset();
        }
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
            Rect rect2 = new Rect(0f, 0f, inRect.width - 16f, inRect.height * 2 + 450f);
            Widgets.BeginScrollView(rect, ref scrollPosition, rect2, true);
            list.Begin(rect2);
            if (list.ButtonText("Default Settings")) {
                deteriorationSettings.Reset();
            };
            list.CheckboxLabeled("Remove vanilla deterioration", ref deteriorationSettings.removeVanillaSettings, "Apparrel on pawns in vanilla Rimworld have a 40% chance of losing 1 durability each day. Check this box if you want this feature removed. If you decide to have this option off, then there is a chance to have multiple deteriorations per day.");
            list.CheckboxLabeled("NPC stuff deteriorates", ref deteriorationSettings.npcDeteriorate, string.Format("With this option on, NPC's equipment will deteriorate as well."));
            list.CheckboxLabeled("Quality Matters", ref deteriorationSettings.qualityMatters, string.Format("This mode ensures that your items will have their chance at taking damage depend on the quality of said item if applicable."));
            if (deteriorationSettings.qualityMatters) {
                list.Label(string.Format("A lower value means less chance for items taking deterioration damage."));

                float.TryParse(list.TextEntryLabeled("Awful ", string.Format("{0:#0.00}", deteriorationSettings.awful)), out deteriorationSettings.awful);
                deteriorationSettings.awful = Mathf.Round(list.Slider(deteriorationSettings.awful, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.awful = deteriorationSettings.awful > 100f ? 100f : deteriorationSettings.awful < 0f ? 0f : deteriorationSettings.awful;

                float.TryParse(list.TextEntryLabeled("Poor ", string.Format("{0:#0.00}", deteriorationSettings.poor)), out deteriorationSettings.poor);
                deteriorationSettings.poor = Mathf.Round(list.Slider(deteriorationSettings.poor, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.poor = deteriorationSettings.poor > 100f ? 100f : deteriorationSettings.poor < 0f ? 0f : deteriorationSettings.poor;

                float.TryParse(list.TextEntryLabeled("Normal ", string.Format("{0:#0.00}", deteriorationSettings.normal)), out deteriorationSettings.normal);
                deteriorationSettings.normal = Mathf.Round(list.Slider(deteriorationSettings.normal, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.normal = deteriorationSettings.normal > 100f ? 100f : deteriorationSettings.normal < 0f ? 0f : deteriorationSettings.normal;

                float.TryParse(list.TextEntryLabeled("Good ", string.Format("{0:#0.00}", deteriorationSettings.good)), out deteriorationSettings.good);
                deteriorationSettings.good = Mathf.Round(list.Slider(deteriorationSettings.good, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.good = deteriorationSettings.good > 100f ? 100f : deteriorationSettings.good < 0f ? 0f : deteriorationSettings.good;

                float.TryParse(list.TextEntryLabeled("Excellent ", string.Format("{0:#0.00}", deteriorationSettings.excellent)), out deteriorationSettings.excellent);
                deteriorationSettings.excellent = Mathf.Round(list.Slider(deteriorationSettings.excellent, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.excellent = deteriorationSettings.excellent > 100f ? 100f : deteriorationSettings.excellent < 0f ? 0f : deteriorationSettings.excellent;

                float.TryParse(list.TextEntryLabeled("Masterwork ", string.Format("{0:#0.00}", deteriorationSettings.masterwork)), out deteriorationSettings.masterwork);
                deteriorationSettings.masterwork = Mathf.Round(list.Slider(deteriorationSettings.masterwork, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.masterwork = deteriorationSettings.masterwork > 100f ? 100f : deteriorationSettings.masterwork < 0f ? 0f : deteriorationSettings.masterwork;

                float.TryParse(list.TextEntryLabeled("Legendary ", string.Format("{0:#0.00}", deteriorationSettings.legendary)), out deteriorationSettings.legendary);
                deteriorationSettings.legendary = Mathf.Round(list.Slider(deteriorationSettings.legendary, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.legendary = deteriorationSettings.legendary > 100f ? 100f : deteriorationSettings.legendary < 0f ? 0f : deteriorationSettings.legendary;

                list.Gap();
            }
            list.GapLine();
            list.Gap();
            list.CheckboxLabeled("Apparell Deteriorate", ref deteriorationSettings.deteriorateApparell, string.Format("This mode ensures that apparell worn by pawns detoriates with a {0}% chance per day", deteriorationSettings.detoriationApparellRate));
            if (deteriorationSettings.deteriorateApparell) {
                float.TryParse(list.TextEntryLabeled("Daily apparell deterioration rate ", string.Format("{0:#0.00}", deteriorationSettings.detoriationApparellRate)), out deteriorationSettings.detoriationApparellRate);
                deteriorationSettings.detoriationApparellRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationApparellRate, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.detoriationApparellRate = deteriorationSettings.detoriationApparellRate > 100f ? 100f : deteriorationSettings.detoriationApparellRate < 0 ? 0f : deteriorationSettings.detoriationApparellRate;
                list.Label(string.Format("({0}) Apparell worn deterioration damage", deteriorationSettings.damageIncreaseApparell));
                deteriorationSettings.damageIncreaseApparell = (int)list.Slider(deteriorationSettings.damageIncreaseApparell, 1f, 10f);
                list.CheckboxLabeled("Randomize damage done to apparell", ref deteriorationSettings.damageIncreaseRandomApparell,
                    string.Format("With this setting on, the damage done to apparell worn will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseApparell));
            }
            list.Gap();
            list.GapLine();
            list.CheckboxLabeled("Equipment Deteriorate", ref deteriorationSettings.deteriorateEquipment, string.Format("This mode ensures that pawn's held weapon detoriates with a {0}% chance per day", deteriorationSettings.detoriationEquipmentRate));
            if (deteriorationSettings.deteriorateEquipment) {
                float.TryParse(list.TextEntryLabeled("Daily equipment deterioration rate ", string.Format("{0:#0.00}", deteriorationSettings.detoriationEquipmentRate)), out deteriorationSettings.detoriationEquipmentRate);
                deteriorationSettings.detoriationEquipmentRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationEquipmentRate, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.detoriationEquipmentRate = deteriorationSettings.detoriationEquipmentRate > 100f ? 100f : deteriorationSettings.detoriationEquipmentRate < 0 ? 0f : deteriorationSettings.detoriationEquipmentRate;
                list.Label(string.Format("({0}) Equipment worn deterioration damage", deteriorationSettings.damageIncreaseEquipment));
                deteriorationSettings.damageIncreaseEquipment = (int)list.Slider(deteriorationSettings.damageIncreaseEquipment, 1f, 10f);
                list.CheckboxLabeled("Randomize damage done to equipment", ref deteriorationSettings.damageIncreaseRandomEquipment,
                    string.Format("With this setting on, the damage done to equipment worn will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseEquipment));
            }

            list.Gap();
            list.GapLine();

            list.CheckboxLabeled("Items Deteriorate", ref deteriorationSettings.deteriorateInventory, string.Format("This mode ensures that items carried by pawns detoriates with a {0}% chance per day", deteriorationSettings.detoriationInventoryRate));
            if (deteriorationSettings.deteriorateInventory) {
                float.TryParse(list.TextEntryLabeled("Daily item deterioration rate ", string.Format("{0:#0.00}", deteriorationSettings.detoriationInventoryRate)), out deteriorationSettings.detoriationInventoryRate);
                deteriorationSettings.detoriationInventoryRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationInventoryRate, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.detoriationInventoryRate = deteriorationSettings.detoriationInventoryRate > 100f ? 100f : deteriorationSettings.detoriationInventoryRate < 0 ? 0f : deteriorationSettings.detoriationInventoryRate;
                list.Label(string.Format("({0}) Items carried deterioration damage", deteriorationSettings.damageIncreaseItem));
                deteriorationSettings.damageIncreaseItem = (int)list.Slider(deteriorationSettings.damageIncreaseItem, 1f, 10f);
                list.CheckboxLabeled("Randomize damage done to items", ref deteriorationSettings.damageIncreaseRandomItem,
                    string.Format("With this setting on, the damage done to items carried will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseItem));
            }

            list.Gap();
            list.GapLine();

            list.CheckboxLabeled("Melee hit detoriates", ref deteriorationSettings.deteriorateMelee, string.Format("This mode ensures that weapons used in melee deteriorates with a {0}% chance", deteriorationSettings.detoriationMeleeUsedRate));
            if (deteriorationSettings.deteriorateMelee) {
                float.TryParse(list.TextEntryLabeled("Melee deterioration rate ", string.Format("{0:#0.00}", deteriorationSettings.detoriationMeleeUsedRate)), out deteriorationSettings.detoriationMeleeUsedRate);
                deteriorationSettings.detoriationMeleeUsedRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationMeleeUsedRate, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.detoriationMeleeUsedRate = deteriorationSettings.detoriationMeleeUsedRate > 100f ? 100f : deteriorationSettings.detoriationMeleeUsedRate < 0 ? 0f : deteriorationSettings.detoriationMeleeUsedRate;
                list.Label(string.Format("({0}) Melee weapons deterioration damage", deteriorationSettings.damageIncreaseMeleeWeapon));
                deteriorationSettings.damageIncreaseMeleeWeapon = (int)list.Slider(deteriorationSettings.damageIncreaseMeleeWeapon, 1f, 10f);
                list.CheckboxLabeled("Randomize damage done to melee weapons", ref deteriorationSettings.damageIncreaseRandomMeleeWeapon,
                    string.Format("With this setting on, the damage done to the melee weapon when used will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseMeleeWeapon));

            }

            list.Gap();
            list.GapLine();

            list.CheckboxLabeled("Shooting Detoriates", ref deteriorationSettings.deteriorateRanged, string.Format("This mode ensures that used ranged weapons deteriorates with a {0}% chance", deteriorationSettings.detoriationRangedUsedRate));
            if (deteriorationSettings.deteriorateRanged) {
                float.TryParse(list.TextEntryLabeled("Ranged deterioration rate ", string.Format("{0:#0.00}", deteriorationSettings.detoriationRangedUsedRate)), out deteriorationSettings.detoriationRangedUsedRate);
                deteriorationSettings.detoriationRangedUsedRate = Mathf.Round(list.Slider(deteriorationSettings.detoriationRangedUsedRate, 0f, 100f) * 100f) / 100f;
                deteriorationSettings.detoriationRangedUsedRate = deteriorationSettings.detoriationRangedUsedRate > 100f ? 100f : deteriorationSettings.detoriationRangedUsedRate < 0 ? 0f : deteriorationSettings.detoriationRangedUsedRate;
                list.Label(string.Format("({0}) Ranged weapons deterioration damage", deteriorationSettings.damageIncreaseRangedWeapon));
                deteriorationSettings.damageIncreaseRangedWeapon = (int)list.Slider(deteriorationSettings.damageIncreaseRangedWeapon, 1f, 10f);
                list.CheckboxLabeled("Randomize damage done to ranged weapons", ref deteriorationSettings.damageIncreaseRandomRangedWeapon,
                      string.Format("With this setting on, the damage done to the ranged weapon when firing will be randomized from 1 to {0}.", deteriorationSettings.damageIncreaseRangedWeapon));
                list.CheckboxLabeled("Bullet Matters", ref deteriorationSettings.bulletMatters, string.Format("This mode increases the deterioration chance for weapons that fire multiple bullets." +
                    "\n\nExample: You have a minigun that fires 24 rounds. " +
                    "Each round increases the chance for damage by {0}% to the weapon. " +
                    "{0} * 24 = " + deteriorationSettings.bulletMattersDamage * 24 + "% increased chance for deterioration. " +
                    "\n\nThus firing 24 bullets in a row gives a " + deteriorationSettings.detoriationRangedUsedRate * (1 + (SettingsHelper.LatestVersion.bulletMattersDamage * 24) / 100) + "% chance for deterioration instead of {0} with this mode on. ",
                        deteriorationSettings.bulletMattersDamage, deteriorationSettings.detoriationRangedUsedRate));
                if (deteriorationSettings.bulletMatters) {
                    float.TryParse(list.TextEntryLabeled("Bullet rate ", string.Format("{0:#0.00}", deteriorationSettings.bulletMattersDamage)), out deteriorationSettings.bulletMattersDamage);
                    deteriorationSettings.bulletMattersDamage = Mathf.Round(list.Slider(deteriorationSettings.bulletMattersDamage, 1f, 100f) * 100f) / 100f;
                    deteriorationSettings.bulletMattersDamage = deteriorationSettings.bulletMattersDamage > 100f ? 100f : deteriorationSettings.bulletMattersDamage < 0 ? 0f : deteriorationSettings.bulletMattersDamage;
                    list.Gap();
                }
                list.CheckboxLabeled("Jamming Matters", ref deteriorationSettings.jammingMatters, string.Format("This mode enables ranged weapon jamming depending on current durability. Do note that this option also opts npc's ranged weapons to jam at times regardless if 'NPC stuff deteriorates' option is enabled or not. However, this is not true for the 'Jamming damages' option." +
                    "\n\nExample: You have a broken pistol at 75% durability. " +
                    "Initial Calculation gives a 25% chance of jamming. " +
                    "However, the value in this slider changes the maximum possible chance to {0}%. " +
                    "This value is then accounted for with those 25%.\n\n" +
                    "There's a " + (((float)deteriorationSettings.jammingMattersPercentage / 100f) * (1f - (75f / 100f))) * 100f + "% chance of jamming given this example.",
                        deteriorationSettings.jammingMattersPercentage));
                if (deteriorationSettings.jammingMatters) {
                    float.TryParse(list.TextEntryLabeled("Jamming rate ", string.Format("{0:#0.00}", deteriorationSettings.jammingMattersPercentage)), out deteriorationSettings.jammingMattersPercentage);
                    deteriorationSettings.jammingMattersPercentage = Mathf.Round(list.Slider(deteriorationSettings.jammingMattersPercentage, 1f, 100f) * 100f) / 100f;
                    deteriorationSettings.jammingMattersPercentage = deteriorationSettings.jammingMattersPercentage > 100f ? 100f : deteriorationSettings.jammingMattersPercentage < 0 ? 0f : deteriorationSettings.jammingMattersPercentage;
                    list.CheckboxLabeled("Jamming Damages", ref deteriorationSettings.jammingMattersBreakable, string.Format("This option enables chance for weapon to take damage when jamming as per shooting deterioration calculation."));
                }
            }
            list.CheckboxLabeled("Excempt Minigun", ref deteriorationSettings.minigunExcemption, string.Format("This mode ensures that miniguns are not calculated", deteriorationSettings.minigunExcemption));
            list.Gap();
            list.GapLine();


            list.End();
            Widgets.EndScrollView();

            deteriorationSettings.Write();
        }
    }
}
