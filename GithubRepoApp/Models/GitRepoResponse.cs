namespace GithubRepoApp.Models
{
    public class GitRepoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Stargazers_Count { get; set; }
    }
}