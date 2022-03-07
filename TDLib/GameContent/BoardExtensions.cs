using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;

namespace TDLib.GameContent {
	/// <summary>
	/// Extensions for <see cref="BoardManager"/>.
	/// </summary>
	public static class BoardExtensions {
		/// <summary>
		/// Returns the number of gems on the board, not counting opponent queue slots.
		/// </summary>
		/// <param name="board"></param>
		/// <returns></returns>
		public static int GemsOnBoard(this BoardManager board) {
			int gems = 0;
			foreach(var card in board.CardsOnBoard) {
				if (card.Info.traits.Contains(Trait.Gem)) {
					gems++;
				}
			}
			return gems;
		}
		/// <summary>
		/// Returns the number of conduits on the board, not counting opponent queue slots.
		/// </summary>
		/// <param name="board"></param>
		/// <returns></returns>
		public static int ConduitsOnBoard(this BoardManager board) {
			int conduits = 0;
			foreach (var card in board.CardsOnBoard) {
				foreach(var ability in card.Info.Abilities) {
					if(AbilitiesUtil.GetInfo(ability).conduit) {
						conduits++;
						continue;
					}
				}
			}
			return conduits;
		}
	}
}
