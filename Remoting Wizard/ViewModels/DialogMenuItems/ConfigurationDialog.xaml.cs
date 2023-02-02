using Remoting_Wizard.Class;
using Remoting_Wizard.Configuration;
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

namespace Remoting_Wizard.ViewModels.DialogMenuItems
{
    /// <summary>
    /// Interaction logic for ConfigurationDialog.xaml
    /// </summary>
    public partial class ConfigurationDialog : UserControl
    {
        public ConfigurationDialog()
        {
            InitializeComponent();
            this.Loaded += MultiscreenRDP_Loaded;
        }

        private void MultiscreenRDP_Loaded(object sender, RoutedEventArgs e)
        {
            ColourSchemeComboBox.ItemsSource = Enum.GetValues(typeof(ColourSchemeEnum)).Cast<ColourSchemeEnum>();
            AfterConnectionComboBox.ItemsSource = Enum.GetValues(typeof(AfterConnectionActionEnum)).Cast<AfterConnectionActionEnum>();
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var VM = (ConfigurationDialogViewModel)this.DataContext;
            VM.AccentColourChangedCommand.Execute();
        }
    }
}
