using GithubRepoApp.Models;
using System.Threading.Tasks;

namespace GithubRepoApp.Services.Abstractions
{
    public interface IGitHubRepoService
    {
        Task<GithubUser> GetGitHubUser(string username);
    }
}
