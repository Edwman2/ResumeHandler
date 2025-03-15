using Microsoft.EntityFrameworkCore;
using ResumeHandler.Data;
using ResumeHandler.DTOs.UserDTOs;
using System.Runtime.CompilerServices;

namespace ResumeHandler.Services
{
    public class UserService
    {
        private readonly ResumeHandlerDBContext context;

        public UserService(ResumeHandlerDBContext _context)
        {
            context = _context;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var userList = await context.Users
                .Select( u => new UserDto
                {
                    UserID = u.UserID,
                    FirstName = u.FirstName,          
                    LastName = u.LastName,       
                    Description = u.Description, 
                    EmailAddress = u.EmailAddress,      
                    PhoneNumber = u.PhoneNumber
                })
                .ToListAsync();  

            return userList;  
        }

        public async Task<List<UserDto>> GetUsersAsync(int id)
        {
            var user = await context.Users
                .Where(u => u.UserID == id)
                .Select(u => new UserDto
                {
                    UserID = u.UserID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Description = u.Description,
                    EmailAddress = u.EmailAddress,
                    PhoneNumber = u.PhoneNumber
                }).ToListAsync();

            return user;
        }
    }
}
