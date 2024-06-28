using BookingSystem.API.Controllers;
using BookingSystem.Application.Interfaces;
using BookingSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BookingSystem.Tests.ApiTests
{
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _controller = new UsersController(_mockUserService.Object);
        }

        [Fact]
        public void Register_ReturnsOkResult()
        {
            // Arrange
            var user = new UserEntity { Username = "testuser", Password = "password" };

            // Act
            var result = _controller.Register(user);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Login_ReturnsOkResult_WithToken()
        {
            // Arrange
            var user = new UserEntity { Username = "testuser", Password = "password" };
            _mockUserService.Setup(s => s.Login(It.IsAny<UserEntity>())).Returns("token");

            // Act
            var result = _controller.Login(user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("token", okResult.Value);
        }

        [Fact]
        public void Login_ReturnsUnauthorizedResult_WhenUserNotFound()
        {
            // Arrange
            var user = new UserEntity { Username = "testuser", Password = "password" };
            _mockUserService.Setup(s => s.Login(It.IsAny<UserEntity>())).Returns<string>(null);

            // Act
            var result = _controller.Login(user);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
