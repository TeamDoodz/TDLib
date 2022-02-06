using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;

namespace TDLib.GameContent {
	public static class AbilityExtensions {

		private static List<Ability> synergygems = new List<Ability>() {
			Ability.GemDependant,
			Ability.GemsDraw,
			Ability.BuffGems,
			Ability.ExplodeGems,
			Ability.ShieldGems
		};
		public static bool SynergyWithGems(this Ability sigil) {
			return synergygems.Contains(sigil);
		}

		private static List<Ability> synergyconduit = new List<Ability>() {
			Ability.CellBuffSelf,
			Ability.CellDrawRandomCardOnDeath,
			Ability.CellTriStrike
		};
		public static bool SynergyWithConduit(this Ability sigil) {
			return synergyconduit.Contains(sigil);
		}
	}
}
