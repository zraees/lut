using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GlobalShopping.Pages.Order
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
        public Models.Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.ID == id);
            
            if (order == null)
            {
                return NotFound();
            }
            var lines = await _context.OrderLine.Where(m => m.OrderID == id).ToListAsync();
            var products = await _context.Product.ToListAsync();
            var productlines = lines.Join(products, m => m.ProductID, t => t.ID, (m, t) => { var _line = m; _line.Product = t; return _line; }).ToList();
            order.Lines = productlines;
            order.OrderValue = order.Lines.Sum(m => m.Quantity * m?.Product?.Price ?? 0);
            Order = order;
            ViewData["UserID"] = new SelectList(_context.Set<Models.UserAccount>(), "ID", "FirstName");
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

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.ID))
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

        private bool OrderExists(int? id)
        {
            return _context.Order.Any(e => e.ID == id);
        }
    }
}
