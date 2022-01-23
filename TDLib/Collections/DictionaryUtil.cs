using System;
using System.Collections.Generic;
using System.Text;

namespace TDLib.Collections {
	public static class DictionaryUtil {

		/// <summary>
		/// If key exists, set it to value. If not, create key and set it to value.
		/// </summary>
		/// <typeparam name="TKey">The type of key specified.</typeparam>
		/// <typeparam name="TValue">The type of value specified.</typeparam>
		/// <param name="self">This.</param>
		/// <param name="key">The key to set.</param>
		/// <param name="value">The value to set.</param>
		public static void SafeSet<TKey,TValue>(this Dictionary<TKey,TValue> self, TKey key, TValue value) {
			if (self.ContainsKey(key)) self[key] = value; else self.Add(key, value);
		}

		/// <summary>
		/// If key exists, return it. Otherwise return fallback.
		/// </summary>
		/// <typeparam name="TKey">The type of key specified.</typeparam>
		/// <typeparam name="TValue">The type of value specified.</typeparam>
		/// <param name="self">This.</param>
		/// <param name="key">The key to get.</param>
		/// <param name="fallback">The fallback value.</param>
		/// <returns></returns>
		public static TValue SafeGet<TKey,TValue>(this Dictionary<TKey,TValue> self, TKey key, TValue fallback = default) {
			if (self.ContainsKey(key)) return self[key]; else return fallback;
		}

	}
}
