using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Remoting_Wizard.Class
{
    /// <summary>
    /// Remote PC's Details
    /// </summary>
    public class Screen : BindableBase
    {
        /// <summary>
        /// ID of the Screen
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Location of Left most pixel
        /// </summary>
        private int _LeftLocation;
        public int LeftLocation
        {
            get { return _LeftLocation; }
            set { SetProperty(ref _LeftLocation, value); }
        }

        private int _BottomLocation;
        public int BottomLocation
        {
            get { return _BottomLocation; }
            set { SetProperty(ref _BottomLocation, value); }
        }

        private int _TopLocation;
        public int TopLocation
        {
            get { return _TopLocation; }
            set { SetProperty(ref _TopLocation, value); }
        }

        private int _RightLocation;
        public int RightLocation
        {
            get { return _RightLocation; }
            set { SetProperty(ref _RightLocation, value); }
        }


        public string Margin { get; private set; }

        private int _Width;
        /// <summary>
        /// Width of Monitor in PX
        /// </summary>
        public int Width
        {
            get { return _Width; }
            set { SetProperty(ref _Width, value); }
        }

        private int _Height;
        /// <summary>
        /// Height of Monitor in PX
        /// </summary>
        public int Height
        {
            get { return _Height; }
            set { SetProperty(ref _Height, value); }
        }


        /// <summary>
        /// Primary Monitor
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Double Clicked to be Primary Monitor
        /// </summary>
        private bool _SelectedPrimary;
        public bool SelectedPrimary
        {
            get { return _SelectedPrimary; }
            set { SetProperty(ref _SelectedPrimary, value); }
        }

        /// <summary>
        /// Is the Screen selected in the UI
        /// </summary>
        private bool _Selected;
        public bool Selected
        {
            get { return _Selected; }
            set { SetProperty(ref _Selected, value); }
        }

        public class RightClickArg : EventArgs
        {
            public int SenderID;
            public RightClickArg(int iD)
            {
                SenderID = iD;
            }
        };

        public EventHandler<RightClickArg> ScreenRightClick { get; set; }

        public DelegateCommand RightClick { get; private set; }

        private async Task RightClickScreen()
        {
            if (ScreenRightClick is not null)
            {
                RightClickArg doubleClickArg = new RightClickArg(ID);
                ScreenRightClick.Invoke(this, doubleClickArg);
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="_ID">ID of the screen</param>
        /// <param name="_width">Width of display in pixels</param>
        /// <param name="_height">Height of display in pixels</param>
        /// <param name="_leftStartLocation">Location of Left most pixel</param>
        /// <param name="_bottomStartLocation">Location of Bottom pixel</param>
        /// <param name="_selected">Is the screen selected</param>
        public Screen(int _ID, int _width, int _height, int _leftStartLocation, int _bottomStartLocation, int _topLocation, int _rightLocation, bool _selected, bool _primary)
        {
            RightClick = new DelegateCommand(async () => await RightClickScreen());

            int scale = 10;

            ID = _ID;
            Width = _width / scale;
            Height = _height / scale;
            LeftLocation = _leftStartLocation / scale;
            BottomLocation = _bottomStartLocation / scale;
            TopLocation = _topLocation / scale;
            RightLocation = _rightLocation / scale;

            Margin = $"{LeftLocation}, {BottomLocation} , 0, 0";
            IsPrimary = _primary;
        }
    }
}
