using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Remoting_Wizard.Class;
using Remoting_Wizard.Styles;
using Remoting_Wizard.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Remoting_Wizard.Archive
{
    public class AddPCPopUpViewModel : BindableBase
    {
        #region Bindable Properties
        private ConfigPCs _ConfigPCs;
        public ConfigPCs ConfigPCs
        {
            get { return _ConfigPCs; }
            set { SetProperty(ref _ConfigPCs, value); }
        }

        private bool _WindowMaximised;
        public bool WindowMaximised
        {
            get { return _WindowMaximised; }
            set { SetProperty(ref _WindowMaximised, value); }
        }

        private string _BackgroundColour;
        public string BackgroundColour
        {
            get { return _BackgroundColour; }
            set { SetProperty(ref _BackgroundColour, value); }
        }
        #endregion

        #region Delegate Commands
        public DelegateCommand CloseCommand { get; private set; }
        public DelegateCommand RestoreUpDownCommand { get; private set; }
        public DelegateCommand MinimiseCommand { get; private set; }

        public DelegateCommand SaveAndCloseCommand { get; private set; }
        #endregion

        #region Public Properties
        #endregion

        #region Private Properties
        #endregion


        public AddPCPopUpViewModel(ConfigPCs pCs, IContainerExtension container)
        {
            ConfigPCs = pCs;

            SaveAndCloseCommand = new DelegateCommand(SaveAndClose);

            CloseCommand = new DelegateCommand(Close);
            RestoreUpDownCommand = new DelegateCommand(RestoreUpDown);
            MinimiseCommand = new DelegateCommand(Minimise);

            Application.Current.MainWindow.StateChanged += MainWindow_StateChanged;
            WindowSizeChange();
        }

        #region Private Methods
        private void SaveAndClose()
        {
            var window = ContainerLocator.Current.Resolve<AddPCPopUp>();
            window.Close();
        }

        private void MainWindow_StateChanged(object? sender, EventArgs e)
        {
            WindowSizeChange();
        }

        private void WindowSizeChange()
        {
            WindowMaximised = Application.Current.MainWindow.WindowState == WindowState.Maximized;
            BackgroundColour = Application.Current.MainWindow.WindowState == WindowState.Maximized ? DarkThemeColours.BackgroundBrush : DarkThemeColours.BackgroundLight1Brush;
        }
        private void Close()
        {
            var test = Application.Current.Windows;
            test.OfType<AddPCPopUp>().First().Close();
        }
        private void RestoreUpDown()
        {
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }
        private void Minimise()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        #endregion
    }
}
