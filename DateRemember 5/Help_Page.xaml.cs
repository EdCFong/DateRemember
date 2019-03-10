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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace DateRemember_5
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Help_Page : Page
    {
        public Help_Page()
        {
            this.InitializeComponent();
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            Texts texts_help = new Texts();
            texts_help.text_0 = loader.GetString("Help_text_0");
            texts_help.text_1 = loader.GetString("Help_text_1");
            texts_help.text_2 = loader.GetString("Help_text_2");
            texts_help.text_3 = loader.GetString("Help_text_3");
            texts_help.text_4 = loader.GetString("Help_text_4");
            texts_help.text_5 = loader.GetString("Help_text_5");
            texts_help.text_6 = loader.GetString("Help_text_6");
            texts_help.text_7 = loader.GetString("Help_text_7");
            texts_help.text_8 = loader.GetString("Help_text_8");
            DataContext = texts_help;
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));           
        }
    }

    public class Texts
    {
        public string text_0 { set; get; }
        public string text_1 { set; get; }
        public string text_2 { set; get; }
        public string text_3 { set; get; }
        public string text_4 { set; get; }
        public string text_5 { set; get; }
        public string text_6 { set; get; }
        public string text_7 { set; get; }
        public string text_8 { set; get; }

    }
}
