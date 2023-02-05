using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Remoting_Wizard.Class;
using Remoting_Wizard.Configuration;
using Remoting_Wizard.Properties;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using ConfigurationSettings = Remoting_Wizard.Configuration.ConfigurationSettings;

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
        public DelegateCommand RefreshMontiorsCommand { get; private set; }
        #endregion

        #region Public Properties
        public ConfigPCs ConfigPCs { get; set; }
        public double MaxWidth { get; set; }
        public double MaxHeight { get; set; }
        #endregion

        #region Private Properties
        IDialogService _DialogService;
        ConfigurationSettings _ConfigurationSettings;
        #endregion

        public MultiscreenRDPViewModel(ConfigPCs configPCs, IDialogService dialogService, ConfigurationSettings configurationSettings)
        {
            ConfigPCs = configPCs;
            _DialogService = dialogService;
            _ConfigurationSettings = configurationSettings;


            RemoteConnectCommand = new DelegateCommand(async () => await RemoteConnect());
            RefreshMontiorsCommand = new DelegateCommand(RefreshMontiors);

            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }

        #region Private Methods
        private async Task RemoteConnect()
        {
            var selectedPC = ConfigPCs.Selected;
            var selectedScreens = Monitors.Where(x => x.Selected).ToList();
            //default rdp connection
            string joinedIDs = string.Join(",", selectedScreens.Select(x => x.Name));
            string s = $"full address:s:{selectedPC.Name} " +
                        $"username: s: {selectedPC.UserID} " +
                        "session bpp:i:32 " +
                        " rdgiskdcproxy:i:0 " +
                        "kdcproxyname:s: " +
                        "drivestoredirect:s: " +
                        "screen mode id:i:2 " +
                        $"use multimon:i:{Convert.ToInt32(selectedScreens.Count > 1)} " +
                        $"selectedmonitors:s:{joinedIDs} ";

            //Save RDP and connect
            string rDPPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\Remoting Wizard";

            if (!Directory.Exists(Path.GetDirectoryName(rDPPath))) Directory.CreateDirectory(Path.GetDirectoryName(rDPPath));

            File.WriteAllText($@"{rDPPath}\Connection.RDP", s);
            await RunCMDCommand($"/C mstsc \"{rDPPath}\\Connection.RDP\"");
            
            var action = (AfterConnectionActionEnum)Enum.Parse(typeof(AfterConnectionActionEnum), Settings.Default.AfterConnectionAction);
            switch (action)
            {
                case AfterConnectionActionEnum.Minimise:
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                    break;
                case AfterConnectionActionEnum.Shutdown:
                    Application.Current.Shutdown();
                    break;
            }
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

        private void RefreshMontiors()
        {
            Monitors = new Monitors();
        }
        private void SystemEvents_DisplaySettingsChanged(object? sender, EventArgs e)
        {
            Monitors = new Monitors();
        }
        #endregion
    }
}
