using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using StarWarsModernUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsModernUI.ViewModel
{
    public class MessageBoxViewModel : ViewModelBase
    {
        public ObservableCollection<DishModel> Positions { get; } = new ObservableCollection<DishModel>();

        private double _cost;
        private const string CostPropertyName = "Cost";
        public double Cost
        {
            get { return _cost; }
            set
            {
                Set(CostPropertyName, ref _cost, value);
            }
        }

        public MessageBoxViewModel()
        {
            Messenger.Default.Register<OrderDetailsMessage>(this, MessageType.OrderDetailsContent, ProcessMessage);
        }

        private void ProcessMessage(OrderDetailsMessage message)
        {
            Positions.Clear();
            message.Positions.ForEach((item) =>
            {
                Positions.Add(item);
            });

            Cost = message.Cost;
        }
    }
}
