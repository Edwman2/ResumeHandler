using Microsoft.EntityFrameworkCore;
using ResumeHandler.Data;
using ResumeHandler.DTOs.EducationDTOs;
using ResumeHandler.Models;

namespace ResumeHandler.Services
{
    public class EducationService
    {
        private readonly ResumeHandlerDBContext context;

        public EducationService(ResumeHandlerDBContext _context)
        {
            context = _context;
        }

        public async Task<List<EducationDto>> GetAllEducations()
        {
            var educationList = await context.Educations
                .Select(e => new EducationDto
                {
                    EducationID = e.EducationID,
                    SchoolName = e.SchoolName,
                    Degree = e.Degree,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                }).ToListAsync();

            return educationList;
        }

        public async Task<List<EducationDto>> GetEducations(int id)
        {
            var education = await context.Educations
                .Where(e => e.EducationID == id)
                .Select(e => new EducationDto
                {
                    EducationID = e.EducationID,
                    SchoolName = e.SchoolName,
                    Degree = e.Degree,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                }).ToListAsync();

            return education;

        }
    }
}
