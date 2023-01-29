using Prism;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using Remoting_Wizard.Class;
using Remoting_Wizard.Configuration;
using Remoting_Wizard.Properties;
using Remoting_Wizard.ViewModels;
using Remoting_Wizard.ViewModels.DialogMenuItems;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using ConfigurationSettings = Remoting_Wizard.Configuration.ConfigurationSettings;

namespace Remoting_Wizard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            MainWindow = shell;
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //_ConfigHelper = new ConfigHelper($@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\Remoting Wizard");
            containerRegistry.RegisterSingleton<ConfigPCs>();
            containerRegistry.RegisterSingleton<ConfigurationSettings>();

            containerRegistry.RegisterDialog<ConfigurePCs, ConfigurePCsViewModel>();
            containerRegistry.RegisterDialog<ConfigurationDialog, ConfigurationDialogViewModel>();
        }

        //public IRegionManager RegionManager { get; set; }

        protected override void Initialize()
        {
            SolidColorBrush test =(SolidColorBrush) this.Resources.MergedDictionaries[0]["SystemAccentColorBrush"];
            var temp = new SolidColorBrush(System.Windows.Media.Colors.HotPink);
            this.Resources.MergedDictionaries[0]["SystemAccentColorBrush"] = temp;
            var test2 = this.Resources.MergedDictionaries[0]["SystemAccentColorBrush"];


            base.Initialize();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;

            var settingsClass = Container.Resolve<ConfigurationSettings>();
            ReadAllSettings(settingsClass);

            //Add views to main window


            //NavigateShell(typeof(RestHandler));

            //Container.RegisterSingleton<CSV>();
            //Container.RegisterSingleton<AddPCPopUp>();

            var config = Container.Resolve<ConfigPCs>((typeof(List<PC>), CSV.ReadCSV()));
            config.PCs = new(CSV.ReadCSV());

            var regionManager = Container.Resolve<IRegionManager>();
            var mainContent = Container.Resolve<MultiscreenRDP>();
            var titleBar = Container.Resolve<CustomTitleBar>();
            _ = regionManager.AddToRegion("MainRegion", mainContent)
                             .AddToRegion("TitleBar", titleBar);
            MainWindow.WindowState = WindowState.Normal;
        }

        static void ReadAllSettings(ConfigurationSettings settings)
        {
            settings.ColourScheme = (ColourSchemeEnum) Enum.Parse(typeof(ColourSchemeEnum), Settings.Default.ColourScheme);
            //ConfigLocator.Load($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{Assembly.GetCallingAssembly().GetName().Name}\App.config");
        }
    }
}

