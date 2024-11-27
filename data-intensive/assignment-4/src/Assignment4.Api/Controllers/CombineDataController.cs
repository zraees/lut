using Assignment4.Api.Entities;
using Assignment4.Api.Helper;
using Assignment4.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombineDataController : ControllerBase
    {
        private readonly Assignment4DBContext _Assignment4DBContext;

        public CombineDataController(Assignment4DBContext Assignment4DBContext)
        {
            this._Assignment4DBContext = Assignment4DBContext;
        }

        [HttpGet("GetSqlNoSqlData")]
        public async Task<IActionResult> GetAllAsync()
        {
            var familiesSql = await _Assignment4DBContext.FamiliesSql.Include("Parents").Include("Children").ToListAsync().ConfigureAwait(false);
            var familiesNoSql = await HelperNoSql.GetAllAsync().ConfigureAwait(false);

            List<Family> families = new List<Family>();
            Family family;

            // Data from SQL-DB
            foreach (var familySql in familiesSql)
            {
                family = new Family();
                family.Id = familySql.Id;
                family.LastName = familySql.LastName;
                family.IsRegistered = familySql.IsRegistered;
                family.Parents = new List<Parent>();
                foreach (var parentSql in familySql.Parents)
                {
                    family.Parents.Add(new Parent() { FamilyName = familySql.LastName, FirstName = parentSql.FirstName });
                }
                family.Children = new List<Child>();
                foreach (var childSql in familySql.Children)
                {
                    family.Children.Add(new Child() { FamilyName = familySql.LastName, FirstName = childSql.FirstName, Grade = childSql.Grade, Gender = childSql.Gender });
                }

                families.Add(family);
            }

            // Data from NoSQL-DB
            foreach (var item in familiesNoSql)
            {
                family = new Family();
                family.Id = item.Id;
                family.LastName = item.LastName;
                family.IsRegistered = item.IsRegistered;
                family.Parents = new List<Parent>();
                foreach (var parentNoSql in item.Parents)
                {
                    family.Parents.Add(new Parent() { FamilyName = item.LastName, FirstName = parentNoSql.FirstName });
                }
                family.Children = new List<Child>();
                foreach (var childNoSql in item.Children)
                {
                    family.Children.Add(new Child() { FamilyName = item.LastName, FirstName = childNoSql.FirstName, Grade = childNoSql.Grade, Gender = childNoSql.Gender });
                }

                families.Add(family);
            }

            return Ok(families);
        }
    }
}
