using JAStyles.Styles;
using Prism.Mvvm;
using Remoting_Wizard.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Remoting_Wizard.Class
{
    public class ApplicationColours : BindableBase
    {
        private Color _SystemAccentColor;
        public Color SystemAccentColor
        {
            get { return _SystemAccentColor; }
            set { SetProperty(ref _SystemAccentColor, value); }
        }

        private Color _SystemAccentColorLight1;
        public Color SystemAccentColorLight1
        {
            get { return _SystemAccentColorLight1; }
            private set { SetProperty(ref _SystemAccentColorLight1, value); }
        }

        public ApplicationColours(ConfigurationSettings configurationSettings)
        {
            configurationSettings.PropertyChanged += ConfigurationSettings_PropertyChanged;
            this.PropertyChanged += ApplicationColours_PropertyChanged;
        }

        private void ConfigurationSettings_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var val = (ConfigurationSettings)sender;

            if (e.PropertyName == nameof(ConfigurationSettings.AccentColour))
            {
                SystemAccentColor = (Color)ColorConverter.ConvertFromString(val.AccentColour);
            }
        }

        private void ApplicationColours_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries[0]["SystemAccentColorBrush"] = new SolidColorBrush(SystemAccentColor);
            SystemAccentColorLight1 = ChangeLightness(SystemAccentColor,0.8);
            Application.Current.Resources.MergedDictionaries[0]["SystemAccentColorLight1Brush"] = new SolidColorBrush(SystemAccentColorLight1);
            //var temp = new SolidColorBrush(System.Windows.Media.Colors.HotPink);
            //this.Resources.MergedDictionaries[0]["SystemAccentColorBrush"] = temp;
            //var test2 = this.Resources.MergedDictionaries[0]["SystemAccentColorBrush"];
        }

        public Color ChangeLightness(Color color, double coef)
        {
            return Color.FromArgb((byte)(color.A),(byte)(color.R * coef), (byte)(color.G * coef),
                (byte)(color.B * coef));
        }
    }
}
