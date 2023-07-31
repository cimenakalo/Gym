using System;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Messages
    {
        public Messages()
        {
            date = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Display(Name = "תוכן ההודעה")]
        public string messeagIndex { get; set; }
        [Display(Name ="תאריך")]
        public DateTime date { get; set; }
        [Display(Name ="שם מלא")]
        public string fullName { get; set; }
        public bool Read { get; set; }
        public static int countNotRaed()
        {
            int count = 0;
            foreach(Messages messages in DataLayer.Data.Messages)
            {
                if (!messages.Read)
                    count++;
            }
            return count;
        }
    }
}
