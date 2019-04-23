using GithubRepoApp.Services.Abstractions;
using System.Web.Mvc;

namespace GithubRepoApp.Controllers
{
    public class GithubController : Controller
    {
        private readonly IGitHubRepoService gitHubRepoService;

        public GithubController(IGitHubRepoService gitHubRepoService)
        {
            this.gitHubRepoService = gitHubRepoService;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Github
        [HttpGet()]
        public ActionResult GetUser(string username)
        {
            // Check if the username is null or an empty string is passed
            // If empty string or null , return an error message to the index action of the home controller
            //return early before execution of service method.
            if (string.IsNullOrEmpty(username))
            {
                ViewBag.ErrorMessage = "Invalid Username";
                return RedirectToAction("Index");
            }

            //else try and get the profile of user withthe username
            var user = gitHubRepoService.GetGitHubUser(username);
            return View(user);
        }
    }
}