﻿using FShopV2.Base.Handlers;
using FShopV2.Base.MessageModels.Customers;
using FShopV2.Base.MongoDB;
using FShopV2.Base.RabbitMQ;
using FShopV2.Service.Order.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Handlers.Customers
{
    public class CustomerCreatedEvent:IEventHandler<CustomerCreated>
    {
        private readonly IMongoRepository<Customer> mongoRepository;

        public CustomerCreatedEvent(IMongoRepository<Customer> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public async Task HandleAsync(CustomerCreated @event, ICorrelationContext context)
            => await mongoRepository.AddAsync(new Customer(@event.Id,@event.FullName,@event.Email, @event.Phone, @event.Address));
    }
}
