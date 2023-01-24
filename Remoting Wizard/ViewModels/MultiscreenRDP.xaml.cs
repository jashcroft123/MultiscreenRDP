using Remoting_Wizard.Class;
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
    /// Interaction logic for MultiscreenRDP.xaml
    /// </summary>
    public partial class MultiscreenRDP : UserControl
    {
        public MultiscreenRDP()
        {
            InitializeComponent();
            this.Loaded += MultiscreenRDP_Loaded;
            ModeComboBox.SelectionChanged += ModeComboBox_SelectionChanged;
        }

        private void ModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void MultiscreenRDP_Loaded(object sender, RoutedEventArgs e)
        {
            ModeComboBox.ItemsSource = Enum.GetValues(typeof(Modes)).Cast<Modes>();
        }
    }
}
