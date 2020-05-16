using FShopV2.Base.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Customers.Messages.Commands
{
    public class CreateUser:ICommand
    {
        public Guid Id { get; set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
        public string Address { get;  set; }

        [JsonConstructor]
        public CreateUser(Guid id,string email, string phone, string address)
        {
            Id = id;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
