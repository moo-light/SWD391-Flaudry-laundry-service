using AutoFixture;
using Domain.Entities;
using Domain.Tests;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Tests
{
    public class AppDbContextTests : SetupTest, IDisposable
    {
        [Fact]
        public async Task AppDbContext_ChemicalsDbSetShouldReturnCorrectData()
        {

            var mockData = _fixture.Build<LaundryOrder>().CreateMany(10).ToList();
            await _dbContext.Orders.AddRangeAsync(mockData);
            
            await _dbContext.SaveChangesAsync();
            var result = await _dbContext.Orders.ToListAsync();
            result.Should().BeEquivalentTo(mockData);
        }

        [Fact]
        public async Task AppDbContext_ChemicalsDbSetShouldReturnEmptyListWhenNotHavingData()
        {
            var result = await _dbContext.Orders.ToListAsync();
            result.Should().BeEmpty();
        }
    }
}
