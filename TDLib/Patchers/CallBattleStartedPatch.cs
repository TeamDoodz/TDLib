using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;
using HarmonyLib;
using TDLib.Events;

namespace TDLib.Patchers {
	[HarmonyPatch(typeof(TurnManager))]
	[HarmonyPatch("StartGame",typeof(EncounterData))]
	static class CallBattleStartedPatch {
		static void Postfix(EncounterData encounterData) {
			EventsManager.CallBattleStarted(encounterData);
		}
	}
}
