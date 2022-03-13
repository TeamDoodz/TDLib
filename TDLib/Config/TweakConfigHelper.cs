
namespace TDLib.Config {
	public class TweakConfigHelper<T> : ConfigHelperBase<T> {
		public string TweakName { get; }
		public string Name { get; }
		public string Description { get; }
		public T Default { get; }

		public TweakConfigHelper(string Name, string Description = "", T Default = default(T), string TweakName = "") {
			this.TweakName = TweakName;
			this.Name = Name;
			this.Default = Default;
			this.Description = Description;
		}

		private T valueCache;
		private bool cacheFilled = false;
		public override T GetValue() {
			if (cacheFilled) return valueCache;
			else {
				valueCache = MainPlugin.cfg.Bind("Tweaks."+TweakName, Name, Default, Description).Value;
				cacheFilled = true;
				return valueCache;
			}
		}
	}
}
