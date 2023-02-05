using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace JAStyles.Converters
{
    /// <summary>
    /// Converts six digit hex string to System.Color
    /// </summary>
    public sealed class SolidColourBrushToColourConverter : IValueConverter
    {
        /// <summary>
        /// Converts six digit hex string to System.Color
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>color</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((SolidColorBrush)value)?.Color ?? new Color();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
