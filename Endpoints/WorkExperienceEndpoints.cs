using Microsoft.EntityFrameworkCore;
using ResumeHandler.Data;
using ResumeHandler.DTOs.WorkExperienceDTOs;
using ResumeHandler.Models;
using System.ComponentModel.DataAnnotations;

namespace ResumeHandler.Endpoints
{
    public class WorkExperienceEndpoints 
    {
        
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/workexperience", async (ResumeHandlerDBContext context) =>
            {
                var experience = await context.WorkExperiences.Select(e => new WorkExperienceDto

                {
                    WorkID = e.WorkID,
                    WorkRole = e.WorkRole,
                    CompanyName = e.CompanyName,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate


                }).ToListAsync();


                return Results.Ok(experience);
            });

            app.MapGet("/workexperience/{id}", async (ResumeHandlerDBContext context, int id) =>
            {
                var workExperience = await context.WorkExperiences
                .Where(e => e.WorkID == id)
                .Select(e => new WorkExperienceDto
                {
                    WorkRole = e.WorkRole,
                    CompanyName = e.CompanyName,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                }).SingleOrDefaultAsync();

                if(workExperience == null)
                {
                    return Results.NotFound(new {message = "Work experience not found"});
                }
                return Results.Ok(workExperience);
            });

            app.MapPost("/add-workexperience", async (CreateWorkExperienceDto newWorkExperience, ResumeHandlerDBContext context) =>
            {

                var validContext = new ValidationContext(newWorkExperience);

                var validationResults = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newWorkExperience, validContext, validationResults, true);

                if (!isValid)
                {
                    return Results.BadRequest(new { message = "Invalid work experience data", errors = validationResults });
                }

                var workExperience = new WorkExperience
                {
                    WorkRole = newWorkExperience.WorkRole,
                    CompanyName = newWorkExperience.CompanyName,
                    Description = newWorkExperience.Description,
                    StartDate = newWorkExperience.StartDate,
                    EndDate = newWorkExperience.EndDate,
                    UserID_FK = newWorkExperience.UserID
                };

                context.WorkExperiences.Add(workExperience);
                await context.SaveChangesAsync();

                return Results.Created($"/workexperience/{workExperience.WorkID}", workExperience);
            });
            app.MapDelete("/delete-workexperience/{id}", async (int id, ResumeHandlerDBContext context) =>
            {
                var workExperience = await context.WorkExperiences.FirstOrDefaultAsync(e => e.WorkID == id);

                if (workExperience == null)
                {
                    return Results.NotFound();
                }
                context.WorkExperiences.Remove(workExperience);
                await context.SaveChangesAsync();

                return Results.NoContent();
            });
        }

    }
}
