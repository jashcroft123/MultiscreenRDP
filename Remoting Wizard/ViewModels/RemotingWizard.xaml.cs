using Remoting_Wizard.Class;
using Remoting_Wizard.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Remoting_Wizard.ViewModels
{
    /// <summary>
    /// Interaction logic for RemotingWizard.xaml
    /// </summary>
    public partial class RemotingWizard : UserControl
    {
        public RemotingWizard()
        {
            InitializeComponent();
        }

        //private void Insert_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var vm = (RemotingWizardViewModel)this.DataContext;
        //    vm.InsertRowPressed.Execute(ConfigData.SelectedIndex);
        //}

        //private void Duplicate_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var vm = (RemotingWizardViewModel)this.DataContext;
        //    (int, PC) temp = (ConfigData.SelectedIndex, (PC)ConfigData.SelectedItem);
        //    vm.DuplicateRowPressed.Execute(temp);
        //}

        //private void Edit_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var temp = ConfigData.SelectedItem as PC;
        //    var vm = (RemotingWizardViewModel)this.DataContext;
        //    vm.EditPressed.Execute();
        //}

        //private void DeleteRow_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var vm = (RemotingWizardViewModel)this.DataContext;
        //    vm.DeleteRow(ConfigData.SelectedIndex);
        //}
    }
}
