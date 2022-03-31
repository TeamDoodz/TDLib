using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TDLib.Reflection {
    /// <summary>
    /// Utilities and extensions for <see cref="Attribute"/>.
    /// </summary>
	public static class AttributeUtils {
        /// <summary>
        /// <seealso href="https://stackoverflow.com/questions/607178/how-enumerate-all-classes-with-custom-class-attribute"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesWithAttribute<T>(Assembly assembly) where T : Attribute {
            foreach (Type type in assembly.GetTypes()) {
                if (type.GetCustomAttributes(typeof(T), true).Length > 0) {
                    yield return type;
                }
            }
        }
    }
}
