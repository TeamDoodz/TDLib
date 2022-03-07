using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TDLib.Reflection;

namespace TDLib.Attributes {
	/// <summary>
	/// This attribute allows a class to run a static method when the main plguin loads. In order for this to work, the main plugin needs to use <see cref="CallAllInit(Assembly)"/> in the <i>Awake</i> method.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
	public class AutoInitAttribute : Attribute {
		/// <summary>
		/// Calls an <i>Init()</i> static method on all classes with <see cref="AutoInitAttribute"/>.
		/// </summary>
		/// <param name="assembly">The assembly to search for classes in.</param>
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