using FShopV2.Base.Types;
using FShopV2.Service.Customers.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Customers.Entities
{
    public class Customer :BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        
        public Customer(Guid id,string fullName,string email, string phone, string address)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Address = address;
        }
     
    }
}
