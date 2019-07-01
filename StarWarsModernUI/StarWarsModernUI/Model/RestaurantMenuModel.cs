using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsModernUI.Model
{
    public class RestaurantMenuModel
    {
        private List<DishModel> _restaurantMenu = new List<DishModel>
        {
            new DishModel
            {
                Name = "Pierś z kaczki",
                Price = 37
            },
            new DishModel
            {
                Name = "Pieczone żeberka",
                Price = 34
            },
            new DishModel
            {
                Name = "Łosoś",
                Price = 32
            },
            new DishModel
            {
                Name = "Zupa pomidorowa",
                Price = 8
            },
            new DishModel
            {
                Name = "Szarlotka",
                Price = 12
            },
            new DishModel
            {
                Name = "Kawa",
                Price = 11
            },
            new DishModel
            {
                Name = "Zielona herbata",
                Price = 9
            },
            new DishModel
            {
                Name = "Napój gazowany",
                Price = 9
            }
        };

        public List<DishModel> RestaurantMenu
        {
            get { return _restaurantMenu; }
            set
            {
                if (value != null)
                    _restaurantMenu = value;
            }
        }
    }
}
