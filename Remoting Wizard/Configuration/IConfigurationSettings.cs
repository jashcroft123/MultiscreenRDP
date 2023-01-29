using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting_Wizard.Configuration
{
    /// <summary>
    /// Used to ensure that the default implements all properties
    /// </summary>
    internal interface IConfigurationSettings
    {
        public ColourSchemeEnum ColourScheme { get; set; }
        public string AccentColour { get; set; }


    }
}
