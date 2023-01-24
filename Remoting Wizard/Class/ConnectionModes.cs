using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting_Wizard.Class
{
    /// <summary>
    /// What the F is going on in here?? :'(
    /// </summary>
    public class ConnectionModes : BindableBase
    {
        private string _Mode;
        public string Mode
        {
            get { return _Mode; }
            set { SetProperty(ref _Mode, value); }
        }


        public ConnectionModes(string mode)
        {
            Mode = mode;
        }
    }
}
