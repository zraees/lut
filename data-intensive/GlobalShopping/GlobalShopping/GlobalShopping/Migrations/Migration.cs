using GlobalShopping.Data;
using Microsoft.EntityFrameworkCore;

namespace GlobalShopping.Migrations
{
    public static class Migrations
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using USAShoppingContext usacontext = scope.ServiceProvider.GetRequiredService<USAShoppingContext>();
            usacontext.Database.Migrate();
            using EuropeShoppingContext eucontext = scope.ServiceProvider.GetRequiredService<EuropeShoppingContext>();
            eucontext.Database.Migrate();
            using AsiaShoppingContext asiaShoppingContext = scope.ServiceProvider.GetRequiredService<AsiaShoppingContext>();
            asiaShoppingContext.Database.Migrate();
        }
    }
}
