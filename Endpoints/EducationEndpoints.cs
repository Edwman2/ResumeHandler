using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ResumeHandler.Data;
using ResumeHandler.DTOs.EducationDTOs;
using ResumeHandler.Models;
using ResumeHandler.Services;
using System.ComponentModel.DataAnnotations;

namespace ResumeHandler.Endpoints
{
    public class EducationEndpoints
    {

        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/educations", async (EducationService educationService) =>
            {
                var response = await educationService.GetAllEducations();

                return Results.Ok(response);
            });

            app.MapGet("/educations/{id}", async (EducationService educationService, int id) =>
            {

                var response = await educationService.GetEducations(id);
                if(response == null)
                {
                    return Results.NotFound(new { message = "Eduaction record not found" });
                }
                

                return Results.Ok(response);

            });

            app.MapPost("/create-education", async (CreateEducationDto createEducationDto, ResumeHandlerDBContext context) =>
            {
                var validationContext = new ValidationContext(createEducationDto);
                var validResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(createEducationDto, validationContext, validResult, true);

                if(!isValid)
                {
                    return Results.BadRequest(validResult.Select(error => error.ErrorMessage));
                }

                

                var createEducation = new Education
                {
                    SchoolName = createEducationDto.SchoolName,
                    Degree = createEducationDto.Degree,
                    StartDate = createEducationDto.StartDate,
                    EndDate = createEducationDto.EndDate,
                    UserID_FK = createEducationDto.UserID
                };

                context.Educations.Add(createEducation);
                await context.SaveChangesAsync();

                return Results.Ok(createEducation);

            });

            app.MapPatch("/update-education/{id}", async (int id, UpdateEducationDto updatedEducation, ResumeHandlerDBContext context) =>
            {
                var existingEducation = await context.Educations.SingleOrDefaultAsync(e => e.EducationID == id);

                if (existingEducation == null)
                {
                    return Results.NotFound(new { message = "Education record not found" });
                }

                if (!string.IsNullOrWhiteSpace(updatedEducation.SchoolName))
                    existingEducation.SchoolName = updatedEducation.SchoolName;

                if (!string.IsNullOrWhiteSpace(updatedEducation.Degree))
                    existingEducation.Degree = updatedEducation.Degree;

                if (updatedEducation.StartDate != default)
                    existingEducation.StartDate = updatedEducation.StartDate;

                if (updatedEducation.EndDate != default)
                    existingEducation.EndDate = updatedEducation.EndDate;

                await context.SaveChangesAsync();

                return Results.Ok(existingEducation);
            });
            app.MapDelete("/delete-education/{id}", async (int id, ResumeHandlerDBContext context) =>
            {
                var education = await context.Educations.FirstOrDefaultAsync(e => e.EducationID == id);

                if(education == null)
                {
                    return Results.NotFound();
                }
                context.Educations.Remove(education);
                await context.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}
