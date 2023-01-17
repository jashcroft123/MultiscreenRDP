using Prism.Commands;
using Prism.Mvvm;
using Remoting_Wizard.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Remoting_Wizard.ViewModels
{
    public class RemoteFilesViewModel : BindableBase
    {
        //#region Ctor
        //public RemoteFilesViewModel(ProcessController processController)
        //{
        //    BtnConnect = new DelegateCommand(BtnConnectPressed);

        //    ComboBox = new ObservableCollection<PC>(CSV.ReadCSV(CSV.FILE_PATH) as List<PC>);
        //}

        //public DelegateCommand BtnConnect { get; set; }
        //#endregion

        //#region Functions
        //private void BtnConnectPressed()
        //{
        //    PC SelectedPC = new(SelectedComboBox.Alias, SelectedComboBox.Name, SelectedComboBox.UserID);

        //    //Set user ID for login \\Uknml12329\c$
        //    OpenFileExplorer($"\\\\{ SelectedPC.Name}\\C$");
        //}

        //private void OpenFileExplorer(string Args)
        //{
        //    System.Diagnostics.Process p = new System.Diagnostics.Process();

        //    p.StartInfo.FileName = "explorer.exe";
        //    p.StartInfo.Arguments = Args;

        //    p.Start();
        //}
        //#endregion
    }
}