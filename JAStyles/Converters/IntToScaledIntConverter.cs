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
    /// <summary>
    /// Scale the numeric value coming in by the command parameter
    /// </summary>
    public sealed class IntToScaledIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            var valueIn = (int)System.Convert.ChangeType(value,typeof(int));
            var parameterIn = (double)System.Convert.ChangeType(parameter, typeof(double));


            return valueIn * parameterIn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
