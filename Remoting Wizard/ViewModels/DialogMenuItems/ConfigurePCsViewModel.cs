using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Remoting_Wizard.Class;
using System;
using System.Linq;
using System.Reflection.Metadata;

namespace Remoting_Wizard.ViewModels.DialogMenuItems
{
    public class ConfigurePCsViewModel : BindableBase, IDialogAware
    {
        #region Bindable Properties

        #endregion

        #region Delegate Commands
        public DelegateCommand CloseCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand AddRowCommand { get; private set; }
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

            CloseCommand = new DelegateCommand(Close);
            SaveCommand = new DelegateCommand(Save);
            AddRowCommand = new DelegateCommand(AddRow);
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
        public void OnDialogClosed()
        {

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

        #region Private Methods
        private void Close()
        {
            RaiseRequestClose(new DialogResult());
        }
        private void Save()
        {
            CSV.ExportCsv(ConfigPCs.PCs.ToList());
            RaiseRequestClose(new DialogResult());
        }
        private void AddRow()
        {
            ConfigPCs.PCs.Add(new PC());
        }
        #endregion
    }
}
