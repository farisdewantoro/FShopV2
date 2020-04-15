using FShopV2.Base.MongoDB;
using FShopV2.Service.Product.Dto;
using FShopV2.Service.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Product.Handlers.Categories
{
    public class CreateCategoryCommand
    {
        private readonly IMongoRepository<Category> _mongoRepository;

        public CreateCategoryCommand(IMongoRepository<Category> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }
        public Task HandleAsync(CreateCategory command)
        {
            Category category = new Category(command.Name, command.Description);
            
            return _mongoRepository.AddAsync(category);
        }
    }
}
