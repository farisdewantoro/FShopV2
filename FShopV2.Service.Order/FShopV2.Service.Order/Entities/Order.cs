using FShopV2.Base.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Entities
{
    public class Order:BaseEntity
    {
        public Guid CustomerId { get; private set; }
        public IEnumerable<OrderItem> Items { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string Currency { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order(Guid customerId, IEnumerable<OrderItem> items, decimal totalAmount, string currency, OrderStatus status)
        {
            CustomerId = customerId;
            Items = items;
            TotalAmount = totalAmount;
            Currency = currency;
            Status = status;
        }
    }
    public enum OrderStatus : byte
    {
        Created = 0,
        Approved = 1,
        Completed = 2,
        Canceled = 3,
        Revoked = 4
    }
}
