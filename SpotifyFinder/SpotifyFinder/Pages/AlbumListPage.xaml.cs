using SpotifyFinder.Data;
using SpotifyFinder.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpotifyFinder.Pages
{
    /// <summary>
    /// Interaction logic for AlbumListPage.xaml
    /// </summary>
    public partial class AlbumListPage : Page
    {
        private HttpGrabber http;
        public AlbumListPage()
        {
            InitializeComponent();
        }

        public AlbumListPage(HttpGrabber http)
        {
            InitializeComponent();
            this.http = http;
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            http.SearchList.CollectionChanged += SearchList_CollectionChanged;
        }

        private void SearchList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            dataList.ItemsSource = http.SearchList;
        }

        private void OnLeftMouseLeftButtonClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = (sender as ListView).SelectedItem as Result;
                MainWindow._mainFrame.Navigate(new AlbumDetailsPage(item));
            }
            catch
            {
                //just pass
            }
        }
    }
}
