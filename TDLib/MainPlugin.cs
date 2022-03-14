using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using System;
using TDLib.Config;
using DiskCardGame;

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

		private BasicConfigHelper<bool> DoVanillaCardByName = new BasicConfigHelper<bool>("DoVanillaCardByName", "The API modifies the vanilla code for finding cards based on their name in a way that can break mods like Act3Cards. If you are having issues like cards being something they shouldn't or errors that mention \"GetNonGuidName\", turn this setting on.", false, "Dev");

		private void Awake() {
			logger = Logger;
			cfg = Config;
			logger.LogMessage($"{Name} v{Version} Loaded!");
			Loaded = true;

			new HarmonyLib.Harmony(GUID).PatchAll();
			if(DoVanillaCardByName.GetValue()) {
				new HarmonyLib.Harmony("cyantist.inscryption.api").Unpatch(typeof(CardLoader).GetMethod("GetCardByName"), HarmonyLib.HarmonyPatchType.Prefix);
			}
		}

	}
}
