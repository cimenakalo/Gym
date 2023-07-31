using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Photo
    {
        public Photo() { }
        [Key]
        public int ID { get; set; }

        [Display(Name = "תמונה")]
        public byte[] MyPhoto { get; set; }
        

    }
}
