using FShopV2.Base.MongoDB;
using FShopV2.Service.Product.Dto;
using FShopV2.Service.Product.Entities;
using FShopV2.Service.Product.Handlers.Categories;
using FShopV2.Service.Product.Test.DummyData.Categories;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FShopV2.Service.Product.Test.Handlers.Categories
{
    public class CreateCategoryCommandTest
    {
        private Mock<IMongoRepository<Category>> _stubMongoRepository;
        public CreateCategoryCommandTest()
        {
             _stubMongoRepository = new Mock<IMongoRepository<Category>>();

        }
        [Fact]
        public void HandleAsync_Insert_ShouldCreateNewCategory()
        {
            CreateCategory command = new CreateCategory();
            command.Name = "Testing";
            command.Description = "wadaw";

            _stubMongoRepository.Setup(x => x.AddAsync(It.IsAny<Category>())).Verifiable();
             var mockCreateCategoryCommand = new CreateCategoryCommand(_stubMongoRepository.Object);
            mockCreateCategoryCommand.HandleAsync(command);
            _stubMongoRepository.Verify();
        }
      

    }
}
