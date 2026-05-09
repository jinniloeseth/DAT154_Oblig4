using Backend.API;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Objects;

namespace Backend.API
{

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<CaseScenario> CaseScenarios { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<VitalSigns> VitalSigns { get; set; }
        public DbSet<ActionLog> ActionLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TeacherObservation> TeacherObservations { get; set; }
    }
}
