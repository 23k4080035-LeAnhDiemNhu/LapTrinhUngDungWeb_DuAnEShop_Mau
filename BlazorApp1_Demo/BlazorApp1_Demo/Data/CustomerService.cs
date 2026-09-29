using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp1_Demo.Data
{
    public class CustomerService : ICustomerService
    {
        public string Uid { get; set; }
        private List<Customer> customers;

        public CustomerService()
        {
            Uid = Guid.NewGuid().ToString();
            customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Tom" },
                new Customer { Id = 2, Name = "John" },
                new Customer { Id = 3, Name = "Jane" }
            };
        }

        public Customer GetCustomerById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id)!;
        }
    }
}
