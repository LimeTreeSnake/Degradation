using HarmonyLib;
using RimWorld;
using Verse;

namespace Degradation.Harmony {
    [StaticConstructorOnStartup]
    internal static class Harmony {
        static Harmony() {
            var harmony = new HarmonyLib.Harmony("limetreesnake.degradation");
            harmony.Patch(AccessTools.Method(typeof(Verb_LaunchProjectile), "WarmupComplete"),
                new HarmonyMethod(typeof(Harmony).GetMethod("TryCastShot_PreFix")),
                null);
            harmony.Patch(AccessTools.Method(typeof(Verb_LaunchProjectile), "TryCastShot"),
                null,
                new HarmonyMethod(typeof(Harmony).GetMethod("TryCastShot_PostFix")));
            harmony.Patch(AccessTools.Method(typeof(Verb_MeleeAttack), "TryCastShot"),
                new HarmonyMethod(typeof(Harmony).GetMethod("TryCastShot_PreFix")),
                new HarmonyMethod(typeof(Harmony).GetMethod("TryCastShot_PostFix")));
        }

        [HarmonyPriority(150)]
        public static bool TryCastShot_PreFix(Verb __instance) {
            if (__instance.EquipmentSource != null && __instance.EquipmentSource.def.IsRangedWeapon && !Settings.SettingsHelper.LatestVersion.Excluded.Contains(__instance.EquipmentSource.def.defName)) {
                if (Utility.Utility.JamCheck(__instance.EquipmentSource)) {
                    Utility.Utility.Degrade(__instance.EquipmentSource, __instance.CasterPawn);
                    return false;
                }
            }
            return true;
        }
        [HarmonyPriority(150)]
        public static void TryCastShot_PostFix(Verb __instance) {
            if (__instance.EquipmentSource != null && __instance.EquipmentSource.def.IsWeapon && !Settings.SettingsHelper.LatestVersion.Excluded.Contains(__instance.EquipmentSource.def.defName)) {
                if (Utility.Utility.QualityCheck(__instance.EquipmentSource)) {
                    Utility.Utility.Degrade(__instance.EquipmentSource, __instance.CasterPawn);
                }
            }
        }
    }

}
