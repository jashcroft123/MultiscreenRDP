using CsvHelper.Configuration.Attributes;
using Prism.Commands;
using Prism.Mvvm;
using Remoting_Wizard.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Remoting_Wizard.ViewModels
{
    public class MultiscreenRDPViewModel : BindableBase
    {
        #region Bindable Properties
        private Monitors _Monitors = new Monitors();
        public Monitors Monitors
        {
            get { return _Monitors; }
            set { SetProperty(ref _Monitors, value); }
        }
        #endregion

        #region Delegate Commands
        public DelegateCommand RemoteConnectCommand { get; private set; }

        #endregion

        #region Public Properties
        public ConfigPCs ConfigPCs { get; set; }
        public double MaxWidth { get; set; }
        public double MaxHeight { get; set; }
        #endregion

        #region Private Properties
        #endregion


        public MultiscreenRDPViewModel(ConfigPCs configPCs)
        {
            ConfigPCs = configPCs;

            RemoteConnectCommand = new DelegateCommand(async () => await RemoteConnect());
            //Screens = new ObservableCollection<Monitor>(Monitor.AllMonitors);
        }


        #region Private Methods
        private async Task RemoteConnect()
        {
            //var selectedPC = ConfigPCs.Selected;

            ////default rdp connection
            //string joinedIDs = string.Join(",", SelectedScreens.Select(x => x.ID));
            //string s = "full address:s:{selectedPC.Name}" +
            //            $"username: s: {selectedPC.UserID}" +
            //            "session bpp:i:32" +
            //            " rdgiskdcproxy:i:0 " +
            //            "kdcproxyname:s:" +
            //            "drivestoredirect:s:" +
            //            "screen mode id:i:2" +
            //            $"use multimon:i:{Convert.ToInt32(SelectedScreens.Count > 1)}" +
            //            $"selectedmonitors:s:{joinedIDs}";

            ////Save RDP and connect
            //string rDPPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\Remoting Wizard";

            //if (!Directory.Exists(Path.GetDirectoryName(rDPPath))) Directory.CreateDirectory(Path.GetDirectoryName(rDPPath));

            //File.WriteAllText($@"{rDPPath}\Connection.RDP", s);
            //await RunCMDCommand($"/C mstsc \"{rDPPath}\\Connection.RDP\"");

        }

        private async Task CurrentDisplays()
        {
            //Screens.Clear();
            //int trueBottom = (int)Monitor.AllMonitors.Min(x => x.Bounds.Top); //Bottom and top are flipped from Monitor
            //int trueLeft = (int)Monitor.AllMonitors.Min(x => x.Bounds.Left);

            //foreach (Monitor monitor in Monitor.AllMonitors)
            //{
            //    //Get monitor ID and put into the format that would be output cmd from "mstsc /l"
            //    int ID = int.Parse(Regex.Match(monitor.Name, @"\d+").Value) - 1;

            //    //For each monitor avaliable get width height and bottom left corner location
            //    Screens.Add(new Screen(
            //        ID, (int)monitor.Bounds.Width, (int)monitor.Bounds.Height, (int)monitor.Bounds.X + Math.Abs(trueLeft),
            //        (int)monitor.Bounds.Y + Math.Abs(trueBottom), (int)Math.Abs(monitor.Bounds.Bottom) + Math.Abs(trueBottom),
            //        (int)monitor.Bounds.Right + Math.Abs(trueLeft), false, monitor.IsPrimary)
            //        );
            //}
            //Screens = new ObservableCollection<Screen>(Screens.OrderBy(x => x.LeftLocation));

            //MaxHeight = Screens.Max(x => x.TopLocation);
            //MaxWidth = Screens.Max(x => x.RightLocation);

            //RegisterRightClick();
        }

        private async Task RunCMDCommand(string Args)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.Arguments = Args;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;

            await Task.Run(p.Start);

            p.StandardInput.Flush();
            p.StandardInput.Close();
        }
        #endregion
    }
}
