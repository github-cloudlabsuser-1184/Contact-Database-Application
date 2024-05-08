using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Xunit;

namespace CRUD_application_2.Tests.Controllers
{

    public class UserControllerTests
    {
        [Fact]
        public void Index_ReturnsViewWithUserList()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
                {
                    new User { Id = 1, Name = "John", Email = "john@example.com" },
                    new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
                };
            UserController.userlist = userList;

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userList, result.Model);
        }

        [Fact]
        public void Details_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
                {
                    new User { Id = 1, Name = "John", Email = "john@example.com" },
                    new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
                };
            UserController.userlist = userList;
            var userId = 1;

            // Act
            var result = controller.Details(userId) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userList.FirstOrDefault(u => u.Id == userId), result.Model);
        }

        [Fact]
        public void Create_ReturnsView()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Create_Post_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John", Email = "john@example.com" };

            // Act
            var result = controller.Create(user) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void Edit_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
                {
                    new User { Id = 1, Name = "John", Email = "john@example.com" },
                    new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
                };
            UserController.userlist = userList;
            var userId = 1;

            // Act
            var result = controller.Edit(userId) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userList.FirstOrDefault(u => u.Id == userId), result.Model);
        }

        [Fact]
        public void Edit_Post_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
                {
                    new User { Id = 1, Name = "John", Email = "john@example.com" },
                    new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
                };
            UserController.userlist = userList;
            var userId = 1;
            var user = new User { Id = 1, Name = "John Doe", Email = "johndoe@example.com" };

            // Act
            var result = controller.Edit(userId, user) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void Delete_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
                {
                    new User { Id = 1, Name = "John", Email = "john@example.com" },
                    new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
                };
            UserController.userlist = userList;
            var userId = 1;

            // Act
            var result = controller.Delete(userId) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userList.FirstOrDefault(u => u.Id == userId), result.Model);
        }

        [Fact]
        public void Delete_Post_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
                {
                    new User { Id = 1, Name = "John", Email = "john@example.com" },
                    new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
                };
            UserController.userlist = userList;
            var userId = 1;

            // Act
            var result = controller.Delete(userId, null) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }
    }
}
