using System.ComponentModel.DataAnnotations;

namespace ResumeHandler.DTOs.EducationDTOs
{
    public class UpdateEducationDto
    {

        [Required]
        public int EducationID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "School name can't exceed 50 characters. ")]
        public string SchoolName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Degree can't exceed 50 characters. ")]
        public string Degree { get; set; }
        
        [Required]
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }
    }
}
