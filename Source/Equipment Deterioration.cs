using Harmony;
using RimWorld;
using Verse;

namespace Equipment_Deterioration
{
    [StaticConstructorOnStartup]
    internal static class HarmonyEquipmentDeterioration
    {
        static HarmonyEquipmentDeterioration()
        {

            HarmonyInstance harmonyInstance = HarmonyInstance.Create("rimworld.limetreesnake.equipmentdeterioration");
            harmonyInstance.Patch(AccessTools.Method(typeof(Pawn_ApparelTracker), "ApparelTrackerTickRare"), new HarmonyMethod(typeof(HarmonyEquipmentDeterioration).GetMethod("ApparelTrackerTickRare_PreFix")), null);

            Log.Message("Initialized");
        }
        
        public static bool ApparelTrackerTickRare_PreFix(Pawn_ApparelTracker __instance)
        {
            int wearoutTick = Traverse.Create(__instance).Field("lastApparelWearoutTick").GetValue<int>();
            int ticksGame = Find.TickManager.TicksGame;
            if (ticksGame - wearoutTick >= 60000)
            {
                
                for (int i = 0; i < __instance.pawn.equipment.AllEquipmentListForReading.Count; i++)
                {
                    int num = GenMath.RoundRandom(0.25f);
                    if (num > 0)
                    {
                        __instance.pawn.equipment.AllEquipmentListForReading[0].TakeDamage(new DamageInfo(DamageDefOf.Deterioration, (float)num));
                    }
                    if (__instance.pawn.equipment.AllEquipmentListForReading[0].Destroyed && PawnUtility.ShouldSendNotificationAbout(__instance.pawn) && !__instance.pawn.Dead)
                    {
                        string str = "MessageWornApparelDeterioratedAway".Translate(GenLabel.ThingLabel(__instance.pawn.equipment.AllEquipmentListForReading[0].def, __instance.pawn.equipment.AllEquipmentListForReading[0].Stuff), __instance.pawn);
                        str = str.CapitalizeFirst();
                        Messages.Message(str, __instance.pawn, MessageTypeDefOf.NegativeEvent);
                    }
                }
            }
            return true;
        }
    }
}   