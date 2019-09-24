using Verse;
using UnityEngine;

namespace Degradation {
    internal class DegradationSettings : ModSettings {

        #region Fields
        private static readonly bool base_removeVanillaSettings = true;
        private static readonly bool base_npcdegrade = false;

        private static readonly bool base_qualityMatters = false;
        private static readonly float base_awful = 3f;
        private static readonly float base_poor = 2f;
        private static readonly float base_normal = 1f;
        private static readonly float base_good = 0.9f;
        private static readonly float base_excellent = 0.7f;
        private static readonly float base_masterwork = 0.5f;
        private static readonly float base_legendary = 0.3f;

        private static readonly bool base_degradeApparell = true;
        private static readonly float base_degradationApparellRate = 25f;
        private static readonly float base_damageIncreaseApparell = 1;
        private static readonly bool base_damageIncreaseRandomApparell = false;

        private static readonly bool base_degradeEquipment = true;
        private static readonly float base_degradationEquipmentRate = 25f;
        private static readonly float base_damageIncreaseEquipment = 1;
        private static readonly bool base_damageIncreaseRandomEquipment = false;

        private static readonly bool base_degradeInventory = true;
        private static readonly float base_degradationInventoryRate = 25f;
        private static readonly float base_damageIncreaseItem = 1;
        private static readonly bool base_damageIncreaseRandomItem = false;

        private static readonly bool base_degradeMelee = true;
        private static readonly float base_degradationMeleeUsedRate = 15f;
        private static readonly float base_damageIncreaseMeleeWeapon = 1;
        private static readonly bool base_damageIncreaseRandomMeleeWeapon = false;

        private static readonly bool base_degradeRanged = true;
        private static readonly float base_degradationRangedUsedRate = 5f;
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
        public bool npcdegrade = base_npcdegrade;

        public bool qualityMatters = base_qualityMatters;
        public float awful = base_awful;
        public float poor = base_poor;
        public float normal = base_normal;
        public float good = base_good;
        public float excellent = base_excellent;
        public float masterwork = base_masterwork;
        public float legendary = base_legendary;

        public bool degradeApparell = base_degradeApparell;
        public float degradationApparellRate = base_degradationApparellRate;
        public float damageIncreaseApparell = base_damageIncreaseApparell;
        public bool damageIncreaseRandomApparell = base_damageIncreaseRandomApparell;

        public bool degradeEquipment = base_degradeEquipment;
        public float degradationEquipmentRate = base_degradationEquipmentRate;
        public float damageIncreaseEquipment = base_damageIncreaseEquipment;
        public bool damageIncreaseRandomEquipment = base_damageIncreaseRandomEquipment;

        public bool degradeInventory = base_degradeInventory;
        public float degradationInventoryRate = base_degradationInventoryRate;
        public float damageIncreaseItem = base_damageIncreaseItem;
        public bool damageIncreaseRandomItem = base_damageIncreaseRandomItem;

        public bool degradeMelee = base_degradeMelee;
        public float degradationMeleeUsedRate = base_degradationMeleeUsedRate;
        public float damageIncreaseMeleeWeapon = base_damageIncreaseMeleeWeapon;
        public bool damageIncreaseRandomMeleeWeapon = base_damageIncreaseRandomMeleeWeapon;

        public bool degradeRanged = base_degradeRanged;
        public float degradationRangedUsedRate = base_degradationRangedUsedRate;
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
            Scribe_Values.Look(ref npcdegrade, "NPCdegrade", base_npcdegrade);

            Scribe_Values.Look(ref qualityMatters, "QualityMatters", base_qualityMatters);
            Scribe_Values.Look(ref awful, "Awful", base_awful);
            Scribe_Values.Look(ref poor, "Poor", base_poor);
            Scribe_Values.Look(ref normal, "Normal", base_normal);
            Scribe_Values.Look(ref good, "Good", base_good);
            Scribe_Values.Look(ref excellent, "Excellent", base_excellent);
            Scribe_Values.Look(ref masterwork, "Masterwork", base_masterwork);
            Scribe_Values.Look(ref legendary, "Legendary", base_legendary);

            Scribe_Values.Look(ref degradeApparell, "degradeApparell", base_degradeApparell);
            Scribe_Values.Look(ref degradationApparellRate, "degradationApparellRate", base_degradationApparellRate);
            Scribe_Values.Look(ref damageIncreaseApparell, "DamageIncreaseApparell", base_damageIncreaseApparell);
            Scribe_Values.Look(ref damageIncreaseRandomApparell, "DamageIncreaseRandomApparell", base_damageIncreaseRandomApparell);

            Scribe_Values.Look(ref degradeEquipment, "degradeEquipment", base_degradeEquipment);
            Scribe_Values.Look(ref degradationEquipmentRate, "degradationEquipmentRate", base_degradationEquipmentRate);
            Scribe_Values.Look(ref damageIncreaseEquipment, "DamageIncreaseEquipment", base_damageIncreaseEquipment);
            Scribe_Values.Look(ref damageIncreaseRandomEquipment, "DamageIncreaseRandomEquipment", base_damageIncreaseRandomEquipment);

            Scribe_Values.Look(ref degradeInventory, "degradeInventory", base_degradeInventory);
            Scribe_Values.Look(ref degradationInventoryRate, "degradationInventoryRate", base_degradationInventoryRate);
            Scribe_Values.Look(ref damageIncreaseItem, "DamageIncreaseItem", base_damageIncreaseItem);
            Scribe_Values.Look(ref damageIncreaseRandomItem, "DamageIncreaseRandomItem", base_damageIncreaseRandomItem);

            Scribe_Values.Look(ref degradeMelee, "degradeMelee", base_degradeMelee);
            Scribe_Values.Look(ref degradationMeleeUsedRate, "degradationMeleeUsedRate", base_degradationMeleeUsedRate);
            Scribe_Values.Look(ref damageIncreaseMeleeWeapon, "DamageIncreaseMeleeWeapon", base_damageIncreaseMeleeWeapon);
            Scribe_Values.Look(ref damageIncreaseRandomMeleeWeapon, "DamageIncreaseRandomMeleeWeapon", base_damageIncreaseRandomMeleeWeapon);

            Scribe_Values.Look(ref degradeRanged, "degradeRanged", base_degradeRanged);
            Scribe_Values.Look(ref degradationRangedUsedRate, "degradationRangedUsedRate", base_degradationRangedUsedRate);
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
            npcdegrade = base_npcdegrade;

            qualityMatters = base_qualityMatters;
            awful = base_awful;
            poor = base_poor;
            normal = base_normal;
            excellent = base_excellent;
            good = base_good;
            masterwork = base_masterwork;
            legendary = base_legendary;

            degradeApparell = base_degradeApparell;
            degradationApparellRate = base_degradationApparellRate;
            damageIncreaseApparell = base_damageIncreaseApparell;
            damageIncreaseRandomApparell = base_damageIncreaseRandomApparell;

            degradeEquipment = base_degradeEquipment;
            degradationEquipmentRate = base_degradationEquipmentRate;
            damageIncreaseEquipment = base_damageIncreaseEquipment;
            damageIncreaseRandomEquipment = base_damageIncreaseRandomEquipment;

            degradeInventory = base_degradeInventory;
            degradationInventoryRate = base_degradationInventoryRate;
            damageIncreaseItem = base_damageIncreaseItem;
            damageIncreaseRandomItem = base_damageIncreaseRandomItem;

            degradeMelee = base_degradeMelee;
            degradationMeleeUsedRate = base_degradationMeleeUsedRate;
            damageIncreaseMeleeWeapon = base_damageIncreaseMeleeWeapon;
            damageIncreaseRandomMeleeWeapon = base_damageIncreaseRandomMeleeWeapon;

            degradeRanged = base_degradeRanged;
            degradationRangedUsedRate = base_degradationRangedUsedRate;
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
        public static DegradationSettings LatestVersion;

        public static void Reset() {
            LatestVersion.Reset();
        }
    }

    public class ModMain : Mod {
        private DegradationSettings degradationSettings;
        public ModMain(ModContentPack content) : base(content) {
            degradationSettings = GetSettings<DegradationSettings>();
            SettingsHelper.LatestVersion = degradationSettings;
        }

        public override string SettingsCategory() {
            return "Degradation";
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
                degradationSettings.Reset();
            };
            list.CheckboxLabeled("Remove vanilla degradation", ref degradationSettings.removeVanillaSettings, "Apparrel on pawns in vanilla Rimworld have a 40% chance of losing 1 durability each day. Check this box if you want this feature removed. If you decide to have this option off, then there is a chance to have multiple degradations per day.");
            list.CheckboxLabeled("NPC stuff degrades", ref degradationSettings.npcdegrade, string.Format("With this option on, NPC's equipment will degrade as well."));
            list.CheckboxLabeled("Quality Matters", ref degradationSettings.qualityMatters, string.Format("This mode ensures that your items will have their chance at taking damage depend on the quality of said item if applicable."));
            if (degradationSettings.qualityMatters) {
                list.Label(string.Format("A lower value means less chance for items taking degradation damage."));

                float.TryParse(list.TextEntryLabeled("Awful ", string.Format("{0:#0.00}", degradationSettings.awful)), out degradationSettings.awful);
                degradationSettings.awful = Mathf.Round(list.Slider(degradationSettings.awful, 0f, 100f) * 100f) / 100f;
                degradationSettings.awful = degradationSettings.awful > 100f ? 100f : degradationSettings.awful < 0f ? 0f : degradationSettings.awful;

                float.TryParse(list.TextEntryLabeled("Poor ", string.Format("{0:#0.00}", degradationSettings.poor)), out degradationSettings.poor);
                degradationSettings.poor = Mathf.Round(list.Slider(degradationSettings.poor, 0f, 100f) * 100f) / 100f;
                degradationSettings.poor = degradationSettings.poor > 100f ? 100f : degradationSettings.poor < 0f ? 0f : degradationSettings.poor;

                float.TryParse(list.TextEntryLabeled("Normal ", string.Format("{0:#0.00}", degradationSettings.normal)), out degradationSettings.normal);
                degradationSettings.normal = Mathf.Round(list.Slider(degradationSettings.normal, 0f, 100f) * 100f) / 100f;
                degradationSettings.normal = degradationSettings.normal > 100f ? 100f : degradationSettings.normal < 0f ? 0f : degradationSettings.normal;

                float.TryParse(list.TextEntryLabeled("Good ", string.Format("{0:#0.00}", degradationSettings.good)), out degradationSettings.good);
                degradationSettings.good = Mathf.Round(list.Slider(degradationSettings.good, 0f, 100f) * 100f) / 100f;
                degradationSettings.good = degradationSettings.good > 100f ? 100f : degradationSettings.good < 0f ? 0f : degradationSettings.good;

                float.TryParse(list.TextEntryLabeled("Excellent ", string.Format("{0:#0.00}", degradationSettings.excellent)), out degradationSettings.excellent);
                degradationSettings.excellent = Mathf.Round(list.Slider(degradationSettings.excellent, 0f, 100f) * 100f) / 100f;
                degradationSettings.excellent = degradationSettings.excellent > 100f ? 100f : degradationSettings.excellent < 0f ? 0f : degradationSettings.excellent;

                float.TryParse(list.TextEntryLabeled("Masterwork ", string.Format("{0:#0.00}", degradationSettings.masterwork)), out degradationSettings.masterwork);
                degradationSettings.masterwork = Mathf.Round(list.Slider(degradationSettings.masterwork, 0f, 100f) * 100f) / 100f;
                degradationSettings.masterwork = degradationSettings.masterwork > 100f ? 100f : degradationSettings.masterwork < 0f ? 0f : degradationSettings.masterwork;

                float.TryParse(list.TextEntryLabeled("Legendary ", string.Format("{0:#0.00}", degradationSettings.legendary)), out degradationSettings.legendary);
                degradationSettings.legendary = Mathf.Round(list.Slider(degradationSettings.legendary, 0f, 100f) * 100f) / 100f;
                degradationSettings.legendary = degradationSettings.legendary > 100f ? 100f : degradationSettings.legendary < 0f ? 0f : degradationSettings.legendary;

                list.Gap();
            }
            list.GapLine();
            list.Gap();
            list.CheckboxLabeled("Apparell degrade", ref degradationSettings.degradeApparell, string.Format("This mode ensures that apparell worn by pawns detoriates with a {0}% chance per day", degradationSettings.degradationApparellRate));
            if (degradationSettings.degradeApparell) {
                float.TryParse(list.TextEntryLabeled("Daily apparell degradation rate ", string.Format("{0:#0.00}", degradationSettings.degradationApparellRate)), out degradationSettings.degradationApparellRate);
                degradationSettings.degradationApparellRate = Mathf.Round(list.Slider(degradationSettings.degradationApparellRate, 0f, 100f) * 100f) / 100f;
                degradationSettings.degradationApparellRate = degradationSettings.degradationApparellRate > 100f ? 100f : degradationSettings.degradationApparellRate < 0 ? 0f : degradationSettings.degradationApparellRate;
                list.Label(string.Format("({0}) Apparell worn degradation damage", degradationSettings.damageIncreaseApparell));
                degradationSettings.damageIncreaseApparell = (int)list.Slider(degradationSettings.damageIncreaseApparell, 1f, 10f);
                list.CheckboxLabeled("Randomize damage done to apparell", ref degradationSettings.damageIncreaseRandomApparell,
                    string.Format("With this setting on, the damage done to apparell worn will be randomized from 1 to {0}.", degradationSettings.damageIncreaseApparell));
            }
            list.Gap();
            list.GapLine();
            list.CheckboxLabeled("Equipment degrade", ref degradationSettings.degradeEquipment, string.Format("This mode ensures that pawn's held weapon detoriates with a {0}% chance per day", degradationSettings.degradationEquipmentRate));
            if (degradationSettings.degradeEquipment) {
                float.TryParse(list.TextEntryLabeled("Daily equipment degradation rate ", string.Format("{0:#0.00}", degradationSettings.degradationEquipmentRate)), out degradationSettings.degradationEquipmentRate);
                degradationSettings.degradationEquipmentRate = Mathf.Round(list.Slider(degradationSettings.degradationEquipmentRate, 0f, 100f) * 100f) / 100f;
                degradationSettings.degradationEquipmentRate = degradationSettings.degradationEquipmentRate > 100f ? 100f : degradationSettings.degradationEquipmentRate < 0 ? 0f : degradationSettings.degradationEquipmentRate;
                list.Label(string.Format("({0}) Equipment worn degradation damage", degradationSettings.damageIncreaseEquipment));
                degradationSettings.damageIncreaseEquipment = (int)list.Slider(degradationSettings.damageIncreaseEquipment, 1f, 10f);
                list.CheckboxLabeled("Randomize damage done to equipment", ref degradationSettings.damageIncreaseRandomEquipment,
                    string.Format("With this setting on, the damage done to equipment worn will be randomized from 1 to {0}.", degradationSettings.damageIncreaseEquipment));
            }

            list.Gap();
            list.GapLine();

            list.CheckboxLabeled("Items degrade", ref degradationSettings.degradeInventory, string.Format("This mode ensures that items carried by pawns detoriates with a {0}% chance per day", degradationSettings.degradationInventoryRate));
            if (degradationSettings.degradeInventory) {
                float.TryParse(list.TextEntryLabeled("Daily item degradation rate ", string.Format("{0:#0.00}", degradationSettings.degradationInventoryRate)), out degradationSettings.degradationInventoryRate);
                degradationSettings.degradationInventoryRate = Mathf.Round(list.Slider(degradationSettings.degradationInventoryRate, 0f, 100f) * 100f) / 100f;
                degradationSettings.degradationInventoryRate = degradationSettings.degradationInventoryRate > 100f ? 100f : degradationSettings.degradationInventoryRate < 0 ? 0f : degradationSettings.degradationInventoryRate;
                list.Label(string.Format("({0}) Items carried degradation damage", degradationSettings.damageIncreaseItem));
                degradationSettings.damageIncreaseItem = (int)list.Slider(degradationSettings.damageIncreaseItem, 1f, 10f);
                list.CheckboxLabeled("Randomize damage done to items", ref degradationSettings.damageIncreaseRandomItem,
                    string.Format("With this setting on, the damage done to items carried will be randomized from 1 to {0}.", degradationSettings.damageIncreaseItem));
            }

            list.Gap();
            list.GapLine();

            list.CheckboxLabeled("Melee hit detoriates", ref degradationSettings.degradeMelee, string.Format("This mode ensures that weapons used in melee degrades with a {0}% chance", degradationSettings.degradationMeleeUsedRate));
            if (degradationSettings.degradeMelee) {
                float.TryParse(list.TextEntryLabeled("Melee degradation rate ", string.Format("{0:#0.00}", degradationSettings.degradationMeleeUsedRate)), out degradationSettings.degradationMeleeUsedRate);
                degradationSettings.degradationMeleeUsedRate = Mathf.Round(list.Slider(degradationSettings.degradationMeleeUsedRate, 0f, 100f) * 100f) / 100f;
                degradationSettings.degradationMeleeUsedRate = degradationSettings.degradationMeleeUsedRate > 100f ? 100f : degradationSettings.degradationMeleeUsedRate < 0 ? 0f : degradationSettings.degradationMeleeUsedRate;
                list.Label(string.Format("({0}) Melee weapons degradation damage", degradationSettings.damageIncreaseMeleeWeapon));
                degradationSettings.damageIncreaseMeleeWeapon = (int)list.Slider(degradationSettings.damageIncreaseMeleeWeapon, 1f, 10f);
                list.CheckboxLabeled("Randomize damage done to melee weapons", ref degradationSettings.damageIncreaseRandomMeleeWeapon,
                    string.Format("With this setting on, the damage done to the melee weapon when used will be randomized from 1 to {0}.", degradationSettings.damageIncreaseMeleeWeapon));

            }

            list.Gap();
            list.GapLine();

            list.CheckboxLabeled("Shooting Detoriates", ref degradationSettings.degradeRanged, string.Format("This mode ensures that used ranged weapons degrades with a {0}% chance", degradationSettings.degradationRangedUsedRate));
            if (degradationSettings.degradeRanged) {
                float.TryParse(list.TextEntryLabeled("Ranged degradation rate ", string.Format("{0:#0.00}", degradationSettings.degradationRangedUsedRate)), out degradationSettings.degradationRangedUsedRate);
                degradationSettings.degradationRangedUsedRate = Mathf.Round(list.Slider(degradationSettings.degradationRangedUsedRate, 0f, 100f) * 100f) / 100f;
                degradationSettings.degradationRangedUsedRate = degradationSettings.degradationRangedUsedRate > 100f ? 100f : degradationSettings.degradationRangedUsedRate < 0 ? 0f : degradationSettings.degradationRangedUsedRate;
                list.Label(string.Format("({0}) Ranged weapons degradation damage", degradationSettings.damageIncreaseRangedWeapon));
                degradationSettings.damageIncreaseRangedWeapon = (int)list.Slider(degradationSettings.damageIncreaseRangedWeapon, 1f, 10f);
                list.CheckboxLabeled("Randomize damage done to ranged weapons", ref degradationSettings.damageIncreaseRandomRangedWeapon,
                      string.Format("With this setting on, the damage done to the ranged weapon when firing will be randomized from 1 to {0}.", degradationSettings.damageIncreaseRangedWeapon));
                list.CheckboxLabeled("Bullet Matters", ref degradationSettings.bulletMatters, string.Format("This mode increases the degradation chance for weapons that fire multiple bullets." +
                    "\n\nExample: You have a minigun that fires 24 rounds. " +
                    "Each round increases the chance for damage by {0}% to the weapon. " +
                    "{0} * 24 = " + degradationSettings.bulletMattersDamage * 24 + "% increased chance for degradation. " +
                    "\n\nThus firing 24 bullets in a row gives a " + degradationSettings.degradationRangedUsedRate * (1 + (SettingsHelper.LatestVersion.bulletMattersDamage * 24) / 100) + "% chance for degradation instead of {0} with this mode on. ",
                        degradationSettings.bulletMattersDamage, degradationSettings.degradationRangedUsedRate));
                if (degradationSettings.bulletMatters) {
                    float.TryParse(list.TextEntryLabeled("Bullet rate ", string.Format("{0:#0.00}", degradationSettings.bulletMattersDamage)), out degradationSettings.bulletMattersDamage);
                    degradationSettings.bulletMattersDamage = Mathf.Round(list.Slider(degradationSettings.bulletMattersDamage, 1f, 100f) * 100f) / 100f;
                    degradationSettings.bulletMattersDamage = degradationSettings.bulletMattersDamage > 100f ? 100f : degradationSettings.bulletMattersDamage < 0 ? 0f : degradationSettings.bulletMattersDamage;
                    list.Gap();
                }
                list.CheckboxLabeled("Jamming Matters", ref degradationSettings.jammingMatters, string.Format("This mode enables ranged weapon jamming depending on current durability. Do note that this option also opts npc's ranged weapons to jam at times regardless if 'NPC stuff degrades' option is enabled or not. However, this is not true for the 'Jamming damages' option." +
                    "\n\nExample: You have a broken pistol at 75% durability. " +
                    "Initial Calculation gives a 25% chance of jamming. " +
                    "However, the value in this slider changes the maximum possible chance to {0}%. " +
                    "This value is then accounted for with those 25%.\n\n" +
                    "There's a " + (((float)degradationSettings.jammingMattersPercentage / 100f) * (1f - (75f / 100f))) * 100f + "% chance of jamming given this example.",
                        degradationSettings.jammingMattersPercentage));
                if (degradationSettings.jammingMatters) {
                    float.TryParse(list.TextEntryLabeled("Jamming rate ", string.Format("{0:#0.00}", degradationSettings.jammingMattersPercentage)), out degradationSettings.jammingMattersPercentage);
                    degradationSettings.jammingMattersPercentage = Mathf.Round(list.Slider(degradationSettings.jammingMattersPercentage, 1f, 100f) * 100f) / 100f;
                    degradationSettings.jammingMattersPercentage = degradationSettings.jammingMattersPercentage > 100f ? 100f : degradationSettings.jammingMattersPercentage < 0 ? 0f : degradationSettings.jammingMattersPercentage;
                    list.CheckboxLabeled("Jamming Damages", ref degradationSettings.jammingMattersBreakable, string.Format("This option enables chance for weapon to take damage when jamming as per shooting degradation calculation."));
                }
            }
            list.CheckboxLabeled("Excempt Minigun", ref degradationSettings.minigunExcemption, string.Format("This mode ensures that miniguns are not calculated", degradationSettings.minigunExcemption));
            list.Gap();
            list.GapLine();


            list.End();
            Widgets.EndScrollView();

            degradationSettings.Write();
        }
    }
}
