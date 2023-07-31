using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Food
    {
        public Food(string name, string category, string description, int protein, int calories, int carbs, int fats, IFormFile file, byte[] photo, int menuID)
        {

            this.name = name;
            this.category = category;
            this.description = description;
            this.protein = protein;
            this.calories = calories;
            this.carbs = carbs;
            this.fats = fats;
            this.file = file;
            this.photo = photo;
            MenuIdent = menuID;
            this.amount = 1;
        
        }
        public Food()
        {

        }

        [Key]
        public int ID { get; set; }
        [Display(Name = "שם המאכל")]
        public string name { get; set; }
        [Display(Name = "סוג המאכל")]
        public string category { get; set; }

        [Display(Name = "תיאור")]
        public string description { get; set; }
        [Display(Name = "חלבון")]
        public int protein { get; set; }
        [Display(Name = "קלוריות")]
        public int calories { get; set; }
        [Display(Name = "פחממות")]
        public int carbs { get; set; }
        [Display(Name = "שומן")]
        public int fats { get; set; }
       [Display(Name = "כמות")]
        public int amount { get; set; }

        [Display(Name = "קובץ לתמונה")]
        public IFormFile file { get; set; }
        [Display(Name = " תמונה")]
        public byte[] photo { get; set; }

        public int MenuIdent { get; set; }


        public void addAmount() { amount++; }
        public void subAmount() { amount--; }

        public Food(Food food)
        {
            ID = food.ID;
            name = food.name;
            category = food.category;
            description = food.description;
            protein = food.protein;
            calories = food.calories;
            carbs = food.carbs;
            fats = food.fats;
            file = food.file;
            photo = food.photo;
            MenuIdent = food.MenuIdent;
            amount = food.amount;
      }
      
        
    }
}
