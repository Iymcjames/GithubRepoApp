using GithubRepoApp.Controllers;
using System.Web.Mvc;
using Xunit;

namespace GithubRepos.Test
{
    public class HomeControllerTest
    {
        private readonly HomeController homeControllerUnderTest;
        public HomeControllerTest()
        {
            homeControllerUnderTest = new HomeController();
        }

        [Fact]
        public void HomeController_ReturnsIndexView()
        {
            //Act
            var result = homeControllerUnderTest.Index();

            // Assert
            Assert.NotNull(result);
        }
    }
}
