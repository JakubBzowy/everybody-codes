using EverybodyCodes.Application.Cameras;
using EverybodyCodes.Domain.Entities;
using EverybodyCodes.Domain.Repositories;
using FluentAssertions;
using Moq;
using System.Diagnostics;

namespace EverybodyCodes.UnitTests
{
    public class CamerasServiceTests
    {
        private readonly Mock<ICamerasRepository> _mockRepository;
        private readonly CamerasService _camerasService;

        public CamerasServiceTests()
        {
            _mockRepository = new Mock<ICamerasRepository>();
            _camerasService = new CamerasService(_mockRepository.Object);
        }

        [Fact]
        public async Task SearchForCamerasByNameAsync_ShouldReturnSpecificCameras_WhenCorrectPartOfNamePassed()
        {            
            //Arrange
            List<Camera> cameras = new List<Camera>
            {
                new Camera { Number = 501, Name = "UTR-CM-501 Neude rijbaan voor Postkantoor", Latitude = "52.093421", Longitude = "5.118278" },
                new Camera { Number = 503, Name = "UTR-CM-503 Neude plein", Latitude = "52.093448", Longitude = "5.118536" },
                new Camera { Number = 504, Name = "UTR-CM-504 Neude / Schoutenstraat", Latitude = "52.092995", Longitude = "5.119088" }
            };

            _mockRepository.Setup(repo => repo.SearchForCamerasByNameAsync("Neude")).ReturnsAsync(cameras);

            // Act
            var result = await _camerasService.SearchForCamerasByNameAsync("Neude");

            // Assert
            result.Should().HaveCount(3);
            result.Should().Contain(c => c.Number == 501);
            result.Should().Contain(c => c.Number == 503);
            result.Should().Contain(c => c.Number == 503);
        }

        [Fact]
        public async Task SearchForCamerasByNameAsync_ShouldReturnEmptyList_WhenIncorrectPartOfNamePassed()
        {
            //Arrange
            var cameras = new List<Camera>
            {
                new Camera { Number = 501, Name = "UTR-CM-501 Neude rijbaan voor Postkantoor", Latitude = "52.093421", Longitude = "5.118278" },
            };

            _mockRepository.Setup(repo => repo.SearchForCamerasByNameAsync("Neude")).ReturnsAsync(cameras);

            // Act
            var result = await _camerasService.SearchForCamerasByNameAsync("NeudeXYZ");

            // Assert
            result.Should().BeEmpty();
        }
    }
}
