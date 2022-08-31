using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Users.IBL;
using Users.Model;
using Users.WebAPI.SelfHosting;

namespace UserWebApi.Tests
{
    [TestClass]
    public class UserUnitTest
    {
       
        [TestMethod]
        public void GetReturnsUserWithSameId()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetUserByID(1))
                .Returns(new UserModel { Id = 1 });

            var controller = new UserController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetUserByID(1);
            var contentResult = actionResult as OkNegotiatedContentResult<UserModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }
        [TestMethod]
        public void GetUserByIdReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var controller = new UserController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetUserByID(10);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostNewUser()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var controller = new UserController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.PostNewUser(new UserModel { Id = 4,CreationTime = DateTime.Now.ToShortDateString(),EmailAddress= "jamie.macdermont@test.com",FirstName = "Jamie", LastName = "Macdermonet" ,NotesField = "Business Analyst" });
            var contentResult = actionResult as CreatedAtRouteNegotiatedContentResult<UserModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(4, contentResult.Content.Id);
        }

        [TestMethod]
        public void PutReturnsContentResult()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var controller = new UserController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Put(new UserModel { Id = 1, CreationTime = DateTime.Now.ToShortDateString(), EmailAddress = "jamie.macdermont@test.com", FirstName = "Jamie", LastName = "Macdermonet", NotesField = "Business Analyst" });
            var contentResult = actionResult as NegotiatedContentResult<UserModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void DeleteReturnsOk()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var controller = new UserController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        private IList<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>

            {
            new UserModel { Id = 1, FirstName = "Rich", LastName = "Grey", EmailAddress = "rich.grey@test.com", NotesField = "Architect", CreationTime = DateTime.Now.ToShortDateString()},
            new UserModel { Id = 2, FirstName = "Ian", LastName = "Warnett", EmailAddress = "ian.warnett@test.com", NotesField = "Product Owner", CreationTime = DateTime.Now.ToShortDateString()},
            new UserModel { Id = 3, FirstName = "Adam", LastName = "Whitlock", EmailAddress = "adam.whitlock@test.com", NotesField = "Business Analyst", CreationTime = DateTime.Now.ToShortDateString()},
            };
            return users;
        }

    }
}
