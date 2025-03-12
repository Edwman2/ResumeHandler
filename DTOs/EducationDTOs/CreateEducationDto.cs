using System.ComponentModel.DataAnnotations;

namespace ResumeHandler.DTOs.EducationDTOs
{
    public class CreateEducationDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "School name can't exceed 50 characters. ")]
        public string SchoolName { get; set; }

        [Required]
        public string Degree { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        [Required]
        public int UserID_FK { get; set; }
    }
}
