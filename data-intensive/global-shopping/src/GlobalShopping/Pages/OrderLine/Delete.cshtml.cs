using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace GlobalShopping.Pages.OrderLine
{
    public class DeleteModel : PageModel
    {
        private readonly IDbcontext _context;

        public DeleteModel([FromKeyedServices("USA")] IDbcontext usa, [FromKeyedServices("EU")] IDbcontext eu, [FromKeyedServices("AS")] IDbcontext asia)
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

        [BindProperty]
        public Models.OrderLine OrderLine { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(ObjectId? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderline = await _context.OrderLine.FirstOrDefaultAsync(m => m.ID == id);

            if (orderline == null)
            {
                return NotFound();
            }
            else
            {
                OrderLine = orderline;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(ObjectId? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderline = await _context.OrderLine.FindAsync(id);
            if (orderline != null)
            {
                OrderLine = orderline;
                _context.OrderLine.Remove(OrderLine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
