using Microsoft.EntityFrameworkCore;
using Tutorial_11.Data;
using Tutorial_11.DTO_s;

namespace Tutorial_11.Services;

public class PatientService: IPatientService
{
     
    private readonly DatabaseContext _context;
    
    public PatientService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<PatientDto> GetPatient(int id)
    {
        var patient = await _context.Patient
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPatient == id) ?? throw new KeyNotFoundException("Pacjent nie istnieje");
        return new PatientDto()
        {
            PatientId = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            Prescriptions = patient.Prescriptions
                .OrderBy(p => p.DueDate)
                .Select(p => new PrescriptionDTO
                {
                    PrescriptionId = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = new DoctorDTO
                    {
                        DoctorId = p.Doctor.IdDoctor,
                        FirstName = p.Doctor.FirstName,
                        LastName = p.Doctor.LastName,
                        Email = p.Doctor.Email
                    },
                    Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentGetDTO
                    {
                        MedicamentId = pm.Medicament.IdMedicament,
                        Name = pm.Medicament.Name,
                        Description = pm.Medicament.Description,
                        Dose = pm.Dose
                    }).ToList()
                }).ToList()
        };

    }
}