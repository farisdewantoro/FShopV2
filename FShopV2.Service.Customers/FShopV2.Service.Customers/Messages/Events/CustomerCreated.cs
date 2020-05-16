using FShopV2.Base.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Customers.Messages.Events
{
    public class CustomerCreated:IEvent
    {
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        [JsonConstructor]
        public CustomerCreated(string email, string phone, string address)
        {
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
