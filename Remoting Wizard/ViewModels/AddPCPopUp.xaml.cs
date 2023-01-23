﻿using Prism.Regions;
using Remoting_Wizard.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Remoting_Wizard.ViewModels
{
    /// <summary>
    /// Interaction logic for AddPCPopUp.xaml
    /// </summary>
    public partial class AddPCPopUp : JAWindow
    {
        private IRegionManager _RegionManager { get; set; }

        public AddPCPopUp(IRegionManager regionManager)
        {
            _RegionManager = regionManager;
            InitializeComponent();
            //this.Topmost = true;
        }
    }
}
