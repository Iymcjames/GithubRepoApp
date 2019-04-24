using GithubRepoApp.Services.Abstractions;
using GithubRepoApp.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GithubRepoApp.Controllers
{
    public class GithubController : Controller
    {
        private readonly IGitHubRepoService gitHubRepoService;
        private readonly GitHubViewModel gitHubViewModel;

        public GithubController(IGitHubRepoService gitHubRepoService,
            GitHubViewModel gitHubViewModel)
        {
            this.gitHubRepoService = gitHubRepoService;
            this.gitHubViewModel = gitHubViewModel;
        }

        public ActionResult Index()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View(gitHubViewModel);
        }

        // GET: Github
        public async Task<ActionResult> GetUser(string username)
        {
            // Check if the username is null or an empty string is passed
            // If empty string or null , return an error message to the index action of the home controller
            //return early before execution of service method.
            if (string.IsNullOrEmpty(username))
            {
                TempData["ErrorMessage"] = "Invalid Username";
                return RedirectToAction("Index");
            }

            //else try and get the profile of user withthe username
            var user = await gitHubRepoService.GetGitHubUserAsync(username);
            return View(user);
        }
    }
}