using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustType { get; set; }
        public string Email { get; set; }

        public Customer() { }
        public Customer(string firstName, string lastName, string custType, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            CustType = custType;
            Email = email;
        }
    }
}
