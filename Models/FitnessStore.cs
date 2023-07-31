using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class FitnessStore
    {

        public FitnessStore() { }

        [Key]//כל פעם שאני יצור אובייקט חדש הוא יוסיף 1 לID
        public int ID { get; set; }
        [Display(Name="Store Name")]
        public string Name { get; set; }

        [Display(Name = "phone number")]
        public int phone_number { get; set; }

        public Menu menu { get; set; }

    }
}
