using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Remoting_Wizard.Configuration
{
    public class ConfigurationSettings : BindableBase, IConfigurationSettings
    {
        private ColourSchemeEnum _ColourScheme;
        public ColourSchemeEnum ColourScheme
        {
            get { return _ColourScheme; }
            set { SetProperty(ref _ColourScheme, value); }
        }


        private string _AccentColour;
        public string AccentColour
        {
            get { return _AccentColour; }
            set { SetProperty(ref _AccentColour, value);



            }
        }
    }
}
