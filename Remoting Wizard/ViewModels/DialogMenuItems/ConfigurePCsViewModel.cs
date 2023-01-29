using Prism.Mvvm;
using Prism.Services.Dialogs;
using Remoting_Wizard.Class;
using System;

namespace Remoting_Wizard.ViewModels.DialogMenuItems
{
    public class ConfigurePCsViewModel : BindableBase, IDialogAware
    {
        #region Bindable Properties

        #endregion

        #region Delegate Commands

        #endregion

        #region Public Properties
        public ConfigPCs ConfigPCs { get; set; }
        public string Title => throw new NotImplementedException();
        #endregion

        #region Private Properties
        #endregion



        public ConfigurePCsViewModel(ConfigPCs configPCs)
        {
            ConfigPCs = configPCs;
        }


        protected void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
                result = ButtonResult.OK;
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.Cancel;

            RaiseRequestClose(new DialogResult(result));
        }

        public event Action<IDialogResult> RequestClose;
        public void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        #region Private Methods

        #endregion
    }
}
