﻿#pragma checksum "..\..\HoofdvensterKlasse.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3AC956CFEB671491730E443E83C273538B2CB9AD18510D62E485EB439B67EA5E"
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
using VoorbeeldWindowsWPF;


namespace VoorbeeldWindowsWPF {
    
    
    /// <summary>
    /// HoofdvensterKlasse
    /// </summary>
    public partial class HoofdvensterKlasse : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\HoofdvensterKlasse.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtResultaat;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\HoofdvensterKlasse.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnWijzigen;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\HoofdvensterKlasse.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/VoorbeeldWindowsWPF;component/hoofdvensterklasse.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\HoofdvensterKlasse.xaml"
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
            
            #line 8 "..\..\HoofdvensterKlasse.xaml"
            ((VoorbeeldWindowsWPF.HoofdvensterKlasse)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TxtResultaat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BtnWijzigen = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\HoofdvensterKlasse.xaml"
            this.BtnWijzigen.Click += new System.Windows.RoutedEventHandler(this.BtnWijzigen_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnInfo = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\HoofdvensterKlasse.xaml"
            this.BtnInfo.Click += new System.Windows.RoutedEventHandler(this.BtnInfo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

