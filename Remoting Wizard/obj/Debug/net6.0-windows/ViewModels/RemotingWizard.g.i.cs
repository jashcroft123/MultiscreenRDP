﻿#pragma checksum "..\..\..\..\ViewModels\RemotingWizard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ABDD86729B5CF4926C7F0969DF697D75F484518"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using Prism.Interactivity;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;
using Prism.Unity;
using Remoting_Wizard.Converters;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Remoting_Wizard.ViewModels {
    
    
    /// <summary>
    /// RemotingWizard
    /// </summary>
    public partial class RemotingWizard : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\ViewModels\RemotingWizard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxMode;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\ViewModels\RemotingWizard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxPCs;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\ViewModels\RemotingWizard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxUsernames;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\ViewModels\RemotingWizard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Refresh;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\ViewModels\RemotingWizard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl Screens;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\ViewModels\RemotingWizard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartRemote;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\..\ViewModels\RemotingWizard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartCDrive;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\..\ViewModels\RemotingWizard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ConfigData;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Remoting Wizard;component/viewmodels/remotingwizard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ViewModels\RemotingWizard.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ComboBoxMode = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.ComboBoxPCs = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ComboBoxUsernames = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Refresh = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.Screens = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 6:
            this.StartRemote = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.StartCDrive = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.ConfigData = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            
            #line 195 "..\..\..\..\ViewModels\RemotingWizard.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Insert_OnClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 197 "..\..\..\..\ViewModels\RemotingWizard.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Duplicate_OnClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 199 "..\..\..\..\ViewModels\RemotingWizard.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_OnClick);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 201 "..\..\..\..\ViewModels\RemotingWizard.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteRow_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

