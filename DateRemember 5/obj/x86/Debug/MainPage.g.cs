﻿#pragma checksum "D:\Projects\DateRemember\DateRemember\DateRemember 5\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8A1679DB3116EB1580EB909785AE3A15"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DateRemember_5
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 16
                {
                    this.Second_column_Main_grid = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 3: // MainPage.xaml line 21
                {
                    this.Hidden_row = (global::Windows.UI.Xaml.Controls.RowDefinition)(target);
                }
                break;
            case 4: // MainPage.xaml line 23
                {
                    this.Grid_botones = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5: // MainPage.xaml line 44
                {
                    this.Calendar_Grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // MainPage.xaml line 52
                {
                    this.Dates_ListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.Dates_ListView).SelectionChanged += this.Dates_ListView_SelectionChanged;
                }
                break;
            case 7: // MainPage.xaml line 68
                {
                    this.Dates_ListView_for_delete = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.Dates_ListView_for_delete).SelectionChanged += this.Dates_ListView_for_delete_SelectionChanged;
                }
                break;
            case 8: // MainPage.xaml line 85
                {
                    this.Dates_ListView_for_edit = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.Dates_ListView_for_edit).SelectionChanged += this.Dates_ListView_for_edit_SelectionChanged;
                }
                break;
            case 12: // MainPage.xaml line 46
                {
                    this.First_Row_Calendar_Grid = (global::Windows.UI.Xaml.Controls.RowDefinition)(target);
                }
                break;
            case 13: // MainPage.xaml line 49
                {
                    this.The_calendar = (global::Windows.UI.Xaml.Controls.CalendarView)(target);
                }
                break;
            case 14: // MainPage.xaml line 50
                {
                    this.Description_TextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // MainPage.xaml line 25
                {
                    this.Adding_date_column = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 16: // MainPage.xaml line 30
                {
                    this.Add_Date_boton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Add_Date_boton).Click += this.Add_Date_boton_Click;
                }
                break;
            case 17: // MainPage.xaml line 31
                {
                    this.Delete_Date_boton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Delete_Date_boton).Click += this.Delete_Date_boton_Click;
                }
                break;
            case 18: // MainPage.xaml line 32
                {
                    this.Edit_boton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Edit_boton).Click += this.Edit_boton_Click;
                }
                break;
            case 19: // MainPage.xaml line 33
                {
                    this.Help_boton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Help_boton).Click += this.Help_boton_Click;
                }
                break;
            case 20: // MainPage.xaml line 34
                {
                    this.Delete_Date_boton_Narrow = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Delete_Date_boton_Narrow).Click += this.Delete_Date_boton_Click;
                }
                break;
            case 21: // MainPage.xaml line 37
                {
                    this.Edit_boton_Narrow = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Edit_boton_Narrow).Click += this.Edit_boton_Click;
                }
                break;
            case 22: // MainPage.xaml line 40
                {
                    this.Help_boton_Narrow = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Help_boton_Narrow).Click += this.Help_boton_Click;
                }
                break;
            case 23: // MainPage.xaml line 103
                {
                    this.WindowStates = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 24: // MainPage.xaml line 104
                {
                    this.WideState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 25: // MainPage.xaml line 117
                {
                    this.State_1 = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 26: // MainPage.xaml line 130
                {
                    this.State_2 = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 27: // MainPage.xaml line 143
                {
                    this.State_3 = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 28: // MainPage.xaml line 162
                {
                    this.NarrowState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

