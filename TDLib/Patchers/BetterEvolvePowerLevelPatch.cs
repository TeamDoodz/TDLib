using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;
using HarmonyLib;

namespace TDLib.Patchers {
	[HarmonyPatch(typeof(CardInfo))]
	[HarmonyPatch("get_PowerLevel")]
	public static class BetterEvolvePowerLevelPatch {
		private static void Postfix(CardInfo __instance, ref int __result) {
			if(__instance.Abilities.Contains(Ability.Evolve) || __instance.Abilities.Contains(Ability.Transformer)) {
				if(__instance.iceCubeParams != null) {
					__result = __instance.iceCubeParams.creatureWithin.PowerLevel - 2;
				}
			}
		}
	}
}
