using Prism;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using Remoting_Wizard.Class;
using Remoting_Wizard.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Media;

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
            containerRegistry.RegisterSingleton<AddPCPopUp>();
            containerRegistry.RegisterSingleton<ConfigPCs>();
        }

        //public IRegionManager RegionManager { get; set; }

        protected override void Initialize()
        {
            base.Initialize();

            Application.Current.MainWindow.WindowState = WindowState.Maximized;

            var RegionManager = Container.Resolve<IRegionManager>();

            //Add views to main window
            var mainContent = Container.Resolve<MultiscreenRDP>();
            var titleBar = Container.Resolve<CustomTitleBar>();
            _ = RegionManager.AddToRegion("MainRegion", mainContent)
                             .AddToRegion("TitleBar", titleBar);


            //NavigateShell(typeof(RestHandler));

            //Container.RegisterSingleton<CSV>();
            //Container.RegisterSingleton<AddPCPopUp>();

            var config = Container.Resolve<ConfigPCs>();

            MainWindow.WindowState = WindowState.Normal;
        }
    }
}

