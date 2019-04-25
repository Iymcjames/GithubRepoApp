using GithubRepoApp.Models;
using GithubRepoApp.Services.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubRepoApp.Services.Concretes
{
    public class GitHubRepoService : IGitHubRepoService
    {
        public async Task<GithubUser> GetGitHubUserAsync(string username)
        {
            //Call backend Api and get GitUserResponse
            var gitUserResponse = await GetGitUserResponseAsync(username);

            //call backend and get the list of repos
            var gitRepoReponse = await GetGitHubReposAync(gitUserResponse.Repos_Url);

            //Create and return the new GitHubUser
            return await GenerateGitHubUser(gitUserResponse, gitRepoReponse);
        }

        private async Task<GithubUser> GenerateGitHubUser(GitUserResponse gitUserResponse, IEnumerable<GitRepoResponse> gitRepoReponse)
        {
            if (gitUserResponse == null)
            {
                return null;
            }

            //AutoMapper will be perfect for this mapping
            var newGitHubUser = new GithubUser
            {
                Avatar_Url = gitUserResponse.Avatar_Url,
                Location = gitUserResponse.Location,
                Login = gitUserResponse.Login
            };

            newGitHubUser.GitRepos = gitRepoReponse.OrderByDescending(x => x.Stargazers_Count).Take(5);

            return newGitHubUser;
        }

        private async Task<IEnumerable<GitRepoResponse>> GetGitHubReposAync(string repos_Url)
        {
            var data = await ConnectToAPIAsync(repos_Url);
            if (!String.IsNullOrEmpty(data))
            {
                return JsonConvert.DeserializeObject<List<GitRepoResponse>>(data);

            }
            return null;
        }

        private async Task<GitUserResponse> GetGitUserResponseAsync(string username)
        {
            string apiUrl = $"https://api.github.com/users/{username}";
            var data = await ConnectToAPIAsync(apiUrl);
            if (!String.IsNullOrEmpty(data))
            {
                return JsonConvert.DeserializeObject<GitUserResponse>(data);

            }
            return null;
        }

        private async Task<string> ConnectToAPIAsync(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Add("User-Agent", "Iymcjames");
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

            }
            return null;
        }
    }
}