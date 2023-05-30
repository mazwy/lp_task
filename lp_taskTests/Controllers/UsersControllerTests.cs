using lp_task.Controllers;
using lp_task.Data;
using lp_task.DTOs;
using lp_task.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace lp_task.Tests.Controllers;

public class UsersControllerTests
{
    private readonly Mock<UserManager<VodUser>> _userManagerMock;
    private readonly Mock<VodDbContext> _contextMock;
    private readonly UsersController _controller;

    public UsersControllerTests()
    {
        _userManagerMock = new Mock<UserManager<VodUser>>(
            Mock.Of<IUserStore<VodUser>>(),
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null);

        _contextMock = new Mock<VodDbContext>();

        _controller = new UsersController(_userManagerMock.Object, _contextMock.Object);
    }

    [Fact]
    public async Task Register_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        _controller.ModelState.AddModelError("Email", "Email is required");

        // Act
        var result = await _controller.Register(new UserDto());

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.IsType<SerializableError>(badRequestResult.Value);
    }

    [Fact]
    public async Task Register_ReturnsBadRequest_WhenUserAlreadyExists()
    {
        // Arrange
        var userDto = new UserDto { Email = "john.doe@example.com" };
        _userManagerMock.Setup(x => x.FindByEmailAsync(userDto.Email)).ReturnsAsync(new VodUser());

        // Act
        var result = await _controller.Register(userDto);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("User already exists", badRequestResult.Value);
    }

    [Fact]
    public async Task Register_ReturnsBadRequest_WhenCreateUserFails()
    {
        // Arrange
        var userDto = new UserDto { Email = "john.doe@example.com" };
        _userManagerMock.Setup(x => x.FindByEmailAsync(userDto.Email)).ReturnsAsync((VodUser)null);
        _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<VodUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Password is too weak" }));

        // Act
        var result = await _controller.Register(userDto);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.IsType<SerializableError>(badRequestResult.Value);
        
        var serializableError = (SerializableError)badRequestResult.Value;
        Assert.Equal("Password is too weak", ((string[])serializableError[""])[0]);
    }
}