using Tutorial_11.DTO_s;
using Tutorial_11.Models;

namespace Tutorial_11.Services;

public interface IPatientService
{
    Task<PatientDto> GetPatient(int id);
}