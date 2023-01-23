using Remoting_Wizard;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace Remoting_Wizard.Styles
{
    public partial class JAWindow : Window
    {
        private Thickness _OriginalThickness;

        public JAWindow()
        {
            this.StateChanged += MainWindow_StateChanged;
            this.Loaded += JAWindow_Loaded;
        }

        private void JAWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _OriginalThickness = this.BorderThickness;
        }

        /// <summary>
        /// Work around for WPF not sizing correctly when maximised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_StateChanged(object? sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new System.Windows.Thickness(8); //crop in 8 pxs
            }
            else
            {
                this.BorderThickness = _OriginalThickness;
            }
        }
    }
}







