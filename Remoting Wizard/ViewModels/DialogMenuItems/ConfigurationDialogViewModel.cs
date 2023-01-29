using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Remoting_Wizard.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting_Wizard.ViewModels.DialogMenuItems
{
    public class ConfigurationDialogViewModel : BindableBase, IDialogAware
    {
        #region Bindable Properties
        private ConfigurationSettings _Settings;
        public ConfigurationSettings Settings
        {
            get { return _Settings; }
            set { SetProperty(ref _Settings, value); }
        }

        #endregion

        #region Delegate Commands
        public DelegateCommand SaveSettingsCommand { get; private set; }

        #endregion

        #region Public Properties
        public string Title => "Preferences";
        #endregion

        #region Private Properties
        #endregion

        public ConfigurationDialogViewModel(ConfigurationSettings settings)
        {
            Settings = settings;
            SaveSettingsCommand = new DelegateCommand(SaveSettings);
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
        private void SaveSettings()
        {
            Properties.Settings.Default.ColourScheme = Settings.ColourScheme.ToString();
            Properties.Settings.Default.Save();
        }

        #endregion
    }
}
