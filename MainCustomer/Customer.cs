using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCustomer
{
    public class MainCustomer
    {
        string FirstName { get; }
        string LastName { get; }
        string CustType { get; }
        string Email { get; }

        public MainCustomer() { }
        public MainCustomer (string firstName, string lastName, string custType, string email )
        {
            FirstName = firstName;
            LastName = lastName;
            CustType = custType;
            Email = email;
        }
    }
}
