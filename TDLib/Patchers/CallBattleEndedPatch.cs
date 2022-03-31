using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;
using HarmonyLib;
using TDLib.Events;

namespace TDLib.Patchers {
    [HarmonyPatch(typeof(TurnManager))]
    [HarmonyPatch("CleanupPhase")]
    static class CallBattleEndedPatch {
        static void Postfix() {
            EventsManager.CallBattleEnded();
        }
    }
}
