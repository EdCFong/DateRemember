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
using Windows.ApplicationModel.Background;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.Helpers;
using Windows.ApplicationModel.Resources;
using System.Threading.Tasks;
using Windows.UI.Popups;
using DataAccess;
using Windows.Storage;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace DateRemember_5
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Add_Date : Page
    {
        DateTimeOffset a_date = DateTime.Now;
        List<Date> dates = Data_Access_tools.GetData();
        ResourceLoader loader = new Windows.ApplicationModel.Resources.ResourceLoader();
        uint freshnessTime;
        bool edit_mode_on = false;
        int ID_date;
        string previous_name_date;
        string BackgroundTaskName = "BackgroundTask_DateRemember8";
        public Add_Date()
        {
            this.InitializeComponent();
            freshnessTime = Read_freshnessTime();
            switch (freshnessTime)
            {
                case 15:
                    _15_minutes_RadioButton.IsChecked = true;
                    _15_minutes_RadioButton1.IsChecked = true;
                    break;
                case 240:
                    _4_hours_RadioButton.IsChecked = true;
                    _4_hours_RadioButton1.IsChecked = true;
                    break;
                case 480:
                    _8_hours_RadioButton.IsChecked = true;
                    _8_hours_RadioButton1.IsChecked = true;
                    break;
                case 1440:
                    _1_days_RadioButton.IsChecked = true;
                    _1_days_RadioButton1.IsChecked = true;
                    break;
                case 4320:
                    _3_days_RadioButton.IsChecked = true;
                    _3_days_RadioButton1.IsChecked = true;
                    break;
                case 10080:
                    _1_week_RadioButton.IsChecked = true;
                    _1_week_RadioButton1.IsChecked = true;
                    break;
                case 0:
                    no_notif_RadioButton.IsChecked = true;
                    no_notif_RadioButton1.IsChecked = true;
                    break;
                default:
                    _15_minutes_RadioButton.IsChecked = true;
                    _15_minutes_RadioButton1.IsChecked = true;
                    break;
            }
        }

        private void Boton_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));             
        }

        private void DatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            a_date = DatePicker.Date;
        }
        private void DatePicker_for_narrow_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            a_date = DatePicker_for_narrow.Date;
        }

        private async void Boton_Ok_Click(object sender, RoutedEventArgs e)
        {
            if(edit_mode_on == false)
            {
                await Adding_a_date();
            }
            else
            {
                await Editing_a_date();
            }
        }

        private async Task Adding_a_date()
        {           
                if (Name_textBox.Text != "")
                {
                    if(!Repeated_name(Name_textBox.Text))
                    {
                    Date my_date = new Date(a_date.Month, a_date.Day, Name_textBox.Text, Descripcion_textBox.Text);
                    my_date.Insert_Data();
                    Set_Notifications(freshnessTime);
                    this.Frame.Navigate(typeof(MainPage));
                    }
                    else
                    {
                    await show_dialog_box(loader.GetString("No_repeat_name"));
                    }
                }               
                else
                {
                    await show_dialog_box(loader.GetString("No_name"));
                }                       
        }

        private async Task Editing_a_date()
        {
            if (Name_textBox.Text != "")
            {
                if ((!Repeated_name(Name_textBox.Text))||(Name_textBox.Text == previous_name_date))
                {
                    Data_Access_tools.EditData(ID_date, a_date.Month, a_date.Day, Name_textBox.Text, Descripcion_textBox.Text);
                    this.Frame.Navigate(typeof(MainPage));
                }
                else
                {
                    await show_dialog_box(loader.GetString("No_repeat_name"));
                }
            }
            else
            {
                await show_dialog_box(loader.GetString("No_name"));
            }
        }

        private bool Repeated_name(string name)
        {
            for(int i=0; i<dates.Count; i++)
            {
                if (dates[i].Name == name)
                {
                    return true;
                }                   
            }
            return false;
        }

        private async void Set_Notifications(uint time)   // Background tasks
        {
                 BackgroundExecutionManager.RemoveAccess();
                 BackgroundAccessStatus status = await BackgroundExecutionManager.RequestAccessAsync();
                // if it is already register return null
                //TimeTrigger(15, false)   15 minutes to wait before scheduling the background task,
                //True if the time event trigger will be used once; false if it will be used each time freshnessTime elapses. 
                var task = BackgroundTaskHelper.Register(BackgroundTaskName, "DateRemember_Background_Task.Class_BackgroundTask", new TimeTrigger(time, false));     
                //task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted); 
        }
        private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
        {

        }

        public void Cancel_Notifications()
        {
            BackgroundTaskHelper.Unregister(BackgroundTaskName, true);
        }

        private void _15_minutes_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            freshnessTime = 15;
            Cancel_Notifications();
            Set_Notifications(freshnessTime);
            Write_freshnessTime(freshnessTime);
        }

        private void _4_hours_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            freshnessTime = 240;
            Cancel_Notifications();
            Set_Notifications(freshnessTime);
            Write_freshnessTime(freshnessTime);
        }

        private void _8_hours_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            freshnessTime = 480;
            Cancel_Notifications();
            Set_Notifications(freshnessTime);
            Write_freshnessTime(freshnessTime);
        }

        private void _1_days_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            freshnessTime = 1440;
            Cancel_Notifications();
            Set_Notifications(freshnessTime);
            Write_freshnessTime(freshnessTime);
        }

        private void _3_days_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            freshnessTime = 4320;
            Cancel_Notifications();
            Set_Notifications(freshnessTime);
            Write_freshnessTime(freshnessTime);
        }

        private void _1_week_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            freshnessTime = 10080;
            Cancel_Notifications();
            Set_Notifications(freshnessTime);
            Write_freshnessTime(freshnessTime);
        }

        private void No_notif_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            freshnessTime = 0;
            Write_freshnessTime(freshnessTime);
            Cancel_Notifications();
        }

        async Task show_dialog_box(string warning_text)
        {          
            ContentDialog my_Dialog = new ContentDialog()
            {
                Title = loader.GetString("Atention"),
                Content = warning_text,
                CloseButtonText = loader.GetString("Accept")
            };
            await my_Dialog.ShowAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {              
                Date my_date_to_edit = dates[Convert.ToInt32(e.Parameter)];
                Name_textBox.Text = my_date_to_edit.Name;
                previous_name_date = my_date_to_edit.Name;
                Descripcion_textBox.Text = my_date_to_edit.Description;
                ID_date = Data_Access_tools.Get_ID(my_date_to_edit.Name);
                a_date = new DateTime(DateTime.Now.Year, my_date_to_edit.Month, my_date_to_edit.Day);
                edit_mode_on = true;
            }
        }

        private void Write_freshnessTime(uint freshnessTime)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["timeNotif"] = freshnessTime;
        }
        private uint Read_freshnessTime()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            uint localValue = Convert.ToUInt32(localSettings.Values["timeNotif"]);
            if(localValue != 0)
            {
                return localValue;
            }
            else
            {
                return 15;
            }           
        }

        
    }   
}
