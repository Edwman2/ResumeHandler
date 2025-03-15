namespace ResumeHandler.DTOs.EducationDTOs
{
    public class EducationDto
    {
        public int EducationID { get; set; }
        public string SchoolName { get; set; }
        public string? Degree { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
