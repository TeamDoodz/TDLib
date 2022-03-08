using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using System;

namespace TDLib {
	/// <summary>
	/// The main plugin of the mod.
	/// </summary>
	[BepInPlugin(GUID, Name, Version)]
	public class MainPlugin : BaseUnityPlugin {

		internal const string GUID = "io.github.TeamDoodz." + Name;
		internal const string Name = "TDLib";
		internal const string Version = "2.0.0";

		/// <summary>
		/// Whether or not this mod has been loaded yet. If you want to do stuff after the mod has been loaded it is recommended to instead make a <see cref="BepInDependency"/> to the mod.
		/// </summary>
		public static bool Loaded = false;

		internal static ManualLogSource logger;

		private void Awake() {
			logger = Logger;
			logger.LogMessage($"{Name} v{Version} Loaded!");
			Loaded = true;

			new HarmonyLib.Harmony(GUID).PatchAll();
		}

	}
}
