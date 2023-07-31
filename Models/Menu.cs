using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gym.Models
{
    public class Menu
    {
        public Menu()
        {
            foodList = new List<Food>();
        }

        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        [Display(Name = "בשרי")]
        public List<Food> foodList { get; set; }

        public string NewMenu { get; set; } = "";
        public string NotNewMenu { get; set; } = "";
        

        public int getValues(string name)
        {
            int total = 0;
            switch (name)
            { case "calories":
                    total = foodList.Sum(x => x.calories);
                    break;
                case "protein":
                    total = foodList.Sum(x => x.protein);
                    break;
                case "fats":
                    total = foodList.Sum(x => x.fats);
                    break;
                case "carbs":
                    total = foodList.Sum(x => x.carbs);
                    break;
            }
            return total;
        }
            
        
        }

    }

