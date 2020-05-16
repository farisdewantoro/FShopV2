using FShopV2.Base.Handlers;
using FShopV2.Base.MongoDB;
using FShopV2.Base.RabbitMQ;
using FShopV2.Service.Product.Entities;
using FShopV2.Service.Product.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Product.Handlers.Categories
{
    public class CreateCategoryCommand: ICommandHandler<CreateCategory>
    {
        private readonly IMongoRepository<Category> _mongoRepository;

        public CreateCategoryCommand(IMongoRepository<Category> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }
        public Task HandleAsync(CreateCategory command, ICorrelationContext context)
        {
            Category category = new Category(command.Id,command.Name, command.Description);
            
            return _mongoRepository.AddAsync(category);
        }

      
    }
}
