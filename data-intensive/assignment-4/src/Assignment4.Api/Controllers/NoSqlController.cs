using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment4.Api.DTOs;
using Assignment4.Api.Models;
using Assignment4.Api.Entities;
using Assignment4.Api.Helper;

namespace Assignment4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoSqlController : ControllerBase
    {
        private readonly HelsinkiDBContext _helsinkiDBContext;

        public NoSqlController(HelsinkiDBContext helsinkiDBContext)
        {
            this._helsinkiDBContext = helsinkiDBContext;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var families = await HelperNoSql.GetAllAsync().ConfigureAwait(false);
            return Ok(families);
        }

        [HttpPost("AddFamilyItem")]
        public async Task<IActionResult> CreateFamilyNoSql(FamilyNoSql family)
        {
            var id =  await HelperNoSql.CreateAsync(family).ConfigureAwait(false);
            if (id.Length > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error while creating nosql item");
            }
        }

        [HttpPost("UpdateFamilyItem")]
        public async Task<IActionResult> UpdateFamilyNoSql(string id, bool registration)
        {
            var resp = await HelperNoSql.UpdateRegistrationAsync(id, registration).ConfigureAwait(false);
            if (resp.Length > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error while updating nosql item");
            }
        }

        [HttpDelete("DeleteFamilyItem")]
        public async Task<IActionResult> DeleteFamilyNoSql(string id)
        {
            var resp = await HelperNoSql.DeleteAsync(id).ConfigureAwait(false);
            if (resp.Length > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error while deleting nosql item");
            }
        }

        //[HttpGet("{location}")]
        //public async Task<IActionResult> GetDoctors(string location)
        //{
        //    CompleteDatasetDTO completeDatasetDTO = new();
        //    switch (location.ToLower())
        //    {
        //        case "helsinki":
        //            completeDatasetDTO.Doctors = await _helsinkiDBContext.Doctors.ToListAsync();
        //            completeDatasetDTO.Patients = await _helsinkiDBContext.Patients.ToListAsync();
        //            completeDatasetDTO.Invoices = await _helsinkiDBContext.Invoices.ToListAsync();
        //            completeDatasetDTO.InvoiceDetails = await _helsinkiDBContext.InvoiceDetails.ToListAsync();
        //            break;
        //        default:
        //            break;
        //    }

        //    return Ok(completeDatasetDTO);
        //}
    }
}
