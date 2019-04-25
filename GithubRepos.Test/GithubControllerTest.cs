using GithubRepoApp.Controllers;
using GithubRepoApp.Services.Abstractions;
using GithubRepoApp.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;

namespace GithubRepos.Test
{
    public class GithubControllerTest
    {
        private readonly GithubController githubControllerUnderTest;
        private readonly Mock<IGitHubRepoService> mock_gitHubRepoService;
        private readonly Mock<GitHubViewModel> mock_gitHubViewModel;
        public GithubControllerTest()
        {
            //Arrange
            mock_gitHubViewModel = new Mock<GitHubViewModel>();
            mock_gitHubRepoService = new Mock<IGitHubRepoService>();
            githubControllerUnderTest = new GithubController(mock_gitHubRepoService.Object, mock_gitHubViewModel.Object);
        }

        [Fact]
        public void GitHubController_ReturnsIndexView()
        {
            //Act
            var result = githubControllerUnderTest.Index() as ViewResult;

            //Arrange
            Assert.NotNull(result.Model);
            // Assert.IsType<Mock<GitHubViewModel>>(result.ViewData.Model);
        }

        [Fact]
        public async void GetUser_RedirectToHomeIndexView_IfEmptyUsername()
        {
            //Act
            var result = (RedirectToRouteResult)await githubControllerUnderTest.GetUser("");

            //Assert
            var Values = Assert.IsType<RouteValueDictionary>(result.RouteValues);
           Assert.Equal("Index", Values.Values.FirstOrDefault());

        }
    }
}
