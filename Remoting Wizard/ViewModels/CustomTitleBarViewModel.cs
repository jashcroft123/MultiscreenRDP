using Prism.Commands;
using Prism.Mvvm;
using Remoting_Wizard.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Remoting_Wizard.ViewModels
{
    public class CustomTitleBarViewModel : BindableBase
    {
        #region Bindable Properties
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
        #endregion

        #region Public Properties

        #endregion

        #region Private Properties

        #endregion


        public CustomTitleBarViewModel()
        {
            CloseCommand = new DelegateCommand(Close);
            RestoreUpDownCommand = new DelegateCommand(RestoreUpDown);
            MinimiseCommand = new DelegateCommand(Minimise);

            Application.Current.MainWindow.StateChanged += MainWindow_StateChanged;
        }


        #region Private Methods
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
            Application.Current.MainWindow.Close();
        }
        private void RestoreUpDown()
        {
            Application.Current.MainWindow.WindowState = (Application.Current.MainWindow.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }
        private void Minimise()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        #endregion
    }
}
