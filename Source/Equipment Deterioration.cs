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
            harmonyInstance.Patch(AccessTools.Method(typeof(Verb_Shoot), "TryCastShot"), null, new HarmonyMethod(typeof(HarmonyEquipmentDeterioration).GetMethod("TryCastShot_Ranged_PostFix")), null);
            harmonyInstance.Patch(AccessTools.Method(typeof(Verb_MeleeAttack), "TryCastShot"), null, new HarmonyMethod(typeof(HarmonyEquipmentDeterioration).GetMethod("TryCastShot_Melee_PostFix")), null);


        }

        public static bool ApparelTrackerTickRare_PreFix(Pawn_ApparelTracker __instance)
        {
            int wearoutTick = Traverse.Create(__instance).Field("lastApparelWearoutTick").GetValue<int>();
            int ticksGame = Find.TickManager.TicksGame;
            if (ticksGame - wearoutTick >= 60000)
            {

                for (int i = 0; i < __instance.pawn.equipment.AllEquipmentListForReading.Count; i++)
                {
                    int num = GenMath.RoundRandom(SettingsHelper.latest.detoriationDailyRate);
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

        //public static void WarmupComplete_PostFix(Verb __instance)
        //{
        //    int num = GenMath.RoundRandom(SettingsHelper.latest.detoriationUsedRate);
        //    if (num > 0)
        //    {
        //        __instance.CasterPawn.equipment.AllEquipmentListForReading[0].TakeDamage(new DamageInfo(DamageDefOf.Deterioration, (float)num));
        //    }
        //    if (__instance.CasterPawn.equipment.AllEquipmentListForReading[0].Destroyed && PawnUtility.ShouldSendNotificationAbout(__instance.CasterPawn) && !__instance.CasterPawn.Dead)
        //    {
        //        string str = "MessageWornApparelDeterioratedAway".Translate(GenLabel.ThingLabel(__instance.CasterPawn.equipment.AllEquipmentListForReading[0].def, __instance.CasterPawn.equipment.AllEquipmentListForReading[0].Stuff), __instance.CasterPawn);
        //        str = str.CapitalizeFirst();
        //        Messages.Message(str, __instance.CasterPawn, MessageTypeDefOf.NegativeEvent);
        //    }
        //}

        public static void TryCastShot_Melee_PostFix(Verb_MeleeAttack __instance, bool __result)
        {
            if (!__instance.CasterPawn.AnimalOrWildMan() && __instance.CasterPawn.equipment.Primary != null)
            {
                if (!__result)
                    return;
                int num = GenMath.RoundRandom(SettingsHelper.latest.detoriationMeleeUsedRate);
                if (num > 0)
                {
                    __instance.CasterPawn.equipment.Primary.TakeDamage(new DamageInfo(DamageDefOf.Deterioration, (float)num));
                }
                if (__instance.CasterPawn.equipment.Primary.Destroyed && PawnUtility.ShouldSendNotificationAbout(__instance.CasterPawn) && !__instance.CasterPawn.Dead)
                {
                    string str = "MessageWornApparelDeterioratedAway".Translate(GenLabel.ThingLabel(__instance.CasterPawn.equipment.Primary.def, __instance.CasterPawn.equipment.Primary.Stuff), __instance.CasterPawn);
                    str = str.CapitalizeFirst();
                    Messages.Message(str, __instance.CasterPawn, MessageTypeDefOf.NegativeEvent);
                }
            }
        }
        public static void TryCastShot_Ranged_PostFix(Verb_Shoot __instance)
        {
            if (!__instance.CasterPawn.AnimalOrWildMan() && __instance.CasterPawn.equipment.Primary != null)
            {
                int num = GenMath.RoundRandom(SettingsHelper.latest.detoriationRangedUsedRate);
                if (num > 0)
                {
                    __instance.CasterPawn.equipment.Primary.TakeDamage(new DamageInfo(DamageDefOf.Deterioration, (float)num));
                }
                if (__instance.CasterPawn.equipment.Primary.Destroyed && PawnUtility.ShouldSendNotificationAbout(__instance.CasterPawn) && !__instance.CasterPawn.Dead)
                {
                    string str = "MessageWornApparelDeterioratedAway".Translate(GenLabel.ThingLabel(__instance.CasterPawn.equipment.Primary.def, __instance.CasterPawn.equipment.Primary.Stuff), __instance.CasterPawn);
                    str = str.CapitalizeFirst();
                    Messages.Message(str, __instance.CasterPawn, MessageTypeDefOf.NegativeEvent);
                }
            }
        }
    }




}