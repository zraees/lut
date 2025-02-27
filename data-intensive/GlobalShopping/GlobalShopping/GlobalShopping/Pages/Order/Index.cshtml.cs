﻿using GlobalShopping.Data;
using GlobalShopping.Interfaces;
using GlobalShopping.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GlobalShopping.Pages.Order
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

        public IList<Models.Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var orders = await _context.Order
                .ToListAsync();
            var persons = await _context.UserAccount.ToListAsync();
            var query1 =
    from o in orders
    join p in persons on o.UserID equals p.ID
    select new Models.Order
    {
        DeliveryAddress = o.DeliveryAddress,
        ID = o.ID,
        UserID = o.UserID,
        User = p,
        OrderDate = o.OrderDate,
        OrderValue = o.OrderValue
    };
            //Order = orders.Join(persons, m => m.UserID, t => t.ID, (m, t) => { var order = m; order.User = t; return order; }).ToList();
            Order = query1.ToList();
        }
    }
}
