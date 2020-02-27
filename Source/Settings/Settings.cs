using Verse;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;

namespace Degradation.Settings {
    internal class Settings : ModSettings {
        #region Fields
        private static readonly int awful = 20;
        private static readonly int poor = 15;
        private static readonly int normal = 10;
        private static readonly int good = 8;
        private static readonly int excellent = 6;
        private static readonly int masterwork = 4;
        private static readonly int legendary = 2;
        private static readonly int alert = 25;
        private static readonly IEnumerable<ThingDef> Weapons = DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.IsWeapon);
        
        #endregion Fields
        #region Properties
        public Vector2 scrollPosition = Vector2.zero;
        public int Awful = awful;
        public int Poor = poor;
        public int Normal = normal;
        public int Good = good;
        public int Excellent = excellent;
        public int Masterwork = masterwork;
        public int Legendary = legendary;
        public int Alert = alert;
        public bool Jamming;
        public HashSet<string> Excluded;
        private string Filter = "";
        #endregion Properties
        #region Methods
        public Settings() {

        }
        public override void ExposeData() {
            base.ExposeData();
            Scribe_Values.Look(ref Awful, "Awful", awful);
            Scribe_Values.Look(ref Poor, "Poor", poor);
            Scribe_Values.Look(ref Normal, "Normal", normal);
            Scribe_Values.Look(ref Good, "Good", good);
            Scribe_Values.Look(ref Excellent, "Excellent", excellent);
            Scribe_Values.Look(ref Masterwork, "Masterwork", masterwork);
            Scribe_Values.Look(ref Legendary, "Legendary", legendary);
            Scribe_Values.Look(ref Jamming, "Jamming");
            Scribe_Values.Look(ref Alert, "Alert");
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
                list.CheckboxLabeled(Language.Language.Jamming, ref Jamming);
                list.Label(Language.Language.Alert + " - " + Alert + "%");
                Alert = (byte)Mathf.Round(list.Slider(Alert, 0, 100));
                list.GapLine(6);
                list.Label(Language.Language.Degradation);
                list.Label(Language.Language.Awful + " - " + Awful);
                Awful = (byte)Mathf.Round(list.Slider(Awful, Poor, 100));
                list.Label(Language.Language.Poor + " - " + Poor);
                if (Poor > Awful)
                    Awful = Poor;
                Poor = (byte)Mathf.Round(list.Slider(Poor, Normal, 100));
                list.Label(Language.Language.Normal + " - " + Normal);
                if (Normal > Poor)
                    Poor = Normal;
                Normal = (byte)Mathf.Round(list.Slider(Normal, Good, 100));
                list.Label(Language.Language.Good + " - " + Good);
                if (Good > Normal)
                    Normal = Good;
                Good = (byte)Mathf.Round(list.Slider(Good, Excellent, 100));
                list.Label(Language.Language.Excellent + " - " + Excellent);
                if (Excellent > Good)
                    Good = Excellent;
                Excellent = (byte)Mathf.Round(list.Slider(Excellent, Masterwork, 100));
                list.Label(Language.Language.Masterwork + " - " + Masterwork);
                if (Masterwork > Excellent)
                    Excellent = Masterwork;
                Masterwork = (byte)Mathf.Round(list.Slider(Masterwork, Legendary, 100));
                list.Label(Language.Language.Legendary + " - " + Legendary);
                if (Legendary > Masterwork)
                    Masterwork = Legendary;
                Legendary = (byte)Mathf.Round(list.Slider(Legendary, 0, 100));
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
