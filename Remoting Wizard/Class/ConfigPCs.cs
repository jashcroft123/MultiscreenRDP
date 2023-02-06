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

        #region Bindable Properties
        private PC _Selected;
        public PC Selected
        {
            get { return _Selected; }
            set { SetProperty(ref _Selected, value); }
        }

        private ObservableCollection<PC> _PCs;
        public ObservableCollection<PC> PCs
        {
            get { return new ObservableCollection<PC>(_PCs.OrderBy(x => x.Alias)); }
            set { SetProperty(ref _PCs, value); }
        }

        private ObservableCollection<string> _DistinctAliases;
        public ObservableCollection<string> DistinctAliases
        {
            get { return _DistinctAliases; }
            set { SetProperty(ref _DistinctAliases, value); }
        }
        private string _SelectedAlias;
        public string SelectedAlias
        {
            get { return _SelectedAlias; }
            set { SetProperty(ref _SelectedAlias, value); }
        }


        private ObservableCollection<string> _UserNames;
        public ObservableCollection<string> UserNames
        {
            get { return _UserNames; }
            set { SetProperty(ref _UserNames, value); }
        }
        private string _SelectedUserName;
        public string SelectedUserName
        {
            get { return _SelectedUserName; }
            set { SetProperty(ref _SelectedUserName, value); }
        }
        #endregion

        #region Public Properties

        #endregion

        #region Private Properties

        #endregion



        public ConfigPCs(List<PC> list)
        {
            PCs = new ObservableCollection<PC>(list);

            this.PropertyChanged += ConfigPCs_PropertyChanged;
        }

        #region Private Properties
        private void ConfigPCs_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PCs) || e.PropertyName == nameof(Selected))
            {
                DistinctAliases = new ObservableCollection<string>(PCs.Select(x => x.Alias).Distinct());
            }
            if (e.PropertyName == nameof(SelectedAlias))
            {
                //get all the user names for the selected Alias from the list of PCs
                UserNames = new ObservableCollection<string>(PCs.Where(x => x.Alias == SelectedAlias).Select(x => x.UserID));
                SelectedUserName = UserNames[0];
            }
            if (e.PropertyName == nameof(SelectedUserName))
            {
                var pcName = PCs.First(x => x.Alias == SelectedAlias).Name;
                Selected = PCs.First(x => x.UserID == SelectedUserName && x.Name == pcName);
            }
        }
        #endregion
    }
}
