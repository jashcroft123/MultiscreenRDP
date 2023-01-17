using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting_Wizard.Class
{
    public class ConfigPCs : BindableBase
    {
        private PC _Selected;
        public PC Selected
        {
            get { return _Selected; }
            set { SetProperty(ref _Selected, value); }
        }

        private ObservableCollection<PC> _PCs;
        public ObservableCollection<PC> PCs
        {
            get { return _PCs; }
            set { SetProperty(ref _PCs, value); }
        }


        public ConfigPCs(List<PC> list)
        {
            PCs = new ObservableCollection<PC>(list);
        }
    }
}
