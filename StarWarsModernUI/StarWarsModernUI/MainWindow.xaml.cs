using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using StarWarsModernUI.Model;
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

namespace StarWarsModernUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<OrderDetailsMessage>(this, MessageType.OrderDetailsCreateWindow, ShowDetailsWindow);
        }

        private void ShowDetailsWindow(OrderDetailsMessage content)
        {
            var view = new MessageBox();
            Messenger.Default.Send(content, MessageType.OrderDetailsContent);
            view.ShowDialog();
        }
    }
}
