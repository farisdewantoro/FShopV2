using FShopV2.Base.Messages;
using FShopV2.Base.Types;
using FShopV2.Base.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Base.MessageModels.Orders
{
    [MessageNamespace(CodeConstant.ServicesName.ORDER_SERVICE)]
    public class CreateOrder:ICommand,IIdentifiable
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public IEnumerable<OrderItem> Items { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string Currency { get; private set; }
        public OrderStatus Status { get; private set; }

        [JsonConstructor]
        public CreateOrder(Guid customerId, IEnumerable<OrderItem> items, decimal totalAmount, string currency, OrderStatus status)
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
    public class OrderItem:IIdentifiable
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public OrderItem(Guid id, string name, int quantity, decimal unitPrice)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
