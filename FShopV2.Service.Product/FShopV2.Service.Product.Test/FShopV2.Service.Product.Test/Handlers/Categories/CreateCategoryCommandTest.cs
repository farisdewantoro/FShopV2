using FShopV2.Base.MessageModels.Products;
using FShopV2.Base.MongoDB;
using FShopV2.Base.RabbitMQ;
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
        private Mock<IBusPublisher> _stubBusPublisher;
        private Mock<ICorrelationContext> _stubCorrelationContext;
        public CreateCategoryCommandTest()
        {
             _stubMongoRepository = new Mock<IMongoRepository<Category>>();
            _stubBusPublisher = new Mock<IBusPublisher>();
            _stubCorrelationContext = new Mock<ICorrelationContext>();
        }
        [Fact]
        public void HandleAsync_Insert_ShouldCreateNewCategory()
        {
            //Arrange
            CreateCategory command = new CreateCategory(Guid.NewGuid(),"Testing Category Name","testing category deskripsi");
            _stubMongoRepository.Setup(x => x.AddAsync(It.IsAny<Category>())).Verifiable();
            _stubBusPublisher.Setup(x => x.PublishAsync(It.IsAny<CategoryCreated>(), _stubCorrelationContext.Object)).Verifiable();

            var mockCreateCategoryCommand = new CreateCategoryCommand(_stubMongoRepository.Object, _stubBusPublisher.Object);
            //Act
            mockCreateCategoryCommand.HandleAsync(command, _stubCorrelationContext.Object);

            //Assert
            _stubMongoRepository.Verify();
            _stubBusPublisher.Verify();
        }


    }
}
