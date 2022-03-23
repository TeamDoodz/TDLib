using System.Reflection;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;
using HarmonyLib;
using InscryptionCommunityPatch.ResourceManagers;
using TDLib.Attributes;
using TDLib.Config;

namespace TDLib.Patchers {
	[AutoInit]
	static class RevertDronePositionPatch {
		static BasicConfigHelper<bool> RevertDronePosition = new BasicConfigHelper<bool>(MainPlugin.cfg, "RevertDronePosition", "The Community Patch makes some modifications to the positioning of the energy/mox drone. This setting reverts those changes.", false);
		static void Init() {
			if(RevertDronePosition.GetValue()) {
				MethodInfo original = typeof(ResourceDrone).GetMethod("SetOnBoard");
				MainPlugin.harmony.Unpatch(original, typeof(EnergyDrone).GetMethod("ResourceDrone_SetOnBoard", BindingFlags.Static | BindingFlags.Public));
				MainPlugin.harmony.Patch(original, new HarmonyMethod(typeof(RevertDronePositionPatch).GetMethod(nameof(NewPatch), BindingFlags.Static | BindingFlags.NonPublic)));
			}
		}

		static void NewPatch(ResourceDrone __instance) {
			if(SaveManager.SaveFile.IsPart1 || SaveManager.SaveFile.IsGrimora) {
				__instance.Gems.gameObject.SetActive(true);
			}
		}
	}
}
