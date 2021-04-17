using ABI.Common.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ABI.UI.Converters.CommandParameterConverters
{
    public class WindowStateToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WindowState state = WindowState.Normal;
            switch (value.ToString())
            {
                case "Normal":
                    state = WindowState.Normal;
                    break;
                case "Minimized":
                    state = WindowState.Minimized;
                    break;
                case "Maximized":
                    state = WindowState.Maximized;
                    break;
                default:
                    break;
            }

            return state;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
