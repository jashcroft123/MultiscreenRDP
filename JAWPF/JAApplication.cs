using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JAWPF
{
    public abstract class JAApplication : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            MainWindow = shell;
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //_ConfigHelper = new ConfigHelper($@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\Remoting Wizard");
            containerRegistry.RegisterSingleton<ApplicationColours>();
            JARegisterTypes();
        }

        protected virtual void JARegisterTypes() { }

        protected override void Initialize()
        {
            base.Initialize();

            Container.Resolve<ApplicationColours>();

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
            settings.ColourScheme = (ColourSchemeEnum)Enum.Parse(typeof(ColourSchemeEnum), Settings.Default.ColourScheme);
            settings.AccentColour = Settings.Default.AccentColour;
            settings.AfterConnectionAction = (AfterConnectionActionEnum)Enum.Parse(typeof(AfterConnectionActionEnum), Settings.Default.AfterConnectionAction);
        }
    }
}
