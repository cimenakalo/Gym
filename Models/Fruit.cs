using Microsoft.AspNetCore.Http;

namespace Gym.Models
{
    public class Fruit: Food
    {
        public string typeOfFruit { get; set; }
        public Fruit(string Name, string Category, string Description, int Protein, int Calories, int Carbs, int Fats, IFormFile File, byte[] Photo, int menuID)
            : base(Name, Category, Description, Protein, Calories, Carbs, Fats, File, Photo, menuID)
        {


        }
        public Fruit()

        {



        }
    }
}