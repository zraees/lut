using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GlobalShopping.Pages.UserAccount
{
    public class CreateModel : PageModel
    {
        private readonly IDbcontext _context;

        public CreateModel([FromKeyedServices("USA")] IDbcontext usa, [FromKeyedServices("EU")] IDbcontext eu, [FromKeyedServices("AS")] IDbcontext asia)
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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.UserAccount UserAccount { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserAccount.Add(UserAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
