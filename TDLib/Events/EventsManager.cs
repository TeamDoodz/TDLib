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
		internal static void CallBattleStarted(EncounterData obj) {
			MainPlugin.logger.LogDebug($"Calling {nameof(BattleStarted)}");
			if(BattleStarted != null) BattleStarted.Invoke(obj);
		}
		/// <summary>
		/// Called when a battle ends.
		/// </summary>
		public static event Action BattleEnded;
		internal static void CallBattleEnded() {
			MainPlugin.logger.LogDebug($"Calling {nameof(BattleEnded)}");
			if(BattleEnded != null) BattleEnded.Invoke();
		}
		/// <summary>
		/// Called when a run starts.
		/// </summary>
		public static event Action RunStarted;
		internal static void CallRunStarted() {
			MainPlugin.logger.LogDebug($"Calling {nameof(RunStarted)}");
			if(RunStarted != null) RunStarted.Invoke();
		}
	}
}
