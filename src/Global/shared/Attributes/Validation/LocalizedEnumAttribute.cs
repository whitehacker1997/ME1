//https://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/EnumDataTypeAttribute.cs

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;

namespace Global.Attributes
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = false)]
    public class LocalizedEnumDataTypeAttribute : DataTypeAttribute
    {
        public Type EnumType { get; private set; }

        public LocalizedEnumDataTypeAttribute(Type enumType)
            : base("Enumeration")
        {
            EnumType = enumType;
        }

        public override bool IsValid(object value)
        {
            if (this.EnumType == null)
            {
                throw new InvalidOperationException("Enum Type cannot be null");
            }
            if (!this.EnumType.IsEnum)
            {
                throw new InvalidOperationException($"Type {this.EnumType.FullName} must be enum");
            }

            if (value == null)
            {
                return true;
            }
            string stringValue = value as string;
            if (stringValue != null && String.IsNullOrEmpty(stringValue))
            {
                return true;
            }

            Type valueType = value.GetType();
            if (valueType.IsEnum && this.EnumType != valueType)
            {
                // don't match a different enum that might map to the same underlying integer
                // 
                return false;
            }

            if (!valueType.IsValueType && valueType != typeof(string))
            {
                // non-value types cannot be converted
                return false;
            }

            if (valueType == typeof(bool) ||
                valueType == typeof(float) ||
                valueType == typeof(double) ||
                valueType == typeof(decimal) ||
                valueType == typeof(char))
            {
                // non-integral types cannot be converted
                return false;
            }

            object convertedValue;
            if (valueType.IsEnum)
            {
                Debug.Assert(valueType == value.GetType(), "The valueType should equal the Type of the value");
                convertedValue = value;
            }
            else
            {
                try
                {
                    if (stringValue != null)
                    {
                        convertedValue = Enum.Parse(this.EnumType, stringValue, false);
                    }
                    else
                    {
                        convertedValue = Enum.ToObject(this.EnumType, value);
                    }
                }
                catch (ArgumentException)
                {
                    // 
                    return false;
                }
            }

            if (IsEnumTypeInFlagsMode(this.EnumType))
            {
                // 
                string underlying = GetUnderlyingTypeValueString(this.EnumType, convertedValue);
                string converted = convertedValue.ToString();
                return !underlying.Equals(converted);
            }
            else
            {
                return Enum.IsDefined(this.EnumType, convertedValue);
            }
        }

        private static bool IsEnumTypeInFlagsMode(Type enumType)
        {
            return enumType.GetCustomAttributes(typeof(FlagsAttribute), false).Length != 0;
        }


        private static string GetUnderlyingTypeValueString(Type enumType, object enumValue)
        {
            return Convert.ChangeType(enumValue, Enum.GetUnderlyingType(enumType), CultureInfo.InvariantCulture).ToString();
        }
    }
}
