using System.ComponentModel.DataAnnotations;

namespace ResumeHandler.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

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

        public virtual List<Education> Educations { get; set; }

        public virtual List<WorkExperience> WorkExperiences { get; set; }
    }
}
