using System;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "מספר הזמנה")]
        public  string OrderNumber
        {
            get
            {
                Random random = new Random();
                int a = random.Next(9999) + 1000;
                return a.ToString();
            }
        }
        [Display(Name = "תאריך ")]
        public DateTime date { get; set; } = DateTime.Now;
        [Display(Name ="תוכן הזמנה")]
        public string orderDetails { get; set; }
    }
}
