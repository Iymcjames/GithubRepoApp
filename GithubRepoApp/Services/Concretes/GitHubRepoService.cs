using GithubRepoApp.Models;
using GithubRepoApp.Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace GithubRepoApp.Services.Concretes
{
    public class GitHubRepoService : IGitHubRepoService
    {
        public Task<GithubUser> GetGitHubUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}