using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using System;

namespace TDLib {
	[BepInPlugin(GUID, Name, Version)]
	public class MainPlugin : BaseUnityPlugin {

		internal const string GUID = "io.github.TeamDoodz." + Name;
		internal const string Name = "TDLib";
		internal const string Version = "1.0.0";

		public static bool Loaded = false;

		internal static ManualLogSource logger;

		private void Awake() {
			logger = Logger;
			logger.LogMessage($"{Name} v{Version} Loaded!");
			Loaded = true;
		}

	}
}
