using FluentAssertions;
using FShopV2.Base.MessageModels.Products;
using FShopV2.Service.Product.Entities;
using FShopV2.Service.Product.IntergationTest.Fixture;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FShopV2.Service.Product.IntergationTest.Handlers.Categories
{
    public class CreateCategoryCommandTest: IClassFixture<MongoDbFixture>,IClassFixture<RabbitMqFixture>, IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly MongoDbFixture _mongoDbFixture;
        private readonly RabbitMqFixture _rabbitMqFixture;

        public CreateCategoryCommandTest(MongoDbFixture mongoDbFixture,RabbitMqFixture rabbitMqFixture)
        {
            _mongoDbFixture = mongoDbFixture;
            _rabbitMqFixture = rabbitMqFixture;
        }
        [Fact]
        public async Task Create_Category_Command_Should_Insert_NewData_And_Publish_CategoryCreatedEvent()
        {
            //Arrange
            var category = new Category(Guid.NewGuid(), "Testing Name", "Testing Desc");
            await _mongoDbFixture.Repository.AddAsync(category);
            var command = new CategoryCreated(category.Id, category.Name, category.Description);

            //Act
            var creationTask = await _rabbitMqFixture.SubscribeAndGetAsync<CategoryCreated, Category>(_mongoDbFixture.GetMongoEntity, command.Id);
            await _rabbitMqFixture.PublishAsync(command);
            var createdCategoryMessage = await creationTask.Task;

            //Assert
            createdCategoryMessage.Id.Should().Be(command.Id);
            createdCategoryMessage.Name.Should().Be(command.Name);
            createdCategoryMessage.Description.Should().Be(command.Description);
        }
    }
}
