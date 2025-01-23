using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace GlobalShopping.Pages.OrderLine
{
    public class IndexModel : PageModel
    {
        private readonly IDbcontext _context;

        public IndexModel([FromKeyedServices("USA")] IDbcontext usa, [FromKeyedServices("EU")] IDbcontext eu, [FromKeyedServices("AS")] IDbcontext asia)
        {
            switch (RegionConfiguration.DefaultRegionID)
            {
                case SupportedRegion.Europe:
                    _context = eu;
                    break;
                case SupportedRegion.Asia:
                    _context = asia;
                    break;
                default:
                    _context = usa;
                    break;
            }
        }

        public IList<Models.OrderLine> OrderLine { get; set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            OrderLine = await _context.OrderLine.Where(m => m.OrderID == id)
                .Include(o => o.Order)
                .Include(o => o.Product).ToListAsync();
        }
    }
}
