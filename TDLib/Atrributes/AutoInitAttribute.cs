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
			Dictionary<Priority, List<MethodInfo>> Inits = new Dictionary<Priority, List<MethodInfo>>();
			Inits.Add(Priority.High, new List<MethodInfo>());
			Inits.Add(Priority.Medium, new List<MethodInfo>());
			Inits.Add(Priority.Low, new List<MethodInfo>());

			foreach (var type in AttributeUtils.GetTypesWithAttribute<AutoInitAttribute>(assembly)) {
				var method = type.GetMethod("Init", BindingFlags.Static | BindingFlags.NonPublic);
				if (method == null) {
					method = type.GetMethod("Init", BindingFlags.Static | BindingFlags.Public);
				}
				if (method != null) {
					Inits[type.GetCustomAttribute<AutoInitAttribute>().priority].Add(method);
				} else {
					MainPlugin.logger.LogWarning($"Could not find Init() method for type {type.Name}");
				}
			}
			foreach(var methodList in Inits.Values) {
				foreach(var method in methodList) {
					try {
						method.Invoke(null, new object[] { });
					} catch(Exception ex) {
						MainPlugin.logger.LogError($"Error calling Init on {method.DeclaringType.Name}: {ex}");
					}
				}
			}
		}
		public AutoInitAttribute(Priority priority = Priority.Medium) {
			this.priority = priority;
		}
		public Priority priority { get; private set; }
		public enum Priority {
			Low,
			Medium,
			High,
		}
	}
}