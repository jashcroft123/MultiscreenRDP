using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;

namespace Remoting_Wizard.Class
{
    public class Monitor : BindableBase
    {
        #region Dll imports

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        private static extern bool GetMonitorInfo
                        (HandleRef hmonitor, [In, Out] MonitorInfoEx info);

        [DllImport("user32.dll", ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        private static extern bool EnumDisplayMonitors(HandleRef hdc, IntPtr rcClip, MonitorEnumProc lpfnEnum, IntPtr dwData);

        private delegate bool MonitorEnumProc(IntPtr monitor, IntPtr hdc, IntPtr lprcMonitor, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        private class MonitorInfoEx
        {
            internal int cbSize = Marshal.SizeOf(typeof(MonitorInfoEx));
            internal Rect rcMonitor = new Rect();
            internal Rect rcWork = new Rect();
            internal int dwFlags = 0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            internal char[] szDevice = new char[32];
        }

        private const int MonitorinfofPrimary = 0x00000001;

        #endregion

        public static HandleRef NullHandleRef = new HandleRef(null, IntPtr.Zero);

        public System.Windows.Rect Bounds { get; private set; }
        public System.Windows.Rect WorkingArea { get; private set; }


        #region Bindable Properties
        private bool _SelectedPrimary;
        public bool SelectedPrimary
        {
            get { return _SelectedPrimary; }
            set { SetProperty(ref _SelectedPrimary, value); }
        }

        private bool _Selected;
        public bool Selected
        {
            get { return _Selected; }
            set { SetProperty(ref _Selected, value); }
        }
        #endregion

        #region Public Properties
        public string Name { get; private set; }
        #endregion

        #region Private Properties

        #endregion

        /// <summary>
        /// Set in dll by callback ref
        /// </summary>
        /// <param name="monitor"></param>
        /// <param name="hdc"></param>
        private Monitor(IntPtr monitor, IntPtr hdc)
        {
            var info = new MonitorInfoEx();
            GetMonitorInfo(new HandleRef(null, monitor), info);
            Bounds = new System.Windows.Rect(
                        info.rcMonitor.left, info.rcMonitor.top,
                        info.rcMonitor.right - info.rcMonitor.left,
                        info.rcMonitor.bottom - info.rcMonitor.top);

            WorkingArea = new System.Windows.Rect(
                        info.rcWork.left, info.rcWork.top,
                        info.rcWork.right - info.rcWork.left,
                        info.rcWork.bottom - info.rcWork.top);

            var name = new string(info.szDevice).TrimEnd((char)0);
            var id = int.Parse(Regex.Match(name, @"\d+").Value) - 1;
            Name = id.ToString();
        }

        public static ObservableCollection<Monitor> AllMonitors
        {
            get
            {
                var cBack = new MonitorEnumCallback();
                var proc = new MonitorEnumProc(cBack.Callback);
                EnumDisplayMonitors(NullHandleRef, IntPtr.Zero, proc, IntPtr.Zero);

                //shift monitors so the top right is 0,0
                var monitors = new ObservableCollection<Monitor>(cBack.Monitors.OrderBy(x => x.Bounds.Left));
                var farLeft = monitors.Min(x => x.Bounds.Left);
                var veryBottom = monitors.Min(x => x.Bounds.Top); //top and bottom are flipped due to how rect's are constructed

                for (int i = 0; i < monitors.Count; i++)
                {
                    var monitor = monitors[i];
                    //Bounds is a struct so by val not ref. Therefore copy change then replace
                    var adjustedBounds = monitor.Bounds;
                    adjustedBounds.Offset(-farLeft + (30 * i), -veryBottom);
                    monitor.Bounds = adjustedBounds;


                }

                return monitors;
            }
        }

        private class MonitorEnumCallback
        {
            public ObservableCollection<Monitor> Monitors { get; private set; }

            public MonitorEnumCallback()
            {
                Monitors = new();
            }

            public bool Callback(IntPtr monitor, IntPtr hdc, IntPtr lprcMonitor, IntPtr lparam)
            {
                Monitors.Add(new Monitor(monitor, hdc));
                return true;
            }
        }
    }
}
