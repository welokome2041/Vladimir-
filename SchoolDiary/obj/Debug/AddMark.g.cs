﻿#pragma checksum "..\..\AddMark.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9B9C2AFD863C51A52771B4E1C65C9A58C8A5995A2D01BB5C8B5E4FABF84508AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SchoolDiary;
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


namespace SchoolDiary {
    
    
    /// <summary>
    /// AddMark
    /// </summary>
    public partial class AddMark : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\AddMark.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox box_subject;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AddMark.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AddMark.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox group;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AddMark.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _continue;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddMark.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button set_mark;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AddMark.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox marks_box;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AddMark.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox date_lesson_box;
        
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
            System.Uri resourceLocater = new System.Uri("/SchoolDiary;component/addmark.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddMark.xaml"
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
            
            #line 14 "..\..\AddMark.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.box_subject = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\AddMark.xaml"
            this.box_subject.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.select_subject_group);
            
            #line default
            #line hidden
            return;
            case 3:
            this.grid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.group = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this._continue = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\AddMark.xaml"
            this._continue.Click += new System.Windows.RoutedEventHandler(this._continue_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.set_mark = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\AddMark.xaml"
            this.set_mark.Click += new System.Windows.RoutedEventHandler(this.set_mark_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.marks_box = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.date_lesson_box = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
