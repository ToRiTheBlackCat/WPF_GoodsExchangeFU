﻿#pragma checksum "..\..\..\OwnProductWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0EBE9DE1C84765DF942C1EE756377D574C432EE9"
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
    /// OwnProductWindow
    /// </summary>
    public partial class OwnProductWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\OwnProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrProducts;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\OwnProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReturn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\OwnProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchProduct;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\OwnProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF-GoodsExchangeFUGUI;component/ownproductwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\OwnProductWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dgrProducts = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\..\OwnProductWindow.xaml"
            this.dgrProducts.Loaded += new System.Windows.RoutedEventHandler(this.dgrProducts_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnReturn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\OwnProductWindow.xaml"
            this.btnReturn.Click += new System.Windows.RoutedEventHandler(this.btnReturn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.searchProduct = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\OwnProductWindow.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

