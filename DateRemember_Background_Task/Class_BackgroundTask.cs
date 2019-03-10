using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using DataAccess;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.Storage;
using Microsoft.Toolkit.Uwp.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



namespace DateRemember_Background_Task
{
    public sealed class Class_BackgroundTask : IBackgroundTask
    {      
        private List<Date> dates = new List<Date>();
        bool _cancelRequested = false;
        ResourceLoader loader = new Windows.ApplicationModel.Resources.ResourceLoader();
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);
            var task = taskInstance.GetDeferral();    //Request the deferral for asynchronous method  
            //https://docs.microsoft.com/es-es/windows/uwp/launch-resume/create-and-register-a-background-task
            //*****************************************************************************************
            
                Load_Data();
                SendToast(dates[0].Name, dates[0].How_many_days_left, dates[0].Description);
                SendTile(dates[0].Get_Month_name_first_three_letters(), dates[0].Day.ToString(), dates[0].Name, dates[0].Month_Day, dates[0].How_many_days_left, dates[1].Day.ToString(), dates[1].Name, dates[1].Month_Day, dates[1].How_many_days_left);
                //*****************************************************************************************
                task.Complete();   //closing deferral
            
        }       
        private static void SendToast(string Date_Name, string Time_left, string Description)
        {
            var toastContent = new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                                  new AdaptiveText()
                                  {
                                       Text = Date_Name
                                  },
                                  new AdaptiveText()
                                  {
                                       Text =Time_left
                                  }
                        },
                        Attribution = new ToastGenericAttributionText()
                        {
                            Text = Description
                        }
                    }
                }
            };

            // Create the toast notification
            var toastNotif = new ToastNotification(toastContent.GetXml());

            // And send the notification
            ToastNotificationManager.CreateToastNotifier().Show(toastNotif);
        }
        private void Load_Data()
        {
            Data_Access_tools.Initialize_Database();
            dates = Data_Access_tools.GetData();

        }       
        private static void SendTile(string Month_name_first_three_letters, string Day_1, string Name_1, string Month_Day_1, string How_many_days_left_1, string Day_2, string Name_2, string Month_Day_2, string How_many_days_left_2)
        {
            var tileContent = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileSmall = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            TextStacking = TileTextStacking.Center,
                            Children =
                            {
                                    new AdaptiveText()
                                    {
                                             Text = Month_name_first_three_letters,
                                             HintAlign = AdaptiveTextAlign.Center
                                    },
                                    new AdaptiveText()
                                    {
                                             Text = Day_1,
                                             HintStyle = AdaptiveTextStyle.Body,
                                             HintAlign = AdaptiveTextAlign.Center
                                    }
                            }
                        }
                    },
                    TileMedium = new TileBinding()
                    {
                        Branding = TileBranding.Name,
                        DisplayName = "DateRemember",
                        Content = new TileBindingContentAdaptive()
                        {
                            PeekImage = new TilePeekImage()
                            {
                                Source = "Assets/Birthday.jpg"
                            },
                            Children =
                            {
                                    new AdaptiveText()
                                    {
                                             Text = Name_1,
                                             HintWrap = true,
                                             HintMaxLines = 2
                                    },
                                    new AdaptiveText()
                                    {
                                             Text = Month_Day_1,
                                             HintStyle = AdaptiveTextStyle.CaptionSubtle
                                    }
                            }
                        }
                    },
                    TileWide = new TileBinding()
                    {
                        Branding = TileBranding.NameAndLogo,
                        DisplayName = "DateRemember",
                        Content = new TileBindingContentAdaptive()
                        {
                            PeekImage = new TilePeekImage()
                            {
                                Source = "Assets/Save_the_date.jpg"
                            },                            
                            Children =
                            {
                                    new AdaptiveText()
                                    {
                                             Text = Name_1
                                    },
                                    new AdaptiveText()
                                    {
                                             Text = Month_Day_1,
                                             HintStyle = AdaptiveTextStyle.CaptionSubtle
                                    },
                                    new AdaptiveText()
                                    {
                                             Text = How_many_days_left_1,
                                             HintStyle = AdaptiveTextStyle.CaptionSubtle
                                    }
                            }
                        }
                    },
                    TileLarge = new TileBinding()
                    {
                        Branding = TileBranding.NameAndLogo,
                        DisplayName = "DateRemember",
                        Content = new TileBindingContentAdaptive()
                        {
                            PeekImage = new TilePeekImage()
                            {
                                Source = "Assets/Birthday.jpg"
                            },
                            Children =
                            {
                                    new AdaptiveGroup()
                                    {
                                             Children =
                                             {
                                                   new AdaptiveSubgroup()
                                                   {
                                                          Children =
                                                          {
                                                                  new AdaptiveText()
                                                                  {
                                                                         Text = Name_1,
                                                                         HintWrap = true
                                                                  },
                                                                  new AdaptiveText()
                                                                  {
                                                                         Text = Month_Day_1,
                                                                         HintStyle = AdaptiveTextStyle.CaptionSubtle
                                                                  },
                                                                  new AdaptiveText()
                                                                  {
                                                                         Text = How_many_days_left_1,
                                                                         HintStyle = AdaptiveTextStyle.CaptionSubtle
                                                                  }
                                                          }
                                                   }
                                             }
                                    },
                                    new AdaptiveText()
                                    {
                                             Text = ""
                                    },
                                    new AdaptiveGroup()
                                    {
                                             Children =
                                             {
                                                   new AdaptiveSubgroup()
                                                   {
                                                          Children =
                                                          {
                                                                  new AdaptiveText()
                                                                  {
                                                                         Text = Name_2,
                                                                         HintWrap = true
                                                                  },
                                                                  new AdaptiveText()
                                                                  {
                                                                         Text = Month_Day_2,
                                                                         HintStyle = AdaptiveTextStyle.CaptionSubtle
                                                                  },
                                                                  new AdaptiveText()
                                                                  {
                                                                         Text = How_many_days_left_2,
                                                                         HintStyle = AdaptiveTextStyle.CaptionSubtle
                                                                  }
                                                          }
                                                   }
                                             }
                                    }
                            }
                        }
                    }
                }
            };

            // Create the tile notification
            var tileNotif = new TileNotification(tileContent.GetXml());

            // And send the notification to the primary tile
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotif);
        }

        private async void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            // Indicate that the background task is canceled.
            _cancelRequested = true;
            string cancel_alert = loader.GetString("cancel_alert");
            await show_dialog_box(cancel_alert);
            
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
    }
    
}
