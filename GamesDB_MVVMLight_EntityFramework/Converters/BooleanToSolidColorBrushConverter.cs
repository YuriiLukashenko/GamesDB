using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GamesDB_MVVMLight_EntityFramework.Converters
{
    public class BooleanToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            var boolValue = (bool)value;
            return boolValue ? new SolidColorBrush(Colors.Tomato) : new SolidColorBrush(Colors.Green);

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            return null;
        }
    }
}
