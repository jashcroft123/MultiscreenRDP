using JAStyles.Styles;
using Prism.Regions;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace JAWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShellWindow : JAWindow
    {
        /// <summary>
        /// The RegionManager that should be used for navigation within the shell
        /// </summary>
        public IRegionManager RegionManager { get; private set; }

        /// <summary>
        /// The main window of the application
        /// </summary>
        /// <param name="regionManager"></param>
        public ShellWindow(IRegionManager regionManager)
        {
            RegionManager = regionManager;
            InitializeComponent();
        }
   }
}