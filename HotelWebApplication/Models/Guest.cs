using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebApplication.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Gender { get; set; }

        public DateTime yaerOfBirth { get; set; }
        public DateTime CheckInDate { get; set; }
    }
}