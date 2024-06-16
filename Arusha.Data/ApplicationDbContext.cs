using arusha.Models;
using Microsoft.EntityFrameworkCore;

namespace arusha.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<University> University { get; set; }
        public DbSet<ProgramUni> ProgramUni { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StoredProcedureResult> StoredProcedureResults { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.ProgramUni) // Используем ProgramUni вместо Program
                .WithMany()
                .HasForeignKey(s => s.ProgramId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
