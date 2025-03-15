using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ResumeHandler.Data;
using ResumeHandler.DTOs.UserDTOs;
using ResumeHandler.Models;
using ResumeHandler.Services;
using System.ComponentModel.DataAnnotations;

namespace ResumeHandler.Endpoints
{
    public class UserEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/users", async (UserService userService) =>
            {
                var response = await userService.GetAllUsersAsync();
                return Results.Ok(response);
            });

            app.MapGet("/users/{id}", async (UserService userService, int id) =>
            {
                var response = await userService.GetUsersAsync(id);

                return Results.Ok(response);
            });

            app.MapPost("/add-user", async (UserDtoCreate newUser, ResumeHandlerDBContext context) =>
            {
                var validContext = new ValidationContext(newUser);

                var validationResults = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newUser, validContext, validationResults, true);

                if(!isValid)
                {
                    return Results.BadRequest(validationResults.Select(u => new { ErrorMessage = u.ErrorMessage }));
                }

                var user = new User
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    EmailAddress = newUser.EmailAddress,
                    PhoneNumber = newUser.PhoneNumber,
                    Description = newUser.Description
                };

                context.Users.Add(user);
                await context.SaveChangesAsync();

                return Results.Created($"/Users/{user.UserID}", user);
            });

            
        }

        
    }
}
