using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsModernUI.Model
{
    public class OrderDetailsMessage
    {
        public List<DishModel> Positions = new List<DishModel>();
        public double Cost = 0;
    }

    public enum MessageType
    {
        OrderDetailsCreateWindow = 0,
        OrderDetailsContent = 1
    }

}
