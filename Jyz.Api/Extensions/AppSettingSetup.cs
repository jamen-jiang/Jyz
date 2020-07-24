using Jyz.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Jyz.Api.Extensions
{
    public static class AppSettingSetup
    {
        public static void AddAppSettingSetup(this IServiceCollection services, IWebHostEnvironment env)
        {
            AppSetting.Init(services, env);
        }
    }
}
