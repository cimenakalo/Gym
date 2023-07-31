using Gym.ModefittnesEquipment;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class VmShakesTosaf
    {
        
        [Key]
        public int ID { get; set; }
        [Display(Name = "מחיר")]
        public float price { get; set; }
        [Display(Name = "כמות")]
        public int amount = 1;
        public float getPrice { get { return ShakeAndTosaf.price * amount; } }
        public ShakeAndTosaf ShakeAndTosaf { get; set; }
        public void AddAmount() { amount++; }
        public void SubAmount() { amount--; }
        public string toString
        {
            get
            {
                return "מוצר:  " + ShakeAndTosaf.name + "\n"
                    + " כמות: " + amount + "\n";
            }
        }
    }
}
