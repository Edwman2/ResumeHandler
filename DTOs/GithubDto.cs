namespace ResumeHandler.DTOs
{
    public class GithubDto
    {
        public string Name { get; set; }
        public string HtmlUrl { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }

        public GithubDto(string name, string htmlUrl, string description, string language)
        {
            Name = name;
            HtmlUrl = htmlUrl ?? "missing";
            Description = description ?? "missing";
            Language = string.IsNullOrEmpty(language) ? "unkown" : language;
        }
    }

}
