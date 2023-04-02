using JAStyles.Styles;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace JAWPF
{
    public class ApplicationColours : BindableBase
    {

        #region Bindable Properties

        private Color _SystemAccentColor;
        public Color SystemAccentColor
        {
            get { return _SystemAccentColor; }
            set { SetProperty(ref _SystemAccentColor, value); }
        }

        private Color _AccentHighLightBrush;
        public Color AccentHighLightBrush
        {
            get { return _AccentHighLightBrush; }
            private set { SetProperty(ref _AccentHighLightBrush, value); }
        }

        private Color _SystemAccentColorLight1;
        public Color SystemAccentColorLight1
        {
            get { return _SystemAccentColorLight1; }
            private set { SetProperty(ref _SystemAccentColorLight1, value); }
        }
        private Color _SystemAccentColorLight2;
        public Color SystemAccentColorLight2
        {
            get { return _SystemAccentColorLight2; }
            private set { SetProperty(ref _SystemAccentColorLight2, value); }
        }
        private Color _SystemAccentColorLight3;
        public Color SystemAccentColorLight3
        {
            get { return _SystemAccentColorLight3; }
            private set { SetProperty(ref _SystemAccentColorLight3, value); }
        }

        private Color _SystemAccentColorDark1;
        public Color SystemAccentColorDark1
        {
            get { return _SystemAccentColorDark1; }
            private set { SetProperty(ref _SystemAccentColorDark1, value); }
        }
        private Color _SystemAccentColorDark2;
        public Color SystemAccentColorDark2
        {
            get { return _SystemAccentColorDark2; }
            private set { SetProperty(ref _SystemAccentColorDark2, value); }
        }
        private Color _SystemAccentColorDark3;
        public Color SystemAccentColorDark3
        {
            get { return _SystemAccentColorDark3; }
            private set { SetProperty(ref _SystemAccentColorDark3, value); }
        }
        #endregion

        #region Public Properties

        #endregion

        #region Private Properties
        private ResourceDictionary _ColourResources { get; set; }
        #endregion


        public ApplicationColours()
        {
            this.PropertyChanged += ApplicationColours_PropertyChanged;

            _ColourResources = FindMergedDictionaryRecursive("Colours", Application.Current.Resources);
        }

        /// <summary>
        /// basic implemetation to increase or decrease the RGB value to change the lightness 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="coef"></param>
        /// <returns></returns>
        public Color ChangeLightness(Color color, double coef)
        {
            return Color.FromArgb((byte)(color.A), (byte)(color.R * coef), (byte)(color.G * coef),
                (byte)(color.B * coef));
        }

        /// <summary>
        /// basic implemetation to increase or decrease the A value to change the Transparency 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="coef"></param>
        /// <returns></returns>
        public Color ChangeTransparency(Color color, double coef)
        {
            return Color.FromArgb((byte)(color.A * coef), (byte)(color.R), (byte)(color.G),
                (byte)(color.B));
        }

        private static ResourceDictionary FindMergedDictionaryRecursive(string dictionaryName, ResourceDictionary startingDictionary)
        {
            // Check the starting dictionary for the named dictionary
            ResourceDictionary namedDictionary = startingDictionary.MergedDictionaries.FirstOrDefault(md => md.Source.OriginalString.Contains(dictionaryName));
            if (namedDictionary != null)
            {
                return namedDictionary;
            }

            // If the named dictionary wasn't found in the starting dictionary, recursively search its merged dictionaries
            foreach (ResourceDictionary mergedDictionary in startingDictionary.MergedDictionaries)
            {
                ResourceDictionary recursiveResult = FindMergedDictionaryRecursive(dictionaryName, mergedDictionary);
                if (recursiveResult != null)
                {
                    return recursiveResult;
                }
            }

            // If the named dictionary wasn't found in any of the merged dictionaries, return null
            return null;
        }


        private void ApplicationColours_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SystemAccentColor))
            {
                UpdateAccentColors();
            }
        }

        private void UpdateAccentColors()
        {
            _ColourResources["SystemAccentColorBrush"] = new SolidColorBrush(SystemAccentColor);

            AccentHighLightBrush = ChangeTransparency(SystemAccentColor, 0.5);
            _ColourResources["AccentHighLightBrush"] = new SolidColorBrush(AccentHighLightBrush);

            SystemAccentColorLight1 = ChangeLightness(SystemAccentColor, 0.8);
            _ColourResources["SystemAccentColorLight1Brush"] = new SolidColorBrush(SystemAccentColorLight1);
            SystemAccentColorLight2 = ChangeLightness(SystemAccentColor, 0.6);
            _ColourResources["SystemAccentColorLight2Brush"] = new SolidColorBrush(SystemAccentColorLight2);
            SystemAccentColorLight3 = ChangeLightness(SystemAccentColor, 0.4);
            _ColourResources["SystemAccentColorLight3Brush"] = new SolidColorBrush(SystemAccentColorLight3);

            SystemAccentColorDark1 = ChangeLightness(SystemAccentColor, 1.2);
            _ColourResources["SystemAccentColorDark1Brush"] = new SolidColorBrush(SystemAccentColorDark1);
            SystemAccentColorDark2 = ChangeLightness(SystemAccentColor, 1.4);
            _ColourResources["SystemAccentColorDark2Brush"] = new SolidColorBrush(SystemAccentColorDark2);
            SystemAccentColorDark3 = ChangeLightness(SystemAccentColor, 1.6);
            _ColourResources["SystemAccentColorDark3Brush"] = new SolidColorBrush(SystemAccentColorDark3);
        }
    }
}
