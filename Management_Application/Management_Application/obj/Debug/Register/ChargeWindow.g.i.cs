﻿#pragma checksum "..\..\..\Register\ChargeWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DA1041DA8952DFAF13DE76969DE64568FAE3B06A4AB919F0D9A5AAF2171767CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Management_Application.Register;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Management_Application.Register {
    
    
    /// <summary>
    /// ChargeWindow
    /// </summary>
    public partial class ChargeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Register\ChargeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Pbal;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Register\ChargeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChargefiftyButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Register\ChargeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChargeHundredButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Register\ChargeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChargeTwentyButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Register\ChargeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChargeTenButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Register\ChargeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Money;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Register\ChargeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChargeButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Register\ChargeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReturnButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Management_Application;component/register/chargewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Register\ChargeWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Pbal = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.ChargefiftyButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Register\ChargeWindow.xaml"
            this.ChargefiftyButton.Click += new System.Windows.RoutedEventHandler(this.ChargefiftyButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ChargeHundredButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Register\ChargeWindow.xaml"
            this.ChargeHundredButton.Click += new System.Windows.RoutedEventHandler(this.ChargeHundredButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ChargeTwentyButton = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.ChargeTenButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Register\ChargeWindow.xaml"
            this.ChargeTenButton.Click += new System.Windows.RoutedEventHandler(this.ChargeTenButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Money = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ChargeButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Register\ChargeWindow.xaml"
            this.ChargeButton.Click += new System.Windows.RoutedEventHandler(this.ChargeButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ReturnButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Register\ChargeWindow.xaml"
            this.ReturnButton.Click += new System.Windows.RoutedEventHandler(this.ReturnButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

