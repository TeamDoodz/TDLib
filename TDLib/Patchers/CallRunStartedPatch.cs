using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;
using HarmonyLib;
using TDLib.Events;

namespace TDLib.Patchers {
	[HarmonyPatch(typeof(AscensionMenuScreens))]
	[HarmonyPatch("TransitionToGame")]
	static class CallRunStartedPatch {
		static void Postfix(bool newRun) {
			if(newRun) EventsManager.CallRunStarted();
		}
	}
}
