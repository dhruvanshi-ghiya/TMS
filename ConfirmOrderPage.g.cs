﻿#pragma checksum "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DCA28ADA35A6BCEF3CD46656DFC756D22ECEA6EAE253EFFD6FBC1FC879C199EE"
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
using TMS.Pages;


namespace TMS.Pages.Planner {
    
    
    /// <summary>
    /// ConfirmOrderPage
    /// </summary>
    public partial class ConfirmOrderPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock OrderInfoSecondary;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RouteVisual;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmOrderBtn;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddTripBtn;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CarrierDropdown;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StartCityDropdown;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EndCityDropdown;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox OrderSummaryList;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TripInputError;
        
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
            System.Uri resourceLocater = new System.Uri("/TMS;component/pages/planner/confirmorderpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
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
            this.OrderInfoSecondary = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.RouteVisual = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.ConfirmOrderBtn = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
            this.ConfirmOrderBtn.Click += new System.Windows.RoutedEventHandler(this.ConfirmOrderBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddTripBtn = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
            this.AddTripBtn.Click += new System.Windows.RoutedEventHandler(this.AddTripBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CarrierDropdown = ((System.Windows.Controls.ComboBox)(target));
            
            #line 65 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
            this.CarrierDropdown.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CarrierDropdown_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StartCityDropdown = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.EndCityDropdown = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.OrderSummaryList = ((System.Windows.Controls.ListBox)(target));
            
            #line 72 "..\..\..\..\Pages\Planner\ConfirmOrderPage.xaml"
            this.OrderSummaryList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OrderSummaryList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TripInputError = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
