using Microsoft.EntityFrameworkCore;
using Tutorial_11.Data;
using Tutorial_11.DTO_s;
using Tutorial_11.Models;

namespace Tutorial_11.Services;

public class PrescriptionService: IPrescriptionService
{
    private readonly DatabaseContext _context;

    public PrescriptionService(DatabaseContext context)
    {
        _context = context;
    }
    

    public async Task AddPrescriptionAsync(AddPrescriptionDTO dto)
    {

        if (dto.Medicaments.Count > 10)
            throw new Exception("Recepta może zawierać maksymalnie 10 leków.");

        if (dto.DateDue < dto.Date)
            throw new Exception("DateDue nie może być wcześniejszy niż Date.");

        var doctor = await _context.Doctor
            .FirstOrDefaultAsync(d => d.IdDoctor == dto.IdDoctor);
        if (doctor == null)
            throw new InvalidOperationException("Lekarz nie istnieje.");
        var patient = await _context.Patient.FirstOrDefaultAsync(p =>
            p.FirstName == dto.Patient.FirstName &&
            p.LastName == dto.Patient.LastName &&
            p.Birthdate == dto.Patient.Birthdate);
        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = dto.Patient.FirstName,
                LastName = dto.Patient.LastName,
                Birthdate = dto.Patient.Birthdate
            };
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();
        }

        var prescription = new Prescription
        {
            Date = dto.Date,
            DueDate = dto.DateDue,
            IdDoctor = doctor.IdDoctor,
            IdPatient = patient.IdPatient,
            PrescriptionMedicaments = new List<PrescriptionMedicament>()
        };
        foreach (var med in dto.Medicaments)
        {
            var medicament = await _context.Medicament.FindAsync(med.IdMedicament);
            if (medicament == null)
                throw new InvalidOperationException($"Lek o ID {med.IdMedicament} nie istnieje.");
            prescription.PrescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdMedicament = medicament.IdMedicament,
                Dose = med.Dose,
                Details = med.Description
            });
        }
        _context.Prescription.Add(prescription);
        await _context.SaveChangesAsync();
    }
    
}
       

