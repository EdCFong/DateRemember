using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DataAccess;
using Windows.ApplicationModel.Resources;
using Windows.UI;
using Microsoft.Toolkit.Uwp.Helpers;
using System.Threading.Tasks;
using Windows.UI.Popups;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace DateRemember_5
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Date> dates = new List<Date>();
        bool delete_mode_on = false;
        bool edit_mode_on = false;
        ResourceLoader loader = new Windows.ApplicationModel.Resources.ResourceLoader();
        public MainPage()
        { 
            this.InitializeComponent();
            Data_Access_tools.Initialize_Database();
            dates = Data_Access_tools.GetData();
            Dates_ListView.ItemsSource = dates;
            Dates_ListView_for_delete.ItemsSource = dates;
            Dates_ListView_for_edit.ItemsSource = dates;
            if(dates.Count==0)
            {
               Add_Date x = new Add_Date();  //For use Cancel_Notifications method 
                x.Cancel_Notifications();
            }
        }

        //Navigate to the add date section
        private void Add_Date_boton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Add_Date));
        }
       
        //Select_item_event:   Show description. Show date in the calendar
        private void Dates_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((Dates_ListView.SelectedIndex == -1))
                {
                    Description_TextBlock.Text = "";
                }
                else
                {
                        Show_description(Dates_ListView.SelectedIndex);
                        Show_date_in_the_calendar(Dates_ListView.SelectedIndex);             
                }
            }
            catch
            {
                Description_TextBlock.Text = Description_TextBlock.Text;
            }
        }
        
        //Select_item_event in delete mode 
        private void Dates_ListView_for_delete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((Dates_ListView_for_delete.SelectedIndex == -1))
                {
                    Description_TextBlock.Text = "";
                }
                else
                {
                    Show_description(Dates_ListView_for_delete.SelectedIndex);
                    Show_date_in_the_calendar(Dates_ListView_for_delete.SelectedIndex);
                    Delete(Dates_ListView_for_delete.SelectedIndex);
                }
            }
            catch
            {
                Description_TextBlock.Text = Description_TextBlock.Text;
            }
        }

        //Select_item_event in edit mode 
        private void Dates_ListView_for_edit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((Dates_ListView_for_edit.SelectedIndex == -1))
                {
                    Description_TextBlock.Text = "";
                }
                else
                {
                    Show_description(Dates_ListView_for_edit.SelectedIndex);
                    Show_date_in_the_calendar(Dates_ListView_for_edit.SelectedIndex);
                    this.Frame.Navigate(typeof(Add_Date), Dates_ListView_for_edit.SelectedIndex);
                }
            }
            catch
            {
                Description_TextBlock.Text = Description_TextBlock.Text;
            }
        }

        //Delete item button  -  Activate the delete mode
        private void Delete_Date_boton_Click(object sender, RoutedEventArgs e)
        {
            if(delete_mode_on == false)
            {
                delete_mode_on = true;
                edit_mode_on = false;
                Dates_ListView.Visibility = Visibility.Collapsed;
                Dates_ListView_for_edit.Visibility = Visibility.Collapsed;
                Dates_ListView_for_delete.Visibility = Visibility.Visible;
                // Dates_ListView.Background = new SolidColorBrush(Color.FromArgb(255, 248, 100, 88));
            }
            else
            {
                delete_mode_on = false;
                Dates_ListView.Visibility = Visibility.Visible;
                Dates_ListView_for_delete.Visibility = Visibility.Collapsed;
                Dates_ListView_for_edit.Visibility = Visibility.Collapsed;
            }
        }

        //Edit item button  -  Activate the edit mode 
        private void Edit_boton_Click(object sender, RoutedEventArgs e)
        {
            if (edit_mode_on == false)
            {
                edit_mode_on = true;
                delete_mode_on = false;
                Dates_ListView.Visibility = Visibility.Collapsed;
                Dates_ListView_for_delete.Visibility = Visibility.Collapsed;
                Dates_ListView_for_edit.Visibility = Visibility.Visible;
            }
            else
            {
                edit_mode_on = false;
                Dates_ListView.Visibility = Visibility.Visible;
                Dates_ListView_for_edit.Visibility = Visibility.Collapsed;
                Dates_ListView_for_delete.Visibility = Visibility.Collapsed;
            }
        }

        //Navigate to the help section
        private void Help_boton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Help_Page));
        }

        //Delete method
        async void Delete(int index)
        {
            ContentDialog my_Dialog = new ContentDialog()
            {
                Title = loader.GetString("Atention"),
                Content = loader.GetString("Are_you_sure_delete_date"),
                PrimaryButtonText = loader.GetString("Accept"),        
                CloseButtonText = loader.GetString("Cancel_word")
            };
            ContentDialogResult result = await my_Dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                string bye_name = dates[index].Name;
                Data_Access_tools.DeleteData(bye_name);
                dates = Data_Access_tools.GetData();
                Dates_ListView.ItemsSource = dates;
                Dates_ListView_for_delete.ItemsSource = dates;
                Dates_ListView_for_edit.ItemsSource = dates;
            }      
        }       

        //Show description method
        void Show_description(int index)
        {
            string My_description = dates[index].Description;
            if (My_description == "")
            {
                Description_TextBlock.Text = loader.GetString("Description_header") + Environment.NewLine + loader.GetString("No_Description_to_show");
            }
            else
            {
                Description_TextBlock.Text = loader.GetString("Description_header") + Environment.NewLine + My_description;
            }
        }

        //Show date in the calendar
        void Show_date_in_the_calendar(int index)
        {
            DateTime temporal_DateTime = new DateTime(DateTimeOffset.Now.Year, dates[index].Month, dates[index].Day);
            The_calendar.SelectedDates.Add(temporal_DateTime);
        }

        
    }
}
