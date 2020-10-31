using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public class GreetingContent_Repo
    {
        private List<Customer> _contentList = new List<Customer>();

        //Create
        public bool AddCustomerToList(Customer listContent)
        {
            int startCount = _contentList.Count;
            _contentList.Add(listContent);
            bool wasAdded = (_contentList.Count > startCount) ? true : false;
            return wasAdded;
        }
        //Read
        public List<Customer> GetCustomers()
        {
            return _contentList;
        }
        public Customer GetCustomerByLastName(string lastName)
        {
            foreach (Customer listContent in _contentList)
            {
                if (listContent.LastName.ToLower() == lastName.ToLower())
                {
                    return listContent;
                }
            }
            return null;
        }
        //Update
        public bool UpdateCustomerInfo(string originalName, Customer newCust)
        {
            Customer oldCust = GetCustomerByLastName(originalName);
            if (oldCust != null)
            {
               
                oldCust.FirstName = newCust.FirstName;
                oldCust.LastName = newCust.LastName;
                oldCust.CustType = newCust.CustType;
                oldCust.Email = newCust.Email;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteExistingCustomer(Customer existingCust)
        {
            bool deleteCust = _contentList.Remove(existingCust);
            return deleteCust;
        }
    }
}
