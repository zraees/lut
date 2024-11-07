using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldCareCenter.Api.DTOs;
using WorldCareCenter.Api.Models;

namespace WorldCareCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly LahtiDBContext _lahtiDBContext;
        private readonly HelsinkiDBContext _helsinkiDBContext;
        private readonly TurkuDBContext _turkuDBContext;

        public DataController(LahtiDBContext lahtiDBContext,
            HelsinkiDBContext helsinkiDBContext,
            TurkuDBContext turkuDBContext)
        {
            this._lahtiDBContext = lahtiDBContext;
            this._helsinkiDBContext = helsinkiDBContext;
            this._turkuDBContext = turkuDBContext;
        }

        [HttpGet("{location}")]
        public async Task<IActionResult> GetDoctors(string location)
        {
            CompleteDatasetDTO completeDatasetDTO = new();
            switch (location.ToLower())
            {
                case "lahti":
                    completeDatasetDTO.Doctors = await _lahtiDBContext.Doctors.ToListAsync();
                    completeDatasetDTO.Patients = await _lahtiDBContext.Patients.ToListAsync();
                    completeDatasetDTO.Invoices = await _lahtiDBContext.Invoices.ToListAsync();
                    completeDatasetDTO.InvoiceDetails = await _lahtiDBContext.InvoiceDetails.ToListAsync();
                    break;
                case "helsinki":
                    completeDatasetDTO.Doctors = await _helsinkiDBContext.Doctors.ToListAsync();
                    completeDatasetDTO.Patients = await _helsinkiDBContext.Patients.ToListAsync();
                    completeDatasetDTO.Invoices = await _helsinkiDBContext.Invoices.ToListAsync();
                    completeDatasetDTO.InvoiceDetails = await _helsinkiDBContext.InvoiceDetails.ToListAsync();
                    break;
                case "turku":
                    completeDatasetDTO.Doctors = await _turkuDBContext.Doctors.ToListAsync();
                    completeDatasetDTO.Patients = await _turkuDBContext.Patients.ToListAsync();
                    completeDatasetDTO.Invoices = await _turkuDBContext.Invoices.ToListAsync();
                    completeDatasetDTO.InvoiceDetails = await _turkuDBContext.InvoiceDetails.ToListAsync();
                    break;
                default:
                    break;
            }

            return Ok(completeDatasetDTO);
        }
    }
}
