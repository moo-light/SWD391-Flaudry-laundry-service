using Application;
using Application.Interfaces;
using AutoFixture;
using Domain.Entities;
using Domain.Tests;
using FluentAssertions;
using Moq;

namespace Infrastructures.Tests
{
    public class UnitOfWorkTests : SetupTest
    {
        //private readonly IUnitOfWork _unitOfWork;
        //public UnitOfWorkTests()
        //{
        //    _unitOfWork = new UnitOfWork(
        //        _dbContext,
        //        _orderRepositoryMock.Object,
        //        _userRepository.Object
        //        );
        //}

        //[Fact]
        //public async Task TestUnitOfWork()
        //{
        //    // arrange
        //    var mockData = _fixture.Build<Order>().CreateMany(10).ToList();

        //    _orderRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(mockData);

        //    // act
        //    var items = await _unitOfWork.OrderRepository.GetAllAsync();

        //    // assert
        //    items.Should().BeEquivalentTo(mockData);
        //}

    }
}
