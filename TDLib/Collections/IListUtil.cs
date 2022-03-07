using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DiskCardGame;

namespace TDLib.Collections {
	/// <summary>
	/// Utilities and extensions for <see cref="IList{T}"/>.
	/// </summary>
	public static class IListUtil {

		/// <summary>
		/// Gets a random entry in the specified list and returns it.
		/// </summary>
		/// <typeparam name="T">The type of list provided.</typeparam>
		/// <param name="self">The list provided.</param>
		/// <param name="randomSeed">The seed to use for RNG.</param>
		/// <param name="blacklist"></param>
		/// <returns></returns>
		public static T GetRandom<T>(this IList<T> self, int randomSeed, IList<T> blacklist = null) {
			IList<T> bl = blacklist ?? new List<T>();
			IList<T> removed = (IList<T>)new List<T>();
			foreach(var entry in self) {
				if(!bl.Contains(entry)) removed.Add(entry);
			}
			return removed[SeededRandom.Range(0, removed.Count, randomSeed)];
		}

		/// <summary>
		/// Shuffles the specified list using the modernized Fisher-Yates shuffle algorithm.
		/// </summary>
		/// <typeparam name="T">The type of list provided.</typeparam>
		/// <param name="self">The list provided.</param>
		/// <param name="randomSeed">The seed to use for RNG.</param>
		/// <returns></returns>
		public static IList<T> Shuffle<T>(this IList<T> self, int randomSeed) {
			IList<T> outp = new List<T>();
			foreach (var entry in self) {
				outp.Add(entry);
			}

			int internalSeed = randomSeed;

			// For a list a of n elements
			for (int i=0; i <= (self.Count-2); i++) {
				int j = SeededRandom.Range(i, self.Count, internalSeed); // A random integer such that i <= j < n
				outp.Swap(i, j);
			}

			return outp;
		}

		/// <summary>
		/// Swaps entries A and B in a list.
		/// </summary>
		/// <typeparam name="T">The type of list provided.</typeparam>
		/// <param name="self">The list provided.</param>
		/// <param name="A">The index of entry A.</param>
		/// <param name="B">The index of entry B.</param>
		public static void Swap<T>(this IList<T> self, int A, int B) {
			T valA = self[A];
			T valB = self[B];
			self[A] = valB;
			self[B] = valA;
		}

	}
}
