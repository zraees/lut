using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GlobalShopping.Pages.UserAccount
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

        public IList<Models.UserAccount> UserAccount { get; set; } = default!;

        public async Task OnGetAsync()
        {
            UserAccount = await _context.UserAccount.ToListAsync();
        }
    }
}
