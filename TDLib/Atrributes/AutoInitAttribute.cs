using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TDLib.Reflection;

namespace TDLib.Attributes {
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
	public class AutoInitAttribute : Attribute {
		public static void CallAllInit(Assembly assembly) {
			foreach (var type in AttributeUtils.GetTypesWithAttribute<AutoInitAttribute>(assembly)) {
				var method = type.GetMethod("Init", BindingFlags.Static | BindingFlags.NonPublic);
				if (method == null) {
					method = type.GetMethod("Init", BindingFlags.Static | BindingFlags.Public);
				}
				if (method != null) {
					MainPlugin.logger.LogDebug($"Calling Init() method on {type.Name}");
					method.Invoke(null, new object[] { });
				} else {
					MainPlugin.logger.LogWarning($"Could not find Init() method for type {type.Name}");
				}
			}
		}
	}
}