﻿#pragma checksum "..\..\..\ModWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F2B4209082CF9308C318E00AA5E40FD17857E1E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPF_GoodsExchangeFUGUI;


namespace WPF_GoodsExchangeFUGUI {
    
    
    /// <summary>
    /// ModWindow
    /// </summary>
    public partial class ModWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\ModWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WPF_GoodsExchangeFUGUI.ModWindow Mod_Window;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\ModWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HomePageButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\ModWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WaitingProductButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\ModWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WaitingReportButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\ModWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QuitButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF-GoodsExchangeFUGUI;component/modwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ModWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Mod_Window = ((WPF_GoodsExchangeFUGUI.ModWindow)(target));
            return;
            case 2:
            this.HomePageButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\ModWindow.xaml"
            this.HomePageButton.Click += new System.Windows.RoutedEventHandler(this.HomePageButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.WaitingProductButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\ModWindow.xaml"
            this.WaitingProductButton.Click += new System.Windows.RoutedEventHandler(this.WaitingProductButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.WaitingReportButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\ModWindow.xaml"
            this.WaitingReportButton.Click += new System.Windows.RoutedEventHandler(this.WaitingReportButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.QuitButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\ModWindow.xaml"
            this.QuitButton.Click += new System.Windows.RoutedEventHandler(this.QuitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

