// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Security.Claims;
// using System.Threading.Tasks;
// using lp_task.Controllers;
// using lp_task.DTOs;
// using lp_task.Models;
// using lp_task.Services;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using Xunit;
//
// namespace lp_task.Tests.Controllers;
//
// public class MovieControllerTests
// {
//     private readonly Mock<IMovieService> _movieServiceMock;
//     private readonly Mock<UserManager<VodUser>> _userManagerMock;
//     private readonly MovieController _controller;
//
//     public MovieControllerTests()
//     {
//         _movieServiceMock = new Mock<IMovieService>();
//         _userManagerMock = new Mock<UserManager<VodUser>>(
//             Mock.Of<IUserStore<VodUser>>(),
//             null, null, null, null, null, null, null, null);
//
//         _controller = new MovieController(_movieServiceMock.Object, _userManagerMock.Object);
//     }
//
//     [Fact]
//     public async Task GetMoviesAsync_ReturnsAllMovies_WhenNoQueryParametersAreSpecified()
//     {
//         // Arrange
//         var movies = new List<MovieDto>
//         {
//             new MovieDto {Title = "Movie 1", Genre = "Genre 1", CoverImage = "CoverImage 1", IsFavorite = false},
//         };
//         _movieServiceMock.Setup(s => s.GetMoviesAsync(0)).ReturnsAsync(movies);
//
//         // Act
//         var result = await _controller.GetMoviesAsync();
//
//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result.Result);
//         var returnedMovies = Assert.IsAssignableFrom<IEnumerable<MovieDto>>(okResult.Value);
//         Assert.Equal(movies.Count, returnedMovies.Count());
//         Assert.Equal(movies.Select(m => m.Id), returnedMovies.Select(m => m.Id));
//     }
//
//     [Fact]
//     public async Task GetMoviesAsync_ReturnsMoviesByCategory_WhenCategoryQueryParameterIsSpecified()
//     {
//         // Arrange
//         var movies = new List<MovieDto>
//         {
//             new MovieDto { Id = "1", Title = "Movie 1" },
//             new MovieDto { Id = "2", Title = "Movie 2" },
//             new MovieDto { Id = "3", Title = "Movie 3" }
//         };
//         _movieServiceMock.Setup(s => s.GetAnnouncementMoviesAsync(0)).ReturnsAsync(movies);
//
//         // Act
//         var result = await _controller.GetMoviesAsync(category: Category.Announcement);
//
//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result.Result);
//         var returnedMovies = Assert.IsAssignableFrom<IEnumerable<MovieDto>>(okResult.Value);
//         Assert.Equal(movies.Count, returnedMovies.Count());
//         Assert.Equal(movies.Select(m => m.Id), returnedMovies.Select(m => m.Id));
//     }
//
//     [Fact]
//     public async Task GetMoviesAsync_ReturnsBadRequest_WhenFavoriteCategoryIsSpecifiedAndUserIsNotAuthenticated()
//     {
//         // Arrange
//
//         // Act
//         var result = await _controller.GetMoviesAsync(category: Category.Favorite);
//
//         // Assert
//         var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
//         Assert.Equal("User is not authenticated", badRequestResult.Value);
//     }
//
//     [Fact]
//     public async Task GetMoviesAsync_ReturnsFavoriteMovies_WhenFavoriteCategoryIsSpecifiedAndUserIsAuthenticated()
//     {
//         // Arrange
//         var movies = new List<MovieDto>
//         {
//             new MovieDto { Id = "1", Title = "Movie 1" },
//             new MovieDto { Id = "2", Title = "Movie 2" },
//             new MovieDto { Id = "3", Title = "Movie 3" }
//         };
//         _movieServiceMock.Setup(s => s.GetFavoriteMoviesAsync(0, "validUserId")).ReturnsAsync(movies);
//
//         var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
//         {
//             new Claim(ClaimTypes.NameIdentifier, "validUserId")
//         }, "mock"));
//
//         _controller.ControllerContext = new ControllerContext
//         {
//             HttpContext = new DefaultHttpContext { User = user }
//         };
//
//         _userManagerMock.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("validUserId");
//
//         // Act
//         var result = await _controller.GetMoviesAsync(category: Category.Favorite);
//
//         // Assert
//         Assert.IsType<OkObjectResult>(result.Result);
//         var okResult = result.Result as OkObjectResult;
//         Assert.Equal(movies, okResult.Value);
//     }
//
//     [Fact]
//     public async Task MarkMovieAsFavorite_ReturnsBadRequest_WhenMovieIdIsNull()
//     {
//         // Act
//         var result = await _controller.MarkMovieAsFavorite(null);
//
//         // Assert
//         Assert.IsType<BadRequestObjectResult>(result);
//         var badRequestResult = (BadRequestObjectResult)result;
//         Assert.Equal("Movie ID is null or empty", badRequestResult.Value);
//     }
//
//     [Fact]
//     public async Task MarkMovieAsFavorite_ReturnsBadRequest_WhenMovieIdIsEmpty()
//     {
//         // Act
//         var result = await _controller.MarkMovieAsFavorite("");
//
//         // Assert
//         Assert.IsType<BadRequestObjectResult>(result);
//         var badRequestResult = (BadRequestObjectResult)result;
//         Assert.Equal("Movie ID is null or empty", badRequestResult.Value);
//     }
//
//     [Fact]
//     public async Task MarkMovieAsFavorite_ReturnsBadRequest_WhenUserIsNotAuthenticated()
//     {
//         // Arrange
//         var movieId = "1";
//         _userManagerMock.Setup(m => m.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("user1");
//
//         // Act
//         var result = await _controller.MarkMovieAsFavorite(movieId);
//
//         // Assert
//         Assert.IsType<BadRequestObjectResult>(result);
//         var badRequestResult = (BadRequestObjectResult)result;
//         Assert.Equal("User is not authenticated", badRequestResult.Value);
//     }
// }