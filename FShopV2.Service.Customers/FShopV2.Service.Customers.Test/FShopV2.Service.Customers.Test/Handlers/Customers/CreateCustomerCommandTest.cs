using FShopV2.Base.MessageModels.Customers;
using FShopV2.Base.MongoDB;
using FShopV2.Base.RabbitMQ;
using FShopV2.Service.Customers.Entities;
using FShopV2.Service.Customers.Handlers.Customers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FShopV2.Service.Customers.Test.Handlers.Customers
{
    public class CreateCustomerCommandTest
    {
        private readonly Mock<IMongoRepository<Customer>> _stubMongoRepository;
        private readonly Mock<IBusPublisher> _stubBusPublisher;
        private readonly Mock<ICorrelationContext> _stubContext;
        public CreateCustomerCommandTest()
        {
            _stubMongoRepository = new Mock<IMongoRepository<Customer>>();
            _stubBusPublisher = new Mock<IBusPublisher>();
            _stubContext = new Mock<ICorrelationContext>();
        }

        [Fact]
        public void HandleAsync_Should_Create_Customer_And_Publish_Event()
        {
            //arrange
            CreateCustomer command = new CreateCustomer(Guid.NewGuid(), "testing name", "testing@gmail.com", "08139669123", "komp no 19");
            Customer user = new Customer(command.Id, command.FullName, command.Email, command.Phone, command.Address);
            _stubMongoRepository.Setup(x => x.AddAsync(It.IsAny<Customer>())).Verifiable();
            _stubBusPublisher.Setup(x => x.PublishAsync(It.IsAny<CustomerCreated>(), _stubContext.Object)).Verifiable();

            var mockCreateCustomerCommand = new CreateCustomerCommand(_stubMongoRepository.Object, _stubBusPublisher.Object);

            //act
            mockCreateCustomerCommand.HandleAsync(command,_stubContext.Object);
            //assert
            _stubMongoRepository.Verify();
            _stubBusPublisher.Verify();
        }
    }
}
