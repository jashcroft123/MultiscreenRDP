using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Remoting_Wizard.Converters
{
    public sealed class MinCountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
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
