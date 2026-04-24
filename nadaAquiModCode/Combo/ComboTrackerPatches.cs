using HarmonyLib;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Hooks;

namespace nadaAquiMod.nadaAquiModCode.Combo;

[HarmonyPatch(typeof(Hook))]
internal static class ComboTrackerPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Hook.AfterCardPlayed))]
    private static void AfterCardPlayed_Prefix(CardPlay cardPlay)
    {
        ComboTracker.RecordPlay(cardPlay.Card);
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Hook.AfterSideTurnStart))]
    private static void AfterSideTurnStart_Postfix(CombatSide side)
    {
        if (side == CombatSide.Player)
            ComboTracker.Clear();
    }
}