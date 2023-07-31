using Gym.ModefittnesEquipment;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gym.Models
{
    public class Cart
    {
        public Cart()
        {
            EquipmentList = new List<VmEquipment>();
            ShakeAndTosafList = new List<VmShakesTosaf>();
        }
        [Key]
        public int ID { get; set; }
        [Display(Name = "רשימה של ציוד")]
        public List<VmEquipment> EquipmentList { get; set; }
        [Display(Name = "רשימה של שייקים ותוספים")]
        public List<VmShakesTosaf> ShakeAndTosafList { get; set; }
        public int totalAmount{get {
                int total = 0;
                foreach (VmEquipment equipment in EquipmentList)
                {
                    total += equipment.amount;
                }
                foreach (VmShakesTosaf shakesTosaf in ShakeAndTosafList)
                {
                    total += shakesTosaf.amount;
                }
                return total;
            }
        }
        [Display(Name ="סהכ לתשלום:")]
        public float totalPrice { get
            {
                float total = 0;
                foreach (VmEquipment equipment in EquipmentList)
                {
                    total += equipment.getPrice;
                }
                foreach (VmShakesTosaf shakesTosaf in ShakeAndTosafList)
                {
                    total += shakesTosaf.getPrice;
                }
                return total;
            } 
        }
        public int ShowHowMuch()
        {
            int count = 0;
            if (DataLayer.User.Cart.ShakeAndTosafList.ToList() != null)
            {
                foreach (VmShakesTosaf shakesTosaf in DataLayer.User.Cart.ShakeAndTosafList.ToList())
                {
                    count += shakesTosaf.amount;
                }
            }
            if(DataLayer.User.Cart.EquipmentList.ToList()!=null)
            {
                foreach(VmEquipment equipment in DataLayer.User.Cart.EquipmentList.ToList())
                {
                    count += equipment.amount;
                }
            }
            return count;

        }
     
    }
}
