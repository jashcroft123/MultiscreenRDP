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
            containerRegistry.RegisterSingleton<ApplicationColours>();
            containerRegistry.RegisterSingleton<ConfigurationSettings>();

            containerRegistry.RegisterDialog<ConfigurePCs, ConfigurePCsViewModel>();
            containerRegistry.RegisterDialog<ConfigurationDialog, ConfigurationDialogViewModel>();
        }

        protected override void Initialize()
        {
            base.Initialize();

            Container.Resolve<ApplicationColours>();

            var settingsClass = Container.Resolve<ConfigurationSettings>();
            ReadAllSettings(settingsClass);

            var config = Container.Resolve<ConfigPCs>((typeof(List<PC>), CSV.ReadCSV()));
            config.PCs = new(CSV.ReadCSV());

            //Add views to main window
            var regionManager = Container.Resolve<IRegionManager>();
            var mainContent = Container.Resolve<MultiscreenRDP>();
            var titleBar = Container.Resolve<CustomTitleBar>();
            var titleBarMenu = Container.Resolve<TitleBarMenu>();
            _ = regionManager.AddToRegion("MainRegion", mainContent)
                             .AddToRegion("TitleBar", titleBar)
                             .AddToRegion("TitleBarContentLeft", titleBarMenu);
        }

        static void ReadAllSettings(ConfigurationSettings settings)
        {
            //read all settings into local class that we can manipulate
            settings.ColourScheme = (ColourSchemeEnum) Enum.Parse(typeof(ColourSchemeEnum), Settings.Default.ColourScheme);
            settings.AccentColour =  Settings.Default.AccentColour;
            settings.AfterConnectionAction = (AfterConnectionActionEnum) Enum.Parse(typeof(AfterConnectionActionEnum), Settings.Default.AfterConnectionAction);
        }
    }
}

