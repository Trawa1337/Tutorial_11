using Tutorial_11.DTO_s;

namespace Tutorial_11.Services;

public interface IPrescriptionService
{
    Task AddPrescriptionAsync(AddPrescriptionDTO dto);
}