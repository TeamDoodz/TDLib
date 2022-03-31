using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using DiskCardGame;

namespace TDLib.Patchers {
	[HarmonyPatch(typeof(CardModificationInfo))]
	[HarmonyPatch("Clone")]
	static class FixNullCardModsPatch {
		static void Prefix(CardModificationInfo __instance) {
			if(__instance.abilities == null) __instance.abilities = new List<Ability>();
			if(__instance.negateAbilities == null) __instance.negateAbilities = new List<Ability>();
			if(__instance.specialAbilities == null) __instance.specialAbilities = new List<SpecialTriggeredAbility>();
			if(__instance.addGemCost == null) __instance.addGemCost = new List<GemType>();
		}
	}
}
