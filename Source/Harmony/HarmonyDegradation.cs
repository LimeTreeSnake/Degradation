using Harmony;
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Sound;

namespace Degradation {
    [StaticConstructorOnStartup]
    internal static class HarmonyDegradation {
        static HarmonyDegradation() {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("rimworld.limetreesnake.degradation");
            harmonyInstance.Patch(AccessTools.Method(typeof(Pawn_ApparelTracker), "ApparelTrackerTickRare"), new HarmonyMethod(typeof(HarmonyDegradation).GetMethod("ApparelTrackerTickRare_PreFix")), null);
            harmonyInstance.Patch(AccessTools.Method(typeof(Verb_MeleeAttack), "TryCastShot"), null, new HarmonyMethod(typeof(HarmonyDegradation).GetMethod("TryCastShot_Melee_PostFix")));
            harmonyInstance.Patch(AccessTools.Method(typeof(Verb_LaunchProjectile), "WarmupComplete"), new HarmonyMethod(typeof(HarmonyDegradation).GetMethod("WarmupComplete_Ranged_PreFix")), new HarmonyMethod(typeof(HarmonyDegradation).GetMethod("WarmupComplete_Ranged_PostFix")));
        }

        public static bool ApparelTrackerTickRare_PreFix(Pawn_ApparelTracker __instance) {
            if (__instance.pawn.Spawned) {
                if (!__instance.pawn.IsColonist && SettingsHelper.LatestVersion.npcdegrade) {
                    return !SettingsHelper.LatestVersion.removeVanillaSettings;
                }
                int ticksGame = Find.TickManager.TicksGame;
                int wearoutTick = Traverse.Create(__instance).Field("lastApparelWearoutTick").GetValue<int>();
                if (wearoutTick < 0) {
                    if (SettingsHelper.LatestVersion.removeVanillaSettings) {
                        Traverse.Create(__instance).Field("lastApparelWearoutTick").SetValue(ticksGame);
                    }
                }
                if (ticksGame - wearoutTick >= 60000) {
                    //Apparell
                    if (SettingsHelper.LatestVersion.degradeApparell)
                        DailyDegrade(__instance.pawn.apparel.WornApparel,
                            __instance.pawn,
                            SettingsHelper.LatestVersion.degradationApparellRate,
                            SettingsHelper.LatestVersion.damageIncreaseApparell,
                            SettingsHelper.LatestVersion.damageIncreaseRandomApparell);
                    //Equipment
                    if (SettingsHelper.LatestVersion.degradeEquipment)
                        DailyDegrade(__instance.pawn.equipment.AllEquipmentListForReading,
                        __instance.pawn,
                        SettingsHelper.LatestVersion.degradationEquipmentRate,
                        SettingsHelper.LatestVersion.damageIncreaseEquipment,
                        SettingsHelper.LatestVersion.damageIncreaseRandomEquipment);
                    //Items
                    if (SettingsHelper.LatestVersion.degradeInventory)
                        DailyDegrade(__instance.pawn.inventory.innerContainer.InnerListForReading,
                        __instance.pawn,
                        SettingsHelper.LatestVersion.degradationInventoryRate,
                        SettingsHelper.LatestVersion.damageIncreaseItem,
                        SettingsHelper.LatestVersion.damageIncreaseRandomItem);

                    //If the vanilla degradation is off, make sure the lastApparelWearoutTick is updated.
                    if (SettingsHelper.LatestVersion.removeVanillaSettings) {
                        Traverse.Create(__instance).Field("lastApparelWearoutTick").SetValue(ticksGame);
                    }
                }
                return false;
            }
            return !SettingsHelper.LatestVersion.removeVanillaSettings;
        }

        public static void TryCastShot_Melee_PostFix(Verb_MeleeAttack __instance, bool __result) {
            if (!SettingsHelper.LatestVersion.npcdegrade) {
                if (!__instance.CasterPawn.IsColonistPlayerControlled) {
                    return;
                }
            }
            if (SettingsHelper.LatestVersion.degradeMelee && Utility.Eligable(__instance)) {
                Utility.Fire(__instance);
            }
        }

        [HarmonyPriority(150)]
        public static bool WarmupComplete_Ranged_PreFix(Verb __instance, ref bool __state) {
            __state = false;
            if (Utility.Eligable(__instance) && !__instance.IsMeleeAttack && SettingsHelper.LatestVersion.jammingMatters) {
                __state = Utility.JamCheck(__instance.EquipmentSource, __instance.CasterPawn, SettingsHelper.LatestVersion.jammingMattersPercentage);
            }
            return !__state;
        }
        public static void WarmupComplete_Ranged_PostFix(Verb __instance, bool __state) {
            if (!SettingsHelper.LatestVersion.npcdegrade) {
                if (!__instance.CasterPawn.IsColonistPlayerControlled) {
                    return;
                }
            }
            if (SettingsHelper.LatestVersion.degradeRanged && Utility.Eligable(__instance) && !__instance.IsMeleeAttack || !__state) {
                Utility.Fire(__instance);
            }
        }
        public static void DailyDegrade<T>(List<T> items, Pawn pawn, float degradeRate, float damageIncrease, bool useRandom) where T : Thing {
            for (int i = 0; i < items.Count; i++) {
                if (Utility.DegradeCheck(items[i], degradeRate / 100f) > 0) {
                    Utility.Degrade(items[i], pawn, damageIncrease, useRandom);
                }
            }
        }
    }
}