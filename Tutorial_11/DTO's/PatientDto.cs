namespace Tutorial_11.DTO_s;

public class PatientGetDTO
{
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public List<PrescriptionDTO> Prescriptions { get; set; }
}

public class PrescriptionDTO
{
    public int PrescriptionId { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<MedicamentGetDTO> Medicaments { get; set; }
    public DoctorDTO Doctor { get; set; }
}
public class MedicamentGetDTO
{
    public int MedicamentId { get; set; }
    public string Name { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}

public class DoctorDTO
{
    public int DoctorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}