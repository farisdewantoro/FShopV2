using FluentAssertions;
using FShopV2.Base.MongoDB;
using FShopV2.Base.Types;
using FShopV2.Service.Customers.Dto;
using FShopV2.Service.Customers.Entities;
using FShopV2.Service.Customers.Handlers.Customers;
using FShopV2.Service.Customers.Queries;
using FShopV2.Service.Customers.Test.DummyData;
using Moq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace FShopV2.Service.Customers.Test.Handlers.Customers
{
    public class BrowseCustomerQueryHandlerTest
    {
        private readonly Mock<IMongoRepository<Customer>> _stubMongoRepository;
        public BrowseCustomerQueryHandlerTest()
        {
            _stubMongoRepository = new Mock<IMongoRepository<Customer>>();
        }

        [Theory]
        [InlineData(1,20,30)]
        [InlineData(2, 10, 10)]
        [InlineData(3, 10, 100)]
        [InlineData(1, 10, 100)]
        public async void HandleAsync_Should_Browse_Customer_And_Return_Paged_Results(int page, int resultsPerPage, int totalData)
        {
            //arrange
            BrowseCustomers query = new BrowseCustomers();
            var customerDummyData = new CustomerData();
            customerDummyData.TotalData = totalData;
            int totalResults = customerDummyData.GetCustomers.Count;

            var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);
            var results = Task.FromResult(PagedResult<Customer>.Create(customerDummyData.GetCustomers, page, resultsPerPage, totalPages, totalResults));

            _stubMongoRepository.Setup(x => x.BrowseAsync(It.IsAny<Expression<Func<Customer, bool>>>(), query)).Returns(results);

            //act
            var mockBrowseCustomerQueryHandler = new BrowseCustomerQueryHandler(_stubMongoRepository.Object);
            PagedResult<CustomerDto> customer = await mockBrowseCustomerQueryHandler.HandleAsync(query);
            //assert
            customer.Items.Should()
                .BeEquivalentTo(results.Result.Items.Select(c => new CustomerDto(c.Id, c.FullName, c.Email, c.Phone, c.Address)));
            customer.TotalPages.Should().Be(results.Result.TotalPages);
            customer.TotalResults.Should().Be(results.Result.TotalResults);
            customer.CurrentPage.Should().Be(results.Result.CurrentPage);
        }
    }
}
