using Microsoft.EntityFrameworkCore;
using ResumeHandler.Models;

namespace ResumeHandler.Data
{
    public class ResumeHandlerDBContext : DbContext
    {
        public ResumeHandlerDBContext(DbContextOptions<ResumeHandlerDBContext> options) : base(options)
        {


        }

        public DbSet<Education> Educations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<WorkExperience> WorkExperiences { get; set; }

    }
}
