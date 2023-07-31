using Gym.ModefittnesEquipment;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Gym.Models
{
    public class VmEquipment
    {

        [Key]
        public int ID { get; set; }
        [Display(Name = "מחיר")]
        public float price { get; set; }
        [Display(Name = "כמות")]
        public int amount = 1;
        public Equipment equipment { get; set; }
        public float getPrice { get { return equipment.price * amount; } }
        public void AddAmount() { amount++; }
        public void SubAmount() { amount--; }
        public string toString
        {
            get
            {
                return " מוצר: " + equipment.name + "\n"
                    + " מספר סידורי: " + equipment.serialNumber + "\n"
                    + " כמות: " + amount + "\n";
            }
        }

    }
}
