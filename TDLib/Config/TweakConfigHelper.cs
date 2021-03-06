
using BepInEx.Configuration;

namespace TDLib.Config {
	public class TweakConfigHelper<T> : ConfigHelperBase<T> {
		public string TweakName { get; }
		public string Name { get; }
		public string Description { get; }
		public T Default { get; }

		public TweakConfigHelper(ConfigFile file, string Name, string Description = "", T Default = default(T), string TweakName = "") {
			this.TweakName = TweakName;
			this.Name = Name;
			this.Default = Default;
			this.Description = Description;
			this.file = file;
		}

		private T valueCache;
		private bool cacheFilled = false;
		public override T GetValue() {
			if (cacheFilled) return valueCache;
			else {
				valueCache = file.Bind("Tweaks."+TweakName, Name, Default, Description).Value;
				cacheFilled = true;
				return valueCache;
			}
		}
	}
}
