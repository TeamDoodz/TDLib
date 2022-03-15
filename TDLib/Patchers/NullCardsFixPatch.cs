using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;
using HarmonyLib;
using TDLib.Attributes;

namespace TDLib.Patchers {
	/// <summary>
	/// Temporary fix/debug for an API bug that calls Clone on a null card
	/// </summary>
	[HarmonyPatch(typeof(CardLoader))]
	[HarmonyPatch("Clone")]
	[AutoInit]
	static class NullCardsFixPatch {
		static void Init() {
			RingWorm = CardLoader.GetCardByName("RingWorm");
		}
		private static CardInfo RingWorm;
		static bool Prefix(CardInfo c, out CardInfo __result) {
			if(c == null) {
				MainPlugin.logger.LogError("Someone (not to name names, but looking at you API...) tried to clone a null card. Pretty sussy! Instead of softlocking the game, i'll just return a ring worm instead.");
				if(RingWorm == null) {
					MainPlugin.logger.LogError("WTF? That Ring Worm is null too. This is really bad...");
					__result = null;
					return true;
				}
				__result = RingWorm;
				return false;
			}
			__result = null;
			return true;
		}
	}
}
