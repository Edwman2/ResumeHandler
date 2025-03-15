using ResumeHandler.DTOs.EducationDTOs;
using ResumeHandler.DTOs.WorkExperienceDTOs;

namespace ResumeHandler.DTOs.UserDTOs
{
    public class UserDto
    {

        public required int UserID { get; set; } 
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Description { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }

       
        public List<EducationDto>? Educations { get; set; } 
        public List<WorkExperienceDto>? WorkExperiences { get; set; } 
    
    }
}
