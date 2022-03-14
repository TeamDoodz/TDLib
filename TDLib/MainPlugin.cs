using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using System;
using TDLib.Config;
using DiskCardGame;
using InscryptionAPI.Card;

namespace TDLib {
	/// <summary>
	/// The main plugin of the mod.
	/// </summary>
	[BepInPlugin(GUID, Name, Version)]
	[BepInDependency("cyantist.inscryption.api")]
	[BepInDependency("extraVoid.inscryption.voidSigils",BepInDependency.DependencyFlags.SoftDependency)]
	[BepInDependency("org.memez4life.inscryption.customsigils", BepInDependency.DependencyFlags.SoftDependency)]
	public class MainPlugin : BaseUnityPlugin {

		internal const string GUID = "io.github.TeamDoodz." + Name;
		internal const string Name = "TDLib";
		internal const string Version = "2.0.0";

		/// <summary>
		/// Whether or not this mod has been loaded yet. If you want to do stuff after the mod has been loaded it is recommended to instead make a <see cref="BepInDependency"/> to the mod.
		/// </summary>
		public static bool Loaded = false;

		internal static ManualLogSource logger;
		internal static ConfigFile cfg;

		private void Awake() {
			logger = Logger;
			cfg = Config;
			logger.LogMessage($"{Name} v{Version} Loaded!");
			Loaded = true;

			new HarmonyLib.Harmony(GUID).PatchAll();

			{
				CardInfo test = CardLoader.GetCardByName("MOON");
				logger.LogDebug($"Test card is null: {test == null}");
				if(test != null) {
				logger.LogDebug($"Test card name: {test.name}");
					if(test.name != "MOON") {
						logger.LogError  ("---------------------------[READ THIS PLEASE]----------------------------");
						logger.LogWarning("If you are reading this, it means that prefix-insensitive card searching");
						logger.LogWarning("has not been removed from the API. This \"feature\" has the potential to");
						logger.LogWarning("break tons of mods, and maybe even the base game itself.");
						logger.LogWarning("Learn more: https://github.com/ScottWilson0903/InscryptionAPI/issues/44");
						logger.LogError  ("-------------------------------------------------------------------------");
					}
				}
			}
		}

	}
}
