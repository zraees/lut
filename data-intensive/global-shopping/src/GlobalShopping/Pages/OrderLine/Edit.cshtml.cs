using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace GlobalShopping.Pages.OrderLine
{
    public class EditModel : PageModel
    {
        private readonly IDbcontext _context;

        public EditModel([FromKeyedServices("USA")] IDbcontext usa, [FromKeyedServices("EU")] IDbcontext eu, [FromKeyedServices("AS")] IDbcontext asia)
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
            OrderLine = orderline;
            ViewData["OrderID"] = new SelectList(_context.Order, "ID", "ID");
            ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrderLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(OrderLine.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderLineExists(ObjectId id)
        {
            return _context.OrderLine.Any(e => e.ID == id);
        }
    }
}
