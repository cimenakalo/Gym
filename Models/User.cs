using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class User
    {
        public User() {
            menus = new List<Menu>();
            orders = new List<Order>();
        }
        [Key]
        public int ID { get; set; }
        [Display(Name = "שם משתמש")]
        public string userName { get; set; }
        [Display(Name = "סיסמא")]
        public string password { get; set; }
        [Display(Name = "כתובת מייל")]
        [EmailAddress(ErrorMessage = "נא להכניס כתובת מייל תקינה")]
        public string email { get; set; }
        [Display(Name = "שם פרטי")]
        public string firstName { get; set; }
        [Display(Name = "שם משפחה")]
        public string lastName { get; set; }
        [Display(Name = "כתובת")]
        public string address { get; set; }
        [Display(Name = "טלפון")]
        public string phoneNumber { get; set; }
        [Display(Name = "עיר")]
        public string city { get; set; }
        public string errorMessage { get; set; } = "";
        public  List<Menu> menus {get;set; }
        [Display(Name ="הזמנות")]
        public List<Order> orders { get; set; }
        public Cart Cart { get; set; }
        public bool checkUserName()
        {
            if (userName[0]>=48 && userName[0]<=57)
            {
                return false;
            }
            for(int i=0; i>userName.Length;i++)
            {
                if ((userName[i] <35 || userName[i] > 57) && (userName[i] < 65 || userName[i]  >90)
                        && (userName[i]<97 || userName[i]>122))
                    return false;
            }
            return true;
        }
        public void LogOut()
        {
            User user = new User()
            {
                firstName = "התחבר",
                ID = 0
            };
            DataLayer.User =user;
            DataLayer.Data.SaveChanges();
        }
    }
}
