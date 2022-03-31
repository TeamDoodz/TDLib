using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;

namespace TDLib.GameContent {
	/// <summary>
	/// Extensions for <see cref="Ability"/>.
	/// </summary>
	public static class AbilityExtensions {

		private static List<Ability> synergygems = new List<Ability>() {
			Ability.GemDependant,
			Ability.GemsDraw,
			Ability.BuffGems,
			Ability.ExplodeGems,
			Ability.ShieldGems
		};
		/// <summary>
		/// Whether or not this sigil benefits the player if there is a gem on the board.
		/// </summary>
		/// <param name="sigil"></param>
		/// <returns></returns>
		public static bool SynergyWithGems(this Ability sigil) {
			return synergygems.Contains(sigil);
		}

		private static List<Ability> synergyconduit = new List<Ability>() {
			Ability.CellBuffSelf,
			Ability.CellDrawRandomCardOnDeath,
			Ability.CellTriStrike
		};
		/// <summary>
		/// Whether or not this sigil benefits the player if it is completed by a circuit.
		/// </summary>
		/// <param name="sigil"></param>
		/// <returns></returns>
		public static bool SynergyWithConduit(this Ability sigil) {
			return synergyconduit.Contains(sigil);
		}
	}
}
