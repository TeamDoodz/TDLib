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

			{
				CardInfo test = CardLoader.GetCardByName("MOON");
				logger.LogDebug($"Test card is null: {test == null}");
				if(test != null) {
					logger.LogDebug($"Test card name: {test.name}");
					if(test.name != "MOON") {
						PrefixInsensitiveExists = true;
					}
				}
			}

			{

				CardInfo card1 = ScriptableObject.CreateInstance<CardInfo>();
				card1.name = "TDLib_AutoPrefixCheck0";
				card1.SetBasic("Leave", 0, 1);
				card1.hideAttackAndHealth = true;
				card1.appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.FullCardPortrait, CardAppearanceBehaviour.Appearance.TerrainBackground };
				CardManager.Add(card1);
			}
			{
				CardInfo card = ScriptableObject.CreateInstance<CardInfo>();
				card.name = "AutoPrefixCheck1";
				card.SetBasic("Leave", 0, 1);
				card.hideAttackAndHealth = true;
				card.appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.FullCardPortrait, CardAppearanceBehaviour.Appearance.TerrainBackground };
				CardManager.Add(card);
			}
			{
				CardInfo card = ScriptableObject.CreateInstance<CardInfo>();
				card.name = "AutoPrefixCheck2";
				card.SetBasic("Leave", 0, 1);
				card.hideAttackAndHealth = true;
				card.appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.FullCardPortrait, CardAppearanceBehaviour.Appearance.TerrainBackground };
				CardManager.Add(card);
			}
			{
				CardInfo card = ScriptableObject.CreateInstance<CardInfo>();
				card.name = "AutoPrefixCheck3";
				card.SetBasic("Leave", 0, 1);
				card.hideAttackAndHealth = true;
				card.appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.FullCardPortrait, CardAppearanceBehaviour.Appearance.TerrainBackground };
				CardManager.Add(card);
			}
			{
				CardInfo card = ScriptableObject.CreateInstance<CardInfo>();
				card.name = "AutoPrefixCheck4";
				card.SetBasic("Leave", 0, 1);
				card.hideAttackAndHealth = true;
				card.appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.FullCardPortrait, CardAppearanceBehaviour.Appearance.TerrainBackground };
				CardManager.Add(card);
			}
			{
				CardInfo card = ScriptableObject.CreateInstance<CardInfo>();
				card.name = "AutoPrefixCheck5";
				card.SetBasic("Leave", 0, 1);
				card.hideAttackAndHealth = true;
				card.appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.FullCardPortrait, CardAppearanceBehaviour.Appearance.TerrainBackground };
				CardManager.Add(card);
			}
			{
				CardInfo card = ScriptableObject.CreateInstance<CardInfo>();
				card.name = "AutoPrefixCheck6";
				card.SetBasic("Leave", 0, 1);
				card.hideAttackAndHealth = true;
				card.appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.FullCardPortrait, CardAppearanceBehaviour.Appearance.TerrainBackground };
				CardManager.Add(card);
			}
		}

		bool firstFrame = true;
		private void Update() {
			if(firstFrame) {
				firstFrame = false;
				var card = CardLoader.GetCardByName("AutoPrefixCheck1");
				logger.LogDebug($"Test card is null: {card == null}");
				if(card != null) {
					logger.LogDebug($"Test card name: {card.name}");
					if(card.name != "AutoPrefixCheck1") {
						logger.LogError  ("---------------------------[READ THIS PLEASE]----------------------------");
						logger.LogWarning("If you are reading this, it means that auto-prefixes have not been");
						logger.LogWarning("removed from the API. This \"feature\" automatically modifies the IDs");
						logger.LogWarning("of cards without the modder's consent (and has no way to turn it off),");
						logger.LogWarning("resulting in potential bugs as well as general annoyance.");
						//logger.LogWarning("Learn more: (link doesn't exist yet)");
						logger.LogError  ("-------------------------------------------------------------------------");
					}
				}
				if(PrefixInsensitiveExists) {
					logger.LogError  ("---------------------------[READ THIS PLEASE]----------------------------");
					logger.LogWarning("If you are reading this, it means that prefix-insensitive card searching");
					logger.LogWarning("has not been removed from the API. This has the potential to break tons");
					logger.LogWarning("of mods, and maybe even the base game itself.");
					logger.LogWarning("Learn more: https://github.com/ScottWilson0903/InscryptionAPI/issues/44");
					logger.LogError  ("-------------------------------------------------------------------------");
				}
			}
		}

	}
}
