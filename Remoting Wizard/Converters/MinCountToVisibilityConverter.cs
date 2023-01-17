using Remoting_Wizard.Class;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Remoting_Wizard.Converters
{
    public sealed class MinCountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { //Make the required checks here. if you content is comboboxitem or something you have to make the conversion here.
            int valueInput = (int)(value ?? 0);
            int minValue = int.Parse((string)parameter);

            if (valueInput <= minValue)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
