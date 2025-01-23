using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GlobalShopping.Pages
{
    public class AdminViewModel : PageModel
    {
        private readonly IDbcontext _usacontext;
        private readonly IDbcontext _eucontext;
        private readonly IDbcontext _asiacontext;

        public AdminViewModel([FromKeyedServices("USA")] IDbcontext usa, [FromKeyedServices("EU")] IDbcontext eu, [FromKeyedServices("AS")] IDbcontext asia)
        {

            _eucontext = eu;
            _asiacontext = asia;
            _usacontext = usa;
        }
        public IList<Product> Product{ get; set; } = default!;
        public IList<Models.UserAccount> UserAccount { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var usa = await _usacontext.Product.ToListAsync();
            var eu = await _eucontext.Product.ToListAsync();
            var asia = await _asiacontext.Product.ToListAsync();
            Product = usa.Union(eu).Union(asia).ToList();

            var usaPer = await _usacontext.UserAccount.ToListAsync();
            var euPer = await _eucontext.UserAccount.ToListAsync();
            var asiaPerson = await _asiacontext.UserAccount.ToListAsync();
            UserAccount = usaPer.Union(euPer).Union(asiaPerson).ToList();

        }
    }
}
