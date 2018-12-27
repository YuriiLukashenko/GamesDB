using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GamesDB_MVVMLight_EntityFramework.Converters
{
    public class BooleanToVisibilityConverter: IValueConverter
    {
        enum Parameter
        {
            Normal, Inverted
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            var boolValue = (bool)value;

            Parameter direction = Parameter.Normal;
            if (parameter != null)
                direction = (Parameter)Enum.Parse(typeof(Parameter), (string)parameter);

            if (direction == Parameter.Inverted)
                return !boolValue ? Visibility.Visible : Visibility.Collapsed;

            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            return null;
        }
    }
}
