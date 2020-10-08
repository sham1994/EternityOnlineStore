using EternityStore.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace EternityStore.Helpers
{
    public static class WebHostExtensions
    {
        //public static IWebHost SeedData(this IWebHost host)
        public static IHost SeedData(this IHost host)
        {
            try
            {
                using var scope = host.Services.CreateScope();
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<DataContext>();
                context.Database.Migrate();
                Seed.SeedUsers(context);
                Seed.SeedProductCategories(context);
                Seed.SeedProducts(context);


            }

            catch (Exception ex)
            {

                Log.Error("An error occured during migration. {message}", ex.Message);
            }
            return host;
        }
    }
}
