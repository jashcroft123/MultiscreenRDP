using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Remoting_Wizard.Converters
{
    /// <summary>
    /// Converts six digit hex string to System.Brush
    /// </summary>
    public sealed class StringToBrushConverter : IValueConverter
    {
        /// Converts six digit hex string to System.Brush
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>color</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Colors.HotPink;

            string hexString = (string)value;

            // String needs to be six code hex
            if (!hexString.Contains("#")) return Colors.HotPink;

            return (SolidColorBrush)new BrushConverter().ConvertFrom(hexString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
