using GlobalShopping.Data;
using GlobalShopping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GlobalShopping.Pages
{
    public class RegionModel : PageModel
    {
        public IActionResult OnGet()
        {
            var regions = new List<Region>()
            {
                new Region(){ ID = (int)SupportedRegion.USA, Name = Enum.GetName(SupportedRegion.USA) },
                new Region(){ ID = (int)SupportedRegion.Europe, Name = Enum.GetName(SupportedRegion.Europe) },
                new Region(){ ID = (int)SupportedRegion.Asia, Name = Enum.GetName(SupportedRegion.Asia) }
            };
            ViewData["Regions"] = new SelectList(regions, "ID", "Name");
            var region = new Region()
            {
                ID = (int)RegionConfiguration.DefaultRegionID,
                Name = Enum.GetName(RegionConfiguration.DefaultRegionID)
            };
            Region = region;
            return Page();
        }
        [BindProperty]
        public Models.Region Region { get; set; } = default!;
        public IActionResult OnPost()
        {
            switch (Region.ID)
            {
                case (int)SupportedRegion.USA:
                    RegionConfiguration.DefaultRegionID = SupportedRegion.USA;
                    break;
                case (int)SupportedRegion.Europe:
                    RegionConfiguration.DefaultRegionID = SupportedRegion.Europe;
                    break;
                case (int)SupportedRegion.Asia:
                    RegionConfiguration.DefaultRegionID = SupportedRegion.Asia;
                    break;
            }
            return RedirectToPage("./Index");
        }
    }
}
