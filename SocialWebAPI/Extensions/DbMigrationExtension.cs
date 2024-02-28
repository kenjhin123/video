using Microsoft.EntityFrameworkCore;
using SocialWebModel;

namespace xtensions
{
    public static class DbMigrationExtension
    {
        public static void UseDbMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }
        }

        public static void UseDataSeeding(this IApplicationBuilder app, bool isDevelopment = false)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                // private readonly IConfiguration _configuration
                var config = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
            }
        }
    }
}
