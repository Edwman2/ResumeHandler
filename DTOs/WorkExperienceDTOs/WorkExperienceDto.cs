using ResumeHandler.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeHandler.DTOs.WorkExperienceDTOs
{
    public class WorkExperienceDto
    {
        public int WorkID { get; set; }  

        [Required]
        [StringLength(50, ErrorMessage = "Work role can't exceed 50 characters.")]
        public string WorkRole { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Company name can't exceed 100 characters.")]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        [Required]
        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

  
    }
}
