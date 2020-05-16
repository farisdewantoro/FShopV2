using FShopV2.Base.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Messages.Commands
{
    public class CreateOrder:ICommand
    {
        public Guid UserId { get; set; }
        public double Amount { get; set; }
        public string ShipAddress { get; set; }
        public string Phone { get; set; }
        public List<Guid> ProductId { get; set; }

        [JsonConstructor]
        public CreateOrder(Guid userId, double amount, string shipAddress, string phone, List<Guid> productId)
        {
            UserId = userId;
            Amount = amount;
            ShipAddress = shipAddress;
            Phone = phone;
            ProductId = productId;
        }
    }
}
