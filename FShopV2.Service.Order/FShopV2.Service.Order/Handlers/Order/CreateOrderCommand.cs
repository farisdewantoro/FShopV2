using FShopV2.Base.Handlers;
using FShopV2.Base.MessageModels.Orders;
using FShopV2.Base.MongoDB;
using FShopV2.Base.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Entities = FShopV2.Service.Order.Entities;
namespace FShopV2.Service.Order.Handlers.Order
{
    public class CreateOrderCommand : ICommandHandler<CreateOrder>
    {
        private readonly IMongoRepository<Entities.Order> mongoRepository;

        public CreateOrderCommand(IMongoRepository<Entities.Order> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }
        public Task HandleAsync(CreateOrder command, ICorrelationContext context)
        {
            //Entities.Order order = new Entities.Order(command);

            throw new Exception();
        }
    }
}
