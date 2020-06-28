using FShopV2.Service.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Service.Customers.Test.DummyData
{
    public class CustomerData
    {
        public List<Customer> GetCustomers
        {
            get
            {
                if (customers == null)
                {
                    return Populate();
                }
                return customers;
            }
        }
        public List<Customer> customers = null;
        public int TotalData { get;set; } = 10;
        public virtual List<Customer> Populate()
        {
            customers = new List<Customer>();
            for (int i = 0; i <= TotalData; i++)
            {
                customers.Add(new Customer(Guid.NewGuid(), "TESTING NAME" + i, "email@test.com" + i,"081394691332","komp data komp no 19"));
            }
            return customers;
        }
    }

}
