using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Besari:Food
    {


        public Besari(string Name, string Category, string Description, int Protein, int Calories, int Carbs, int Fats, IFormFile File, byte[] Photo, int menuID)
            : base(Name, Category, Description, Protein, Calories, Carbs, Fats, File, Photo, menuID)
        {



        }

        public Besari()
        {



        }






    }
}
