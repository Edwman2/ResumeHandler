using Microsoft.AspNetCore.Mvc.Razor;
using ResumeHandler.DTOs;
using ResumeHandler.DTOs.EducationDTOs;
using System.Text.Json;

namespace ResumeHandler.Endpoints
{
    public static class GitHubEndpoints
    {
        public static void GithubEndpoints(this WebApplication app)
        {
            app.MapGet("/github/{username}", async (string username) =>
            {
                if (string.IsNullOrWhiteSpace(username))
                return Results.BadRequest(new { message = "Username is required" });

                using var client = new HttpClient();
                client.DefaultRequestHeaders.UserAgent.ParseAdd("C# app");

                var url = $"https://api.github.com/users/{username}/repos";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return Results.BadRequest(new { message = "User not found" });
                }

                var json = await response.Content.ReadAsStringAsync();

                var repos = JsonSerializer.Deserialize<List<GithubDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var githubRepos = repos?.ConvertAll(r => new GithubDto(

                    r.Name,
                    r.HtmlUrl,
                    r.Description,
                    r.Language
                ));
                return Results.Ok(githubRepos);
            });
        }

    }
    public record GitHubRepo(string Name, string HtmlUrl, string Language = "okänt",string Description = "saknas");
}
