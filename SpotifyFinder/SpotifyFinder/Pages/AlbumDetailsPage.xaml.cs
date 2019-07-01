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
    /// Interaction logic for AlbumDetailsPage.xaml
    /// </summary>
    public partial class AlbumDetailsPage : Page
    {
        private  Result albumItem;

        public AlbumDetailsPage(Result item)
        {
            InitializeComponent();
            albumItem = item;
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            TestBox.Text = albumItem.name;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow._mainFrame.GoBack();
        }
    }
}
