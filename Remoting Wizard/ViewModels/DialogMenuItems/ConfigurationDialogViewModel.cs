using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Remoting_Wizard.Class;
using Remoting_Wizard.Configuration;
using Remoting_Wizard.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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

        private AfterConnectionActionEnum _AfterConnectionActionEnum;
        public AfterConnectionActionEnum AfterConnectionActionEnum
        {
            get { return _AfterConnectionActionEnum; }
            set
            {
                SetProperty(ref _AfterConnectionActionEnum, value);
                Settings.AfterConnectionAction = value;
            }
        }

        #endregion

        #region Delegate Commands
        public DelegateCommand SaveSettingsCommand { get; private set; }
        public DelegateCommand AccentColourChangedCommand { get; private set; }
        #endregion

        #region Public Properties
        public string Title => "Preferences";
        #endregion

        #region Private Properties
        private ApplicationColours _Colours;
        #endregion

        public ConfigurationDialogViewModel(ConfigurationSettings settings, ApplicationColours colours)
        {
            _Colours = colours;
            Settings = settings;
            SaveSettingsCommand = new DelegateCommand(SaveSettings);
            AccentColourChangedCommand = new DelegateCommand(AccentColourChanged);
        }


        public event Action<IDialogResult> RequestClose;
        public void RaiseRequestClose(IDialogResult dialogResult = null)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            _Colours.SystemAccentColor = (Color)ColorConverter.ConvertFromString(Properties.Settings.Default.AccentColour);
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        #region Private Methods
        private void AccentColourChanged()
        {
            _Colours.SystemAccentColor = (Color)ColorConverter.ConvertFromString(Settings.AccentColour);
        }

        private void SaveSettings()
        {
            //set all the remote settings by reflection from the local settings
            var localProps = Settings.GetType().GetProperties();

            var remoteProps = Properties.Settings.Default.GetType().GetProperties().ToList();

            foreach (var property in localProps)
            {
                var propVal = property.GetValue(Settings);
                var propName = property.Name;

                var propToSet = remoteProps.FirstOrDefault(x => x.Name == propName);

                propToSet?.SetValue(Properties.Settings.Default, Convert.ChangeType(propVal, propToSet.PropertyType));
            }

            Properties.Settings.Default.Save();
            RaiseRequestClose();
        }
        #endregion
    }
}
