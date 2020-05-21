using FShopV2.Base.Handlers;
using FShopV2.Base.MessageModels.Products;
using FShopV2.Base.MongoDB;
using FShopV2.Base.RabbitMQ;
using FShopV2.Service.Order.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Handlers.Products
{
    public class CategoryCreatedEvent:IEventHandler<CategoryCreated>
    {
        private readonly IMongoRepository<Category> mongoRepository;

        public CategoryCreatedEvent(IMongoRepository<Category> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }
        public async Task HandleAsync(CategoryCreated @event, ICorrelationContext context)
            => await mongoRepository.AddAsync(new Category(@event.Id, @event.Name, @event.Description));
        
    }
}
