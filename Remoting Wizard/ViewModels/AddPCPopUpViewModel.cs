using Prism.Commands;
using Remoting_Wizard.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Mvvm;

namespace Remoting_Wizard.ViewModels
{
    public class AddPCPopUpViewModel : BindableBase
    {
        #region Bindable Properties
        private ConfigPCs _ConfigPCs;
        public ConfigPCs ConfigPCs
        {
            get { return _ConfigPCs; }
            set { SetProperty(ref _ConfigPCs, value); }
        }

        #endregion

        #region Delegate Commands
        public DelegateCommand SaveAndCloseCommand { get; private set; }
        #endregion

        #region Public Properties
        #endregion

        #region Private Properties
        #endregion


        public AddPCPopUpViewModel(ConfigPCs pCs)
        {
            ConfigPCs = pCs;

            SaveAndCloseCommand = new DelegateCommand(SaveAndClose);
        }

        #region Private Methods
        private void SaveAndClose()
        {
            var window = ContainerLocator.Current.Resolve<AddPCPopUp>();
            window.Close();
        }
        #endregion
    }
}
