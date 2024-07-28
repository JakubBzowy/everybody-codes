using EverybodyCodes.Infrastructure.Repositories;
using FluentAssertions;
using Xunit;

namespace EverybodyCodes.Tests.Unit
{
    public class CamerasRepositoryTests
    {
        private readonly string _testFilePath;

        public CamerasRepositoryTests()
        {
            _testFilePath = @"C:\dev\everybody-codes-backend\EverybodyCodes\EverybodyCodes.Tests\cameras-test.csv";
        }

        [Fact]
        public void GetAllCameras_ShouldReturnAllCamerasFromCsv()
        {
            //Arrange
            var repository = new CamerasRepository(_testFilePath);

            //Act
            var cameras = repository.GetAllCameras();

            //Assert
            cameras.Should().HaveCount(3);
        }
    }
}
