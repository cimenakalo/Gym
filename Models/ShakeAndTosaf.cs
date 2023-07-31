using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class ShakeAndTosaf: Food
    {
        public ShakeAndTosaf(string Name, string Category, string Description, int Protein, int Calories, int Carbs, int Fats, IFormFile File, byte[] Photo, int menuID,string kosher,string taste,bool halavi,string typeOf,float price,int amountAvailable)
           : base(Name, Category, Description, Protein, Calories, Carbs, Fats, File, Photo, menuID)
        {
            this.amountAvailable = amountAvailable;
            this.taste = taste;
            this.kosher = kosher;
            this.halavi = halavi;
            this.TypeOf = typeOf;
            this.price = price;
        }
        public ShakeAndTosaf()
        {

        }
        [Display(Name = "כשרות ")]

        public string kosher { get; set; }
        [Display(Name = "טעם ")]

        public string taste { get; set; }
        [Display(Name = "חלבי? ")]


        public bool halavi { get; set; }
        [Display(Name = "סוג")]

        
        public string TypeOf { get; set; }
        [Display(Name ="מחיר")]
        public float price { get; set; }
        [Display(Name = "כמות")]
        public int amountAvailable { get; set; }
        public bool isAvailable { get; set; }
        public string Available()
        {
            if (isAvailable)
                return  "המוצר זמין במלאי";
            return  " המוצר לא זמין במלאי";
        }
        public void ChangeAvailable()
        {
            isAvailable = !isAvailable;
        }
       
    }
}
