using SocialWebServices.Services.MenuService;
using SocialWebServices.Services.TestService;
using SocialWebServices.Services.VideoService;

namespace Extensions
{
    public static class ServiceRegisterExtension
    {
        public static void ServiceRegister(this IServiceCollection services)
        {
            services.AddScoped<ITestService,TestService>();
            services.AddScoped<IMenuService,MenuService>(); 
            services.AddScoped<IVideoService,VideoService>();
        }
    }
}