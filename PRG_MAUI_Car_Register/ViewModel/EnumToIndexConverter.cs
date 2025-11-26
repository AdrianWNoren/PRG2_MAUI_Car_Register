using System.Globalization;

namespace PRG_MAUI_Car_Register.Converters
{
    public class EnumToIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Vehicle.Type enumValue)
                return (int)enumValue;
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue && Enum.IsDefined(typeof(Vehicle.Type), intValue))
                return (Vehicle.Type)intValue;
            return Vehicle.Type.Bil;
        }
    }
}