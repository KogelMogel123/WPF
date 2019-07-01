using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using StarWarsModernUI.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarWarsModernUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RestaurantMenuModel _restaurantMenuModel;
        public ObservableCollection<DishModel> RestaurantMenu { get; }

        private int _count;
        private const string CountPropertyName = "Count";
        public int Count
        {
            get { return _count; }
            set
            {
                Set(CountPropertyName, ref _count, value);
            }
        }

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

        public ObservableCollection<DishModel> SelectedDishes { get; } = new ObservableCollection<DishModel>();

        public MainViewModel()
        {
            _restaurantMenuModel = new RestaurantMenuModel();
            RestaurantMenu = new ObservableCollection<DishModel>(_restaurantMenuModel.RestaurantMenu);
        }

        private RelayCommand<DishModel> _addItemCommand;
        public RelayCommand<DishModel> AddItemCommand
        {
            get
            {
                return _addItemCommand
                    ?? (_addItemCommand = new RelayCommand<DishModel>(
                    (item) =>
                    {
                        SelectedDishes.Add(item);

                        int count = SelectedDishes.Count;
                        double cost = SelectedDishes.Sum(dish => dish.Price);

                        Count = count;
                        Cost = cost;

                    }));
            }
        }
        private RelayCommand _clearCommand;
        public RelayCommand ClearCommand
        {
            get
            {
                return _clearCommand
                       ?? (_clearCommand = new RelayCommand(
                           () =>
                           {
                               SelectedDishes.Clear();
                               Count = 0;
                               Cost = 0;

                           }));
            }
        }

        private RelayCommand _showDetailsCommand;
        public RelayCommand ShowDetailsCommand
        {
            get
            {
                return _showDetailsCommand
                       ?? (_showDetailsCommand = new RelayCommand(
                           () =>
                           {
                               Messenger.Default.Send<OrderDetailsMessage>(new OrderDetailsMessage
                               {
                                   Positions = SelectedDishes.ToList(),
                                   Cost = Cost
                               }, MessageType.OrderDetailsCreateWindow);

                           }));
            }
        }

    }
}