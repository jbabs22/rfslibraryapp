using LibraryBookApp.Controllers;
using LibraryBookApp.Models;
using LibraryBookApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace LibraryBookApp.Tests
{
    public class AccountControllerTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;
        private readonly Mock<ILogger<AccountController>> _loggerMock;

        public AccountControllerTests()
        {
            // Mock dependencies for UserManager and SignInManager
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            var contextAccessorMock = new Mock<IHttpContextAccessor>();
            var userClaimsPrincipalFactoryMock = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();
            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
                _userManagerMock.Object, contextAccessorMock.Object, userClaimsPrincipalFactoryMock.Object, null, null, null, null);

            _loggerMock = new Mock<ILogger<AccountController>>();
        }

        [Fact]
        public void Login_Get_ReturnsViewResult()
        {
            // Arrange
            var controller = new AccountController(_userManagerMock.Object, _signInManagerMock.Object, _loggerMock.Object);

            // Act
            var result = controller.Login();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); 
        }

        [Fact]
        public async Task Login_Post_ValidCredentials_RedirectsToHome()
        {
            // Arrange
            var loginViewModel = new LoginViewModel { Email = "test@example.com", Password = "password123", RememberMe = false };
            _signInManagerMock
                .Setup(sm => sm.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            var controller = new AccountController(_userManagerMock.Object, _signInManagerMock.Object, _loggerMock.Object);

            // Act
            var result = await controller.Login(loginViewModel);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
        }

        [Fact]
        public async Task Login_Post_InvalidCredentials_ReturnsViewWithError()
        {
            // Arrange
            var loginViewModel = new LoginViewModel { Email = "test@example.com", Password = "wrongpassword", RememberMe = false };
            _signInManagerMock
                .Setup(sm => sm.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            var controller = new AccountController(_userManagerMock.Object, _signInManagerMock.Object, _loggerMock.Object);

            // Act
            var result = await controller.Login(loginViewModel);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(loginViewModel, viewResult.Model);
            Assert.True(controller.ModelState.ContainsKey(string.Empty));
        }

        [Fact]
        public async Task Logout_Post_RedirectsToHome()
        {
            // Arrange
            var controller = new AccountController(_userManagerMock.Object, _signInManagerMock.Object, _loggerMock.Object);
            _signInManagerMock.Setup(sm => sm.SignOutAsync()).Returns(Task.CompletedTask);

            // Act
            var result = await controller.Logout();

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
            _signInManagerMock.Verify(sm => sm.SignOutAsync(), Times.Once); 
        }
    }
}
