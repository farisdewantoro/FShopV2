using FShopV2.Base.Handlers;
using FShopV2.Base.MongoDB;
using FShopV2.Base.RabbitMQ;
using FShopV2.Service.Customers.Entities;
using FShopV2.Service.Customers.Messages.Commands;
using FShopV2.Service.Customers.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Customers.Handlers.Customers
{
    public class CreateCustomerCommand : ICommandHandler<CreateUser>
    {
        private readonly IMongoRepository<Customer> mongoRepository;
        private readonly IBusPublisher busPublisher;

        public CreateCustomerCommand(IMongoRepository<Customer> mongoRepository,IBusPublisher busPublisher)
        {
            this.mongoRepository = mongoRepository;
            this.busPublisher = busPublisher;
        }

        public Task HandleAsync(CreateUser command, ICorrelationContext context)
        {
            Customer user = new Customer(command);
            mongoRepository.AddAsync(user);
            return busPublisher.PublishAsync(new CustomerCreated(command.Email, command.Phone, command.Address),context);
        }
    }
}
