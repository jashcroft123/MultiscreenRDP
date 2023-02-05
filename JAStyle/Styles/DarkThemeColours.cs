using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace JAStyles.Styles
{
    public class DarkThemeColours : BindableBase
    {
        #region components
        public const string BackgroundLight5Brush = "#808080";
        public const string BackgroundLight4Brush = "#484848";
        public const string BackgroundLight3Brush = "#3C3C3C";
        public const string BackgroundLight2Brush = "#333333";
        public const string BackgroundLight1Brush = "#2A2A2A";
        public const string BackgroundBrush =       "#212121";
        public const string BackgroundDark1Brush =  "#1C1C1C";
        public const string BackgroundDark2Brush =  "#131313";
        public const string BackgroundDark3Brush =  "#0F0F0F";
        public const string BackgroundDark4Brush =  "#000000";

        public const string SystemAccentColorLight3Brush = "#ffc030";
        public const string SystemAccentColorLight2Brush = "#ffb331";
        public const string SystemAccentColorLight1Brush = "#ffa632";
        public const string SystemAccentColorBrush = "#FF9933";
        public const string SystemAccentColorDark1Brush = "#cc7a28";
        public const string SystemAccentColorDark2Brush = "#995b1e";
        public const string SystemAccentColorDark3Brush = "#653c14";

        public const string AccentHighLightBrush = "#11653c14";



        private string _ChangeBrush;

        public string ChangeBrush
        {
            get { return _ChangeBrush; }
            set { SetProperty(ref _ChangeBrush, value); }
        }


        /// <summary>
        /// Pass green
        /// </summary>
        public const string Green = "#8EE43F";

        /// <summary>
        /// Lighter pass green
        /// </summary>
        public const string LightGreen = "#84DA35";

        /// <summary>
        /// Fail red
        /// </summary>
        public const string Red = "#FF626D";

        /// <summary>
        /// Darker fail red
        /// </summary>
        public const string DarkRed = "#8B0000";

        /// <summary>
        /// Used to highlight engineering across the application
        /// </summary>
        public const string Blue = "#33BBFF";

        /// <summary>
        /// Lighter engineering colour
        /// </summary>
        public const string LightBlue = "#7AD9F5";

        /// <summary>
        /// Used for text displaying database data or inputs
        /// </summary>
        public const string White = "#FFFFFF";

        /// <summary>
        /// Black
        /// </summary>
        public const string Black = "#000000";

        #endregion
    }
}
