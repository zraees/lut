using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldCareCenter.Api.Entities;
using WorldCareCenter.Api.Helper;
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
            List<Doctor> doctors = [];

            switch (location.ToLower())
            {
                case "lahti":
                    doctors = await _lahtiDBContext.Doctors.ToListAsync();
                    break;
                case "helsinki":
                    doctors = await _helsinkiDBContext.Doctors.ToListAsync();
                    break;
                case "turku":
                    doctors = await _turkuDBContext.Doctors.ToListAsync();
                    break;
                default:
                    break;
            }

            return Ok(doctors);
        }
    }
}
