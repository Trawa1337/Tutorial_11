namespace Tutorial_11.DTO_s;

    public class AddPrescriptionDTO
    {
    public PatientDTO Patient { get; set; }
    public int IdDoctor { get; set; }
    public List<MedicamentDTO> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DateDue { get; set; }

    }

        public class MedicamentDTO
    {
        public int IdMedicament { get; set; }
        public int? Dose { get; set; }
        public string Description { get; set; }
    }

    public class PatientDTO
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
