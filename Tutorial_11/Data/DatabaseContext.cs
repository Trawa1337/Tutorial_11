using Microsoft.EntityFrameworkCore;
using Tutorial_11.Models;

namespace Tutorial_11.Data;

public class DatabaseContext:DbContext
{
    public DbSet<Medicament> Medicament { get; set; }
    public DbSet<Prescription> Prescription { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Patient> Patient { get; set; }
    
    
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "Katarzyna", LastName = "Zielińska", Email = "k.zielinska@clinic.pl" },
            new Doctor { IdDoctor = 2, FirstName = "Tomasz", LastName = "Lewandowski", Email = "t.lewandowski@clinic.pl" }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "Adam", LastName = "Wiśniewski", Birthdate = new DateTime(1975, 3, 25) },
            new Patient { IdPatient = 2, FirstName = "Ewa", LastName = "Kaczmarek", Birthdate = new DateTime(1988, 11, 9) }
        );

        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1, Name = "Polopiryna", Description = "Na przeziębienie", Type = "Tabletka" },
            new Medicament { IdMedicament = 2, Name = "Rutinoscorbin", Description = "Wzmacniający odporność", Type = "Tabletka" }
        );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription { IdPrescription = 1, Date = new DateTime(2024, 4, 1), DueDate = new DateTime(2024, 4, 10), IdDoctor = 1, IdPatient = 1 },
            new Prescription { IdPrescription = 2, Date = new DateTime(2024, 5, 5), DueDate = new DateTime(2024, 5, 20), IdDoctor = 2, IdPatient = 2 }
        );

        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament { IdPrescription = 1, IdMedicament = 1, Dose = 1, Details = "Raz dziennie po posiłku" },
            new PrescriptionMedicament { IdPrescription = 2, IdMedicament = 2, Dose = 2, Details = "Dwa razy dziennie przed snem" }
        );
    }

    
}