using Assignment4.Api.Entities;
using Assignment4.Api.Helper;
using Assignment4.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlController : ControllerBase
    {
        private readonly Assignment4DBContext _Assignment4DBContext;

        public SqlController(Assignment4DBContext Assignment4DBContext)
        {
            this._Assignment4DBContext = Assignment4DBContext;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var families = await _Assignment4DBContext.FamiliesSql.Include("Parents").Include("Children").ToListAsync().ConfigureAwait(false);
            return Ok(families);
        }

        [HttpPost("AddFamilyRecord")]
        public async Task<IActionResult> CreateFamilySql(FamilySql family)
        {
            try
            {
                await _Assignment4DBContext.FamiliesSql.AddAsync(family).ConfigureAwait(false);
                await _Assignment4DBContext.SaveChangesAsync().ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error while creating Sql item");
            }
        }

        [HttpPost("UpdateFamilyItem")]
        public async Task<IActionResult> UpdateFamilySql(string id, bool registration)
        {
            try
            {
                var family = await _Assignment4DBContext.FamiliesSql.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
                if (family != null)
                {
                    family.IsRegistered = registration;
                    await _Assignment4DBContext.SaveChangesAsync().ConfigureAwait(false);
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error while creating Sql item");
            }
        }

        [HttpDelete("DeleteFamilyItem")]
        public async Task<IActionResult> DeleteFamilySql(string id)
        {
            try
            {
                var family = await _Assignment4DBContext.FamiliesSql.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
                if (family != null)
                {
                    #region parents
                    var parents = await _Assignment4DBContext.ParentsSql.Where(x => x.FamilyId == id).ToListAsync().ConfigureAwait(false);
                    if (parents.Count > 0)
                    {
                        _Assignment4DBContext.ParentsSql.RemoveRange(parents);
                    }
                    #endregion

                    #region chilren
                    var children = await _Assignment4DBContext.ChildrenSql.Where(x => x.FamilyId == id).ToListAsync().ConfigureAwait(false);
                    if (children.Count > 0)
                    {
                        _Assignment4DBContext.ChildrenSql.RemoveRange(children);
                    }
                    #endregion

                    _Assignment4DBContext.FamiliesSql.Remove(family);
                    await _Assignment4DBContext.SaveChangesAsync().ConfigureAwait(false);
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error while creating Sql item");
            }
        }
    }
}