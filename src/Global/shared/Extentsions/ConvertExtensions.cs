using System.Globalization;

namespace Global
{
    public static class ConvertExtensions
    {
        public static string AsString(this object value)
        {
            if (value == null)
                return string.Empty;

            if (value is string)
                return (string)value;

            return value.ToString();
        }

        public static int AsInt(this string value, int defaultValue, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            if (formatProvider == null)
                formatProvider = GetDefaultFormatProvider();

            if (int.TryParse(value, numberStyles, formatProvider, out int convertedValue))
                return convertedValue;

            return defaultValue;
        }
        public static int? AsInt(this string value, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            if (formatProvider == null)
                formatProvider = GetDefaultFormatProvider();

            if (int.TryParse(value, numberStyles, formatProvider, out int convertedValue))
                return convertedValue;

            return default;
        }

        public static long AsLong(this string value, long defaultValue, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            if (formatProvider == null)
                formatProvider = GetDefaultFormatProvider();

            if (long.TryParse(value, numberStyles, formatProvider, out long convertedValue))
                return convertedValue;

            return defaultValue;
        }
        public static long? AsLong(this string value, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            if (formatProvider == null)
                formatProvider = GetDefaultFormatProvider();

            if (long.TryParse(value, numberStyles, formatProvider, out long convertedValue))
                return convertedValue;

            return default;
        }

        public static decimal AsDecimal(this string value, decimal defaultValue, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            if (formatProvider == null)
                formatProvider = GetDefaultFormatProvider();

            if (decimal.TryParse(value, numberStyles, formatProvider, out decimal convertedValue))
                return convertedValue;

            return defaultValue;
        }
        public static decimal? AsDecimal(this string value, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            if (formatProvider == null)
                formatProvider = GetDefaultFormatProvider();

            if (decimal.TryParse(value, numberStyles, formatProvider, out decimal convertedValue))
                return convertedValue;

            return default;
        }

        public static double AsDouble(this string value, double defaultValue, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            if (formatProvider == null)
                formatProvider = GetDefaultFormatProvider();

            if (double.TryParse(value, numberStyles, formatProvider, out double convertedValue))
                return convertedValue;

            return defaultValue;
        }
        public static double? AsDouble(this string value, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            if (formatProvider == null)
                formatProvider = GetDefaultFormatProvider();

            if (double.TryParse(value, numberStyles, formatProvider, out double convertedValue))
                return convertedValue;

            return default;
        }

        public static float AsSingle(this string value, float defaultValue, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            if (formatProvider == null)
                formatProvider = GetDefaultFormatProvider();

            if (float.TryParse(value, numberStyles, formatProvider, out float convertedValue))
                return convertedValue;

            return defaultValue;
        }
        public static float? AsSingle(this string value, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Any)
        {
            if (formatProvider == null)
                formatProvider = GetDefaultFormatProvider();

            if (float.TryParse(value, numberStyles, formatProvider, out float convertedValue))
                return convertedValue;

            return default;
        }

        private static IFormatProvider GetDefaultFormatProvider() => CultureInfo.InvariantCulture;
    }
}
