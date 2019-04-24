using GithubRepoApp.Models;
using System.Threading.Tasks;

namespace GithubRepoApp.Services.Abstractions
{
    public interface IGitHubRepoService
    {
        Task<GithubUser> GetGitHubUserAsync(string username);
    }
}
