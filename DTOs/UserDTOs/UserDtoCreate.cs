using System.ComponentModel.DataAnnotations;

namespace ResumeHandler.DTOs.UserDTOs
{
    public class UserDtoCreate
    {
        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }

        public string Description { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        
        public List<int> EducationIds { get; set; }  
        public List<int> WorkExperienceIds { get; set; } 
    }
}
