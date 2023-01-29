using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting_Wizard.Configuration
{
    internal class DefaultConfigSettings : BindableBase, IConfigurationSettings
    {
        public ColourSchemeEnum ColourScheme { get; set; } = ColourSchemeEnum.Dark;
        public string AccentColour { get; set; } = "#FF9933";
    }
}
