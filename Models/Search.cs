using Gym.ModefittnesEquipment;
using System.Collections.Generic;

namespace Gym.Models
{
    public class Search
    {

        public Search()
        {
            Equipmentlist = new List<Equipment>();
            shakeAndTosaflist = new List<ShakeAndTosaf>();
        }
        public List<Equipment> Equipmentlist { get; set; }
        public List<ShakeAndTosaf> shakeAndTosaflist { get; set; }
      
    }
}
