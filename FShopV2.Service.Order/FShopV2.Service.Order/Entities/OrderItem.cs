using FShopV2.Base.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Entities
{
    public class OrderItem :BaseEntity
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public OrderItem(string name, int quantity, decimal unitPrice)
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
