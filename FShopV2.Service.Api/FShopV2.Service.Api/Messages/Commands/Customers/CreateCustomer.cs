﻿using FShopV2.Base.Messages;
using FShopV2.Base.Types;
using FShopV2.Base.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Api.Messages.Commands.Customers
{
    [MessageNamespace(CodeConstant.ServicesName.CUSTOMER_SERVICE)]
    public class CreateCustomer:ICommand,IIdentifiable
    {

        public Guid Id { get; private set; }
        public string FullName { get; set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }

        public CreateCustomer(Guid id,string fullName, string email, string phone, string address)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}