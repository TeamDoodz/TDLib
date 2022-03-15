using System;
using System.Collections.Generic;
using System.Text;
using BepInEx.Configuration;

namespace TDLib.Config {
	public class BasicConfigHelper<T> : ConfigHelperBase<T> {
		public string Category { get; }
		public string Name { get; }
		public string Description { get; }
		public T Default { get; }

		public BasicConfigHelper(ConfigFile file, string Name, string Description = "", T Default = default(T), string Category = "General") {
			this.Category = Category;
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
				valueCache = MainPlugin.cfg.Bind(Category, Name, Default, Description).Value;
				cacheFilled = true;
				return valueCache;
			}
		}
	}
}
