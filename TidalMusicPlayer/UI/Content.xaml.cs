using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TidalMusicPlayer
{
    /// <summary>
    /// Interaction logic for Content.xaml
    /// </summary>
    public partial class Content : Window
    {
          
        public Content()
        {
            
            var cef = new CefSettings();
            CefSharp.Cef.Initialize(cef);
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

                     
        }

        private void BrowerContent_LoadingStateChanged(object sender, CefSharp.LoadingStateChangedEventArgs e)
        {
            if(!e.IsLoading)
            {
                this.Dispatcher.Invoke(() =>
                {
                    loading.Visibility = Visibility.Hidden;
                });
            } else
            {
                Dispatcher.Invoke(() =>
                {
                    loading.Visibility = Visibility.Visible;
                });
            }
            
        }

        private void Load_Error(object sender, CefSharp.LoadErrorEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                loadingError.Visibility = Visibility.Visible;

                errorCode.Content += e.ErrorCode.ToString();
                errorDesc.Content += e.ErrorText.ToString();
            });
        }

        private void Finished_Loading(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loadingError.Visibility = Visibility.Hidden;
            browerContent.Load("listen.tidal.com");
        }
    }
}
