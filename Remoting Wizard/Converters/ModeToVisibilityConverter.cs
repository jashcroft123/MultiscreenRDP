using Remoting_Wizard.Class;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Remoting_Wizard.Converters
{
    public sealed class ModeToVisibiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { //Make the required checks here. if you content is comboboxitem or something you have to make the conversion here.
            ConnectionModes temp = (ConnectionModes)value;

            if (temp is null)
                return Visibility.Collapsed;

            if (temp.Mode.ToLower() == parameter.ToString().ToLower())
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
