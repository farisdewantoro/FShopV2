using FShopV2.Base.Handlers;
using FShopV2.Base.MessageModels.Products;
using FShopV2.Base.MongoDB;
using FShopV2.Base.RabbitMQ;
using FShopV2.Service.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Product.Handlers.Categories
{
    public class CreateCategoryCommand: ICommandHandler<CreateCategory>
    {
        private readonly IMongoRepository<Category> _mongoRepository;
        private readonly IBusPublisher _busPublisher;

        public CreateCategoryCommand(IMongoRepository<Category> mongoRepository,IBusPublisher busPublisher)
        {
            _mongoRepository = mongoRepository;
            _busPublisher = busPublisher;
        }
        public  Task HandleAsync(CreateCategory command, ICorrelationContext context)
        {
            Category category = new Category(command.Id,command.Name, command.Description);
             _mongoRepository.AddAsync(category);

           return _busPublisher.PublishAsync(
                new CategoryCreated(command.Id, command.Name, command.Description),context);  
        }

      
    }
}
