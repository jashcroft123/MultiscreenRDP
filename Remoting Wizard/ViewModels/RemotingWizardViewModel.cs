using Microsoft.VisualBasic.FileIO;
using Prism.Commands;
using Prism.Common;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Remoting_Wizard.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static Remoting_Wizard.Class.Screen;

namespace Remoting_Wizard.ViewModels
{
    public class RemotingWizardViewModel : BindableBase
    {
        #region Delegates
        public DelegateCommand BtnRemoteConnect { get; set; }
        public DelegateCommand BtnCDriveConnect { get; set; }
        public DelegateCommand BtnConfig { get; set; }
        public DelegateCommand<int?> InsertRowPressed { get; set; }
        public DelegateCommand SavePressed { get; set; }
        public DelegateCommand EditPressed { get; set; }
        public DelegateCommand BtnRefresh { get; set; }
        public DelegateCommand PCSelected { get; set; }
        public DelegateCommand<object> DuplicateRowPressed { get; set; }
        #endregion

        #region Bindables
        private int _MaxHeight;
        public int MaxHeight
        {
            get { return _MaxHeight; }
            set { SetProperty(ref _MaxHeight, value); }
        }

        private int _MaxWidth;
        public int MaxWidth
        {
            get { return _MaxWidth; }
            set { SetProperty(ref _MaxWidth, value); }
        }


        private string _SelectedUserName;
        public string SelectedUserName
        {
            get { return _SelectedUserName; }
            set { SetProperty(ref _SelectedUserName, value); }
        }

        private ObservableCollection<string> _Usernames;
        public ObservableCollection<string> Usernames
        {
            get { return _Usernames; }
            set { SetProperty(ref _Usernames, value); }
        }

        private string _SelectedAlias;
        public string SelectedAlias
        {
            get { return _SelectedAlias; }
            set
            {
                SetProperty(ref _SelectedAlias, value);
                SelectedPCUpdate.Invoke(this, new EventArgs());
            }
        }

        private ObservableCollection<string> _Alias;
        public ObservableCollection<string> Alias
        {
            get
            {
                if (_Alias?.Count > 0)
                    return new ObservableCollection<string>(_Alias.Distinct());

                return _Alias;
            }
            set { SetProperty(ref _Alias, value); }
        }

        private ObservableCollection<ConnectionModes> _Modes;
        /// <summary>
        /// Mode Selection for UI Combobox
        /// </summary>
        public ObservableCollection<ConnectionModes> Modes
        {
            get { return _Modes; }
            set { SetProperty(ref _Modes, value); }
        }

        private ConnectionModes _SelectedMode;
        /// <summary>
        /// Mode Selection for UI Combobox
        /// </summary>
        public ConnectionModes SelectedMode
        {
            get { return _SelectedMode; }
            set { SetProperty(ref _SelectedMode, value); }
        }

        private ObservableCollection<Screen> _Screens;
        /// <summary>
        /// Screens to use for item control
        /// </summary>
        public ObservableCollection<Screen> Screens
        {
            get { return _Screens; }
            set { SetProperty(ref _Screens, value); }
        }

        private ConfigPCs _ConfigPCs;
        /// <summary>
        /// CSV Manager
        /// </summary>
        public ConfigPCs ConfigPCs
        {
            get { return _ConfigPCs; }
            set { SetProperty(ref _ConfigPCs, value); }
        }

        private int _PrimaryScreenID;
        public int PrimaryScreenID
        {
            get { return _PrimaryScreenID; }
            set { SetProperty(ref _PrimaryScreenID, value); }
        }

        private List<PC> _PCs;
        public List<PC> PCs
        {
            get { return _PCs; }
            set
            {
                _PCs = value;
                Alias = new ObservableCollection<string>(from x in PCs
                                                         select x.Alias);
            }
        }
        #endregion

        private PC SelectedPC
        {
            get
            {
                var temp = (from x in PCs
                            where x.Alias == SelectedAlias && x.UserID == SelectedUserName
                            select x).First();
                return temp;
            }
        }

        private EventHandler SelectedPCUpdate;

        public RemotingWizardViewModel(ConfigPCs configPCs)
        {
            ConfigPCs = configPCs;
            PCs = new List<PC>(ConfigPCs.PCs);

            BtnRemoteConnect = new DelegateCommand(async () => await BtnPCConnectPressed());
            BtnCDriveConnect = new DelegateCommand(async () => await BtnCDriveConnectPressed());
            BtnRefresh = new DelegateCommand(async () => await RefreshScreensPressed());
            SelectedPCUpdate += UpdateSelectedPC;


            InsertRowPressed = new DelegateCommand<int?>(async (i) => await InsertRow(i));
            SavePressed = new DelegateCommand(SaveCSV);
            DuplicateRowPressed = new DelegateCommand<object>(async (obj) => await DuplicateRow(obj));
            EditPressed = new DelegateCommand(async () => await EditRow());

            Modes = new ObservableCollection<ConnectionModes>();
            Modes.Add(new ConnectionModes("Remote Connection"));
            Modes.Add(new ConnectionModes("C-Drive"));

            ConfigPCs.PCs = new(CSV.ReadCSV());
            Screens = new();
            CurrentDisplays();
        }

        private void OpenFileExplorer(string Args)
        {
            System.Diagnostics.Process pro = new();

            pro.StartInfo.FileName = "explorer.exe";
            pro.StartInfo.Arguments = Args;

            pro.Start();
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private async Task BtnCDriveConnectPressed()
        {
            //Set user ID for login \\Uknml12329\c$
            OpenFileExplorer($@"\\{SelectedPC.Name}\C$");
        }

        private void UpdateSelectedPC(object sender, EventArgs args)
        {
            var temp = from x in PCs
                       where x.Alias == SelectedAlias
                       select x.UserID;

            Usernames = new ObservableCollection<string>(temp);
        }

        private async Task BtnPCConnectPressed()
        {
            //get selected pc details
            var selectedPC = ConfigPCs.Selected;

            //Get selected screens
            List<Screen> SelectedScreens = new(Screens.Where(x => x.Selected.Equals(true)));
            SelectedScreens = SelectedScreens.OrderBy(x => x.SelectedPrimary != true).ToList();
            string s = "session bpp:i:32 " +
                        " rdgiskdcproxy:i:0 " +
                        "kdcproxyname:s: " +
                        "drivestoredirect:s: " +
                        "screen mode id:i:2";

            //string rdpBasePath = AppDomain.CurrentDomain.BaseDirectory + @"Data\RemoteConnection";
            StringBuilder rdpSB = new();

            //Build RDP script
            rdpSB.AppendLine($"full address:s:{selectedPC.Name}");
            //string RDPTemplate = string.Format(File.ReadAllText(rdpBasePath + "template.txt"));
            rdpSB.AppendLine(s);
            rdpSB.AppendLine($"username: s: {selectedPC.UserID}");
            rdpSB.AppendLine($"use multimon:i:{Convert.ToInt32(SelectedScreens.Count > 1)}");

            string joinedIDs = string.Join(",", SelectedScreens.Select(x => x.ID));
            rdpSB.AppendLine($"selectedmonitors:s:{joinedIDs}");

            //Save RDP and connect
            string rDPPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\Remoting Wizard";

            DirectoryInfo directoryInfo = new DirectoryInfo(rDPPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            File.WriteAllText($@"{rDPPath}\Connection.RDP", rdpSB.ToString());
            await RunCMDCommand($"/C mstsc \"{rDPPath}\\Connection.RDP\"");

            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private async Task RefreshScreensPressed()
        {
            RegisterRightClick(false);
            await CurrentDisplays();
        }

        public async Task DuplicateRow(object row)
        {
            var newRow = ((int index, PC pc))row;
            ConfigPCs.PCs.Insert(newRow.index + 1,
                             new PC(newRow.pc.Alias, newRow.pc.Name, newRow.pc.UserID)); //add blank row to data grid
        }

        private async Task InsertRow(int? index)
        {
            if (index.Value < 0)
            {
                index = 0;
            }
            ConfigPCs.PCs.Insert(index.Value, new PC(string.Empty, string.Empty, string.Empty));
        }

        private async Task EditRow()
        {
            var window = ContainerLocator.Current.Resolve<AddPCPopUp>();
            //if (window != null)
            //{
            //    MvvmHelpers.AutowireViewModel(window);
            //    RegionManager.SetRegionManager(window, _containerExtension.Resolve<IRegionManager>());
            //    RegionManager.UpdateRegions();
            //    InitializeShell(shell);
            //}
            window.Show();
            var RegionManager = ContainerLocator.Current.Resolve<IRegionManager>();

            TaskCompletionSource tcs = new TaskCompletionSource();
            window.Closed += (s, e) => tcs.TrySetResult();

            await tcs.Task;
            SaveCSV();
        }

        public void DeleteRow(int index)
        {
            ConfigPCs.PCs.RemoveAt(index);
            SaveCSV();
        }

        private void SaveCSV()
        {
            CSV.ExportCsv(new List<PC>(ConfigPCs.PCs));
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

        private async Task CurrentDisplays()
        {
            Screens.Clear();
            int trueBottom = (int)Monitor.AllMonitors.Min(x => x.Bounds.Top); //Bottom and top are flipped from Monitor
            int trueLeft = (int)Monitor.AllMonitors.Min(x => x.Bounds.Left);

            foreach (Monitor monitor in Monitor.AllMonitors)
            {
                //Get monitor ID and put into the format that would be output cmd from "mstsc /l"
                int ID = int.Parse(Regex.Match(monitor.Name, @"\d+").Value) - 1;

                //For each monitor avaliable get width height and bottom left corner location
                Screens.Add(new Screen(
                    ID, (int)monitor.Bounds.Width, (int)monitor.Bounds.Height, (int)monitor.Bounds.X + Math.Abs(trueLeft),
                    (int)monitor.Bounds.Y + Math.Abs(trueBottom), (int)Math.Abs(monitor.Bounds.Bottom) + Math.Abs(trueBottom),
                    (int)monitor.Bounds.Right + Math.Abs(trueLeft), false, monitor.IsPrimary)
                    );
            }
            Screens = new ObservableCollection<Screen>(Screens.OrderBy(x => x.LeftLocation));

            MaxHeight = Screens.Max(x => x.TopLocation);
            MaxWidth = Screens.Max(x => x.RightLocation);

            RegisterRightClick();
        }

        private void RightClicked(object sender, RightClickArg e)
        {
            //CurrentDisplays();
            PrimaryScreenID = e.SenderID;
            Screens.Where(x => x.ID == e.SenderID).FirstOrDefault().Selected = true;

            foreach (Screen screen in Screens)
            {
                screen.SelectedPrimary = screen.ID == e.SenderID;

            }
        }

        private void RegisterRightClick(bool register = true)
        {
            foreach (Screen screen in Screens)
            {
                if (register)
                    screen.ScreenRightClick += RightClicked;
                else
                    screen.ScreenRightClick -= RightClicked;
            }
        }
    }
}