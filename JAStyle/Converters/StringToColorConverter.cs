﻿using System;
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
    public sealed class StringToColorConverter : IValueConverter
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
            if (value == null) return Colors.HotPink;

            string hexString = (string)value;

            // String needs to be six code hex
            if (!hexString.Contains("#")) return Colors.HotPink;

            return (Color)ColorConverter.ConvertFromString(hexString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
