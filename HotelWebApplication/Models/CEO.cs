using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebApplication.Models
{
    public class CEO
    {
        public int Id;
        public string FullName;
        public int Age;
        public string Email;
        public int Salary;

        public CEO(int id, string fullName, int age, string email, int salary)
        {
            Id = id;
            FullName = fullName;
            Age = age;
            Email = email;
            Salary = salary;
        }
    }
}