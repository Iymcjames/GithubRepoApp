namespace GithubRepoApp.Models
{
    public class GitUserResponse
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Location { get; set; }
        public string Avatar_Url { get; set; }
        public string Repos_Url { get; set; }
    }
}