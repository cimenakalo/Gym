using Microsoft.AspNetCore.Http;

namespace Gym.Models
{
    public class Vegetable: Food
    {
        public string typeOfVegetable { get; set; }
        public Vegetable(string Name, string Category, string Description, int Protein, int Calories, int Carbs, int Fats, IFormFile File, byte[] Photo, int menuID)
            : base(Name, Category, Description, Protein, Calories, Carbs, Fats, File, Photo, menuID)
        {


        }
        public Vegetable()

        {



        }


    }

}
