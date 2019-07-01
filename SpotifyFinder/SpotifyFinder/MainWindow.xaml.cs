using SpotifyFinder.Data;
using SpotifyFinder.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SpotifyFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpGrabber http = new HttpGrabber();
        internal static Frame _mainFrame;
        AlbumListPage albumListPage;

        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metoda inicjalizująca program
        /// </summary>
        private void IntProgram()
        {
            _mainFrame = MainFrame;
            albumListPage = new AlbumListPage(http);
            _mainFrame.Navigate(albumListPage);
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            IntProgram();
        }

        private async Task GetData(string search)
        {
            await http.MakeStringGreatAgain(search);
        }

        private void searchBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            string search = searchBox.Text;
            if(search.Length > 5 && TimeBetwenKeyUp(500, search))
            {
                GetData(search);
            }
        }

        private int lastSearchStringLength = 0;
        private long lastKeyUp = 0;

        private bool TimeBetwenKeyUp(int time, string search)
        {
            bool searchAfterTime = false;

            if (search.Length == lastSearchStringLength)
                return false;

            var elapsedTics = Stopwatch.GetTimestamp() - lastKeyUp;
            var elapsedTimeMs = elapsedTics * 100000 / Stopwatch.Frequency;

            if(elapsedTimeMs > time)
            {
                searchAfterTime = true;
            }

            lastKeyUp = Stopwatch.GetTimestamp();    

            return searchAfterTime;
        }
    }
}
