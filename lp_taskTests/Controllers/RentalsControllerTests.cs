using System.Security.Claims;
using lp_task.Controllers;
using lp_task.DTOs;
using lp_task.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Xunit;
using Xunit.Abstractions;

namespace lp_task.Tests.Controllers;

public class RentalsControllerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<IRentalService> _rentalServiceMock;
    private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
    private readonly RentalsController _controller;

    public RentalsControllerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _rentalServiceMock = new Mock<IRentalService>();
        _userManagerMock = new Mock<UserManager<IdentityUser>>(
            Mock.Of<IUserStore<IdentityUser>>(),
            null, null, null, null, null, null, null, null);

        _controller = new RentalsController(_rentalServiceMock.Object, _userManagerMock.Object);
    }
    
    [Fact]
    public async Task GetRentalsAsync_ReturnsBadRequest_WhenUserIsNotAuthenticated()
    {
        // Arrange
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = new ClaimsPrincipal() }
        };

        // Act
        var result = await _controller.GetRentalsAsync();

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("User is not authenticated", badRequestResult.Value);
    }

    [Fact]
    public async Task GetRentalsAsync_ReturnsBadRequest_WhenUserIsLockedOut()
    {
        // Arrange
        const string userId = "123";

        var user = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userId),
            new(ClaimTypes.AuthenticationMethod, "TestAuthentication")
        }, "TestAuthentication"));

        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = user
            }
        };

        _userManagerMock.Setup(x => x.GetUserId(_controller.User)).Returns(userId);
        _userManagerMock.Setup(x => x.IsLockedOutAsync(It.IsAny<IdentityUser>())).ReturnsAsync(true);

        // Act
        var result = await _controller.GetRentalsAsync();

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("User is locked out", badRequestResult.Value);
    }
}