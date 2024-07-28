using EverybodyCodes.Infrastructure.Repositories;
using FluentAssertions;

namespace EverybodyCodes.Tests.Unit
{
    public class CamerasRepositoryTests
    {
        private readonly string _testFilePath;

        public CamerasRepositoryTests()
        {
            _testFilePath = @"C:\dev\everybody-codes-backend\EverybodyCodes\EverybodyCodes.UnitTests\cameras-test.csv";
        }

        [Fact]
        public async Task GetAllCamerasAsync_ShouldReturnAllCamerasFromCsv()
        {
            //Arrange
            var repository = new CamerasRepository(_testFilePath);

            //Act
            var cameras = await repository.GetAllCamerasAsync();

            //Assert
            cameras.Should().HaveCount(3);
        }
    }
}
