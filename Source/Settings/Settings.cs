using Verse;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;

namespace Degradation.Settings {
    internal class Settings : ModSettings {
        #region Fields
        private int awful = 20;
        private int poor = 15;
        private int normal = 10;
        private int good = 8;
        private int excellent = 6;
        private int masterwork = 4;
        private int legendary = 2;
        private int alert = 25;
        private bool jamming = false;
        private IEnumerable<ThingDef> Weapons = DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.IsWeapon);
        private Vector2 scrollPosition = Vector2.zero;
        private string Filter = "";

        #endregion Fields
        #region Properties
        public int Awful => awful;
        public int Poor => poor;
        public int Normal => normal;
        public int Good => good;
        public int Excellent => excellent;
        public int Masterwork => masterwork;
        public int Legendary => legendary;
        public int Alert => alert;
        public bool Jamming => jamming;
        public HashSet<string> Excluded;
        #endregion Properties
        #region Methods
        public Settings() {

        }
        public override void ExposeData() {
            base.ExposeData();
            Scribe_Values.Look(ref awful, "Awful", awful);
            Scribe_Values.Look(ref poor, "Poor", poor);
            Scribe_Values.Look(ref normal, "Normal", normal);
            Scribe_Values.Look(ref good, "Good", good);
            Scribe_Values.Look(ref excellent, "Excellent", excellent);
            Scribe_Values.Look(ref masterwork, "Masterwork", masterwork);
            Scribe_Values.Look(ref legendary, "Legendary", legendary);
            Scribe_Values.Look(ref jamming, "Jamming");
            Scribe_Values.Look(ref alert, "Alert");
            Scribe_Collections.Look(ref Excluded, "Excluded");
        }
        public void DoWindowContents(Rect inRect) {
            try {
                inRect.yMin += 20;
                inRect.yMax -= 20;
                Listing_Standard list = new Listing_Standard();
                Rect rect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
                Rect rect2 = new Rect(0f, 0f, inRect.width - 30f, inRect.height * 2 + 600);
                Widgets.BeginScrollView(rect, ref scrollPosition, rect2, true);
                list.Begin(rect2);
                list.CheckboxLabeled(Language.Language.Jamming, ref jamming);
                list.Label(Language.Language.Alert + " - " + Alert + "%");
                alert = (byte)Mathf.Round(list.Slider(Alert, 0, 100));
                list.GapLine(6);
                list.Label(Language.Language.Degradation);
                list.Label(Language.Language.Awful + " - " + Awful);
                awful = (byte)Mathf.Round(list.Slider(Awful, Poor, 100));
                list.Label(Language.Language.Poor + " - " + Poor);
                if (Poor > Awful)
                    awful = Poor;
                poor = (byte)Mathf.Round(list.Slider(Poor, Normal, 100));
                list.Label(Language.Language.Normal + " - " + Normal);
                if (Normal > Poor)
                    poor = Normal;
                normal = (byte)Mathf.Round(list.Slider(Normal, Good, 100));
                list.Label(Language.Language.Good + " - " + Good);
                if (Good > Normal)
                    normal = Good;
                good = (byte)Mathf.Round(list.Slider(Good, Excellent, 100));
                list.Label(Language.Language.Excellent + " - " + Excellent);
                if (Excellent > Good)
                    good = Excellent;
                excellent = (byte)Mathf.Round(list.Slider(Excellent, Masterwork, 100));
                list.Label(Language.Language.Masterwork + " - " + Masterwork);
                if (Masterwork > Excellent)
                    excellent = Masterwork;
                masterwork = (byte)Mathf.Round(list.Slider(Masterwork, Legendary, 100));
                list.Label(Language.Language.Legendary + " - " + Legendary);
                if (Legendary > Masterwork)
                    masterwork = Legendary;
                legendary = (byte)Mathf.Round(list.Slider(Legendary, 0, 100));
                ///Excluding
                list.GapLine(12);
                list.Label(Language.Language.Exclude);
                Filter = list.TextEntryLabeled(Language.Language.Filter, Filter, 1);
                Listing_Standard list2 = list.BeginSection(600);
                list2.ColumnWidth = (rect2.width - 50) / 4;
                foreach (ThingDef def in Weapons) {
                    if (string.IsNullOrEmpty(Filter) || def.label.ToUpper().Contains(Filter.ToUpper())) {
                        bool contains = Excluded.Contains(def.defName);
                        list2.CheckboxLabeled(def.label, ref contains);
                        if (contains == false && Excluded.Contains(def.defName)) {
                            Excluded.Remove(def.defName);
                        }
                        else if (contains == true && !Excluded.Contains(def.defName)) {
                            Excluded.Add(def.defName);
                        }
                    }
                }
                list.EndSection(list2);

                ///Stuff
                list.End();
                Widgets.EndScrollView();
                Write();
            }
            catch (Exception ex) {
                Log.Message(ex.Message);
            }
        }
        #endregion Methods
    }
    internal static class SettingsHelper {
        public static Settings LatestVersion;
    }
    public class Degradation : Mod {
        private Settings settings;
        public Degradation(ModContentPack content) : base(content) {
            settings = GetSettings<Settings>();
            SettingsHelper.LatestVersion = settings;
            if (SettingsHelper.LatestVersion.Excluded == null)
                SettingsHelper.LatestVersion.Excluded = new HashSet<string>();
        }
        public override string SettingsCategory() {
            return "Degradation";
        }
        public override void DoSettingsWindowContents(Rect inRect) {
            settings.DoWindowContents(inRect);
        }
    }
}
