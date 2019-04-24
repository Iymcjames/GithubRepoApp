using System.Collections.Generic;

namespace GithubRepoApp.Models
{
    public class GithubUser
    {
        public string Login { get; set; }
        public string Location { get; set; }
        public string Avatar_Url { get; set; }
        public IEnumerable<GitRepoResponse> GitRepos { get; set; }
    }
}