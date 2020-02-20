using System;
using System.ComponentModel;

namespace Jupiter.Framework.Utilities
{
    public static class StringHelper
    {
        public static String RemoveCurrency(this string value)
        {
            return value.Replace("$", string.Empty);
        }

        public static TEnum GetEnumValueByDescription<TEnum>(this string description)
        {
            var type = typeof(TEnum);
            if (!type.IsEnum)
            {
                throw new InvalidOperationException($"Provided type '{type}' does not represent an Enum");
            }
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                    && attribute.Description.Equals(description))
                {
                    return (TEnum)field.GetValue(null);
                }
            }
            throw new ArgumentException($"Enum value with description '{description}' was not found");
        }
    }
}
