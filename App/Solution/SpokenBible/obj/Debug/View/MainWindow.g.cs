﻿#pragma checksum "..\..\..\View\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7BF6DBDEE3CBC9B4505FD65711A9844A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AltzControls;
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


namespace SpokenBible.View {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\View\MainWindow.xaml"
        internal AltzControls.AutoComplete busca;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\View\MainWindow.xaml"
        internal System.Windows.Controls.Button ir;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\MainWindow.xaml"
        internal System.Windows.Controls.Button ler;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\MainWindow.xaml"
        internal System.Windows.Controls.FlowDocumentReader documentReader;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\View\MainWindow.xaml"
        internal System.Windows.Documents.FlowDocument document;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\MainWindow.xaml"
        internal System.Windows.Controls.Frame principal;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SpokenBible;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.busca = ((AltzControls.AutoComplete)(target));
            
            #line 22 "..\..\..\View\MainWindow.xaml"
            this.busca.SearchRequest += new System.Windows.RoutedEventHandler(this.busca_SearchRequest);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\View\MainWindow.xaml"
            this.busca.TextChanged += new System.Windows.RoutedEventHandler(this.busca_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ir = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\View\MainWindow.xaml"
            this.ir.Click += new System.Windows.RoutedEventHandler(this.busca_SearchRequest);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ler = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\View\MainWindow.xaml"
            this.ler.Click += new System.Windows.RoutedEventHandler(this.ler_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.documentReader = ((System.Windows.Controls.FlowDocumentReader)(target));
            return;
            case 5:
            this.document = ((System.Windows.Documents.FlowDocument)(target));
            return;
            case 6:
            this.principal = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
