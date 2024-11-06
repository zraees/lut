using Microsoft.EntityFrameworkCore;
using WorldCareCenter.Api.Entities;
using WorldCareCenter.Api.Models;

namespace WorldCareCenter.Api.Helper;

public class Utilities
{
    private readonly LahtiDBContext _lahtiDBContext;

    public Utilities(LahtiDBContext lahtiDBContext)
    {
        _lahtiDBContext = lahtiDBContext;
    }

    public async Task<List<Doctor>> getData(string location)
    {
        switch (location.ToLower())
        {
            case "lahti":
                return await getLathiData().ConfigureAwait(false);
            default:
                return new List<Doctor>();
        }
    }

    private async Task<List<Doctor>> getLathiData()
    {
        return await _lahtiDBContext.Doctors.ToListAsync();
    }
}
