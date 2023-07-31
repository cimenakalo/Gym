using System.Collections;
using System.Collections.Generic;

namespace Gym.Models
{
    public class Admin:User
    {
        public Admin()
        {
            messages = new List<Messages>();
        }
        public List<Messages> messages { get; set; }
    }
}
