using FShopV2.Base.Messages;
using FShopV2.Base.Types;
using FShopV2.Base.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Base.MessageModels.Customers
{
    [MessageNamespace(CodeConstant.ServicesName.CUSTOMER_SERVICE)]
    public class CreateCustomer:ICommand, IIdentifiable
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }

        [JsonConstructor]
        public CreateCustomer(Guid id, string fullName, string email, string phone, string address)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
