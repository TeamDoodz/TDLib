using System;
using System.Collections.Generic;
using System.Text;
using TDLib.Attributes;
using DiskCardGame;
using TDLib.Config;

namespace TDLib.Patchers {
	[AutoInit]
	static class PreventLifeCurrencyBowlPatch {
		static BasicConfigHelper<bool> DisableBowlVisibility = new BasicConfigHelper<bool>(MainPlugin.cfg, "DisableBowlVisibility", "The Life Cost mod makes the currency bowl visible throught an entire battle, which can get annoying for some people. This option manually disables that.", false);
		static void Init() {
			if(DisableBowlVisibility.GetValue()) {
				MainPlugin.harmony.Unpatch(typeof(ResourcesManager).GetMethod("Setup"), typeof(LifeCost.OnSetupPatch_Part1.void_TeethPatch_ReourceSetup).GetMethod("Postfix"));
				MainPlugin.harmony.Unpatch(typeof(Part1ResourcesManager).GetMethod("Cleanup"), typeof(LifeCost.OnSetupPatch_Part1.void_TeethPatch_ReourceCleanup).GetMethod("Postfix"));
				MainPlugin.harmony.Unpatch(typeof(CurrencyBowl).GetMethod("ShowGain"), typeof(LifeCost.OnSetupPatch_Part1.void_TeethPatch_CurrencyBowlPatch).GetMethod("Postfix"));
			}
		}
	}
}
