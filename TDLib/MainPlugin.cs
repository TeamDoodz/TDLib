using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using DiskCardGame;
using InscryptionAPI.Card;
using TDLib.Attributes;
using UnityEngine;

namespace TDLib {
	/// <summary>
	/// The main plugin of the mod.
	/// </summary>
	[BepInPlugin(GUID, Name, Version)]
	[BepInDependency("cyantist.inscryption.api")]
	[BepInDependency("community.inscryption.patch")]
	[BepInDependency("extraVoid.inscryption.voidSigils", BepInDependency.DependencyFlags.SoftDependency)]
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

		bool PrefixInsensitiveExists = false;

		private void Awake() {
			logger = Logger;
			cfg = Config;
			logger.LogMessage($"{Name} v{Version} Loaded!");
			Loaded = true;

			new HarmonyLib.Harmony(GUID).PatchAll();

			AutoInitAttribute.CallAllInit(Assembly.GetExecutingAssembly());

		}

	}
}
