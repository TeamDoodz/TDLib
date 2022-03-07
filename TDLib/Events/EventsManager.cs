using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;

namespace TDLib.Events {
	/// <summary>
	/// Several events to hook into rather than create a whole new patch.
	/// </summary>
	public static class EventsManager {
		/// <summary>
		/// Called when a battle starts.
		/// </summary>
		public static event Action<EncounterData> BattleStarted;
		internal static void CallBattleStartedBecauseCSharpIsStupid(EncounterData obj) => BattleStarted.Invoke(obj);
	}
}
