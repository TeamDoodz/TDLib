
using BepInEx.Configuration;

namespace TDLib.Config {
	public abstract class ConfigHelperBase<T> {
		protected ConfigFile file;
		public abstract T GetValue();
	}
}
