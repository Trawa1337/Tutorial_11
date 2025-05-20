using Microsoft.AspNetCore.Mvc;
using Tutorial_11.DTO_s;
using Tutorial_11.Models;
using Tutorial_11.Services;

namespace Tutorial_11.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _service;
        
        public PrescriptionController(IPrescriptionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescription([FromBody] AddPrescriptionDTO prescription)
        {
            try
            {
                await _service.AddPrescriptionAsync(prescription);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

    }
}