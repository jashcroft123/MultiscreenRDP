using Prism.Commands;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Remoting_Wizard.Class
{
    public class Monitors : ObservableCollection<Monitor>
    {

        #region Bindable Properties

        #endregion

        #region Public Properties
        public double CollectionWidth { get; set; }
        public double CollectionHeight { get; set; }
        #endregion

        #region Private Properties

        #endregion

        #region Delegates
        public DelegateCommand<string> RightClickCommand { get; private set; }
        #endregion



        public Monitors()
        {
            foreach (Monitor monitor in Monitor.AllMonitors)
            {
                this.Add(monitor);
            }
            CollectionWidth = this.Max(x => x.Bounds.Right);
            CollectionHeight = this.Max(x => x.Bounds.Bottom);

            RightClickCommand = new DelegateCommand<string>(RightClick);
        }

        private void RightClick(string senderMonitorName)
        {
            foreach(Monitor monitor in this)
            {
                monitor.SelectedPrimary = senderMonitorName == monitor.Name;
                if(senderMonitorName == monitor.Name)
                {
                    monitor.Selected = true;
                }
            }
        }
    }
}
