using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeHandler.Models
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }

        [Required]
        [StringLength(50,MinimumLength =3, ErrorMessage = "School name can't exceed 50 characters. ")]
        public string SchoolName { get; set; }
        
        [Required]
        public string Degree { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID_FK { get; set; }

        public virtual User User { get; set; }



    }
}
