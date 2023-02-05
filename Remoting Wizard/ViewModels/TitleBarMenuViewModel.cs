using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Remoting_Wizard.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting_Wizard.ViewModels
{
    public class TitleBarMenuViewModel : BindableBase
    {
        #region Bindable Properties

        #endregion

        #region Delegate Commands
        public DelegateCommand OpenPCConfigCommand { get; private set; }
        public DelegateCommand PreferencesCommand { get; private set; }
        #endregion

        #region Public Properties

        #endregion

        #region Private Properties
        private DialogService _DialogService;
        private ConfigPCs _ConfigPCs;
        #endregion


        public TitleBarMenuViewModel(DialogService dialogService, ConfigPCs configPCs)
        {
            OpenPCConfigCommand = new DelegateCommand(OpenPCConfig);
            PreferencesCommand = new DelegateCommand(Preferences);

            _DialogService = dialogService;
            _ConfigPCs = configPCs;
        }


        #region Private Methods
        private void OpenPCConfig()
        {
            _DialogService.ShowDialog("ConfigurePCs");
            _ConfigPCs.PCs = new(CSV.ReadCSV());
        }
        private void Preferences()
        {
            _DialogService.ShowDialog("ConfigurationDialog");
        }
        #endregion
    }
}
