using System;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkExtras
{
    internal static class Attributes
    {
        public static T GetAttribute<T>(Type fromType) where T : Attribute
        {
            object[] attributes = fromType.GetCustomAttributes(typeof(T), false);

            return GetAttribute<T>(attributes);
        }

        public static T GetAttribute<T>(PropertyInfo propertyInfo) where T : Attribute
        {
            object[] attributes = propertyInfo.GetCustomAttributes(typeof(T), false);

            return GetAttribute<T>(attributes);
        }

        private static T GetAttribute<T>(object[] attributes) where T : Attribute
        {
            if (!attributes.Any())
                return null;

            var attribute = (T)attributes.First();

            return attribute;
        }
    }
}