using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GlobalShopping.Pages.UserAccount
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
        public Models.UserAccount UserAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.UserAccount.FirstOrDefaultAsync(m => m.ID == id);

            if (person == null)
            {
                return NotFound();
            }
            else
            {
                UserAccount = person;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.UserAccount.FindAsync(id);
            if (person != null)
            {
                UserAccount = person;
                _context.UserAccount.Remove(UserAccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
