using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Jyz.Infrastructure
{
    /// <summary>
    /// appsettings.json操作类
    /// </summary>
    public static class AppSetting
    {
        public static IConfiguration Configuration { get; private set; }
        public static string CurrentPath { get; private set; } = null;
        public static SystemConfig SystemConfig { get; private set; }
        public static Jwt Jwt { get; private set; }
        public static Cors Cors { get; private set; }
        public static ServiceProvider Provider { get; private set; }

        public static void Init(IServiceCollection services, IWebHostEnvironment env)
        {
            CurrentPath = env.ContentRootPath;
            Configuration = new ConfigurationBuilder()
               .SetBasePath(CurrentPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)//这样的话，可以直接读目录里的json文件，而不是 bin 文件夹下的，所以不用修改复制属性
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
               .Build();
            //string path  = $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";
            services.Configure<SystemConfig>(Configuration.GetSection("SystemConfig"));
            services.Configure<Jwt>(Configuration.GetSection("Jwt"));
            services.Configure<Cors>(Configuration.GetSection("Cors"));
            Provider = services.BuildServiceProvider();
            SystemConfig = Provider.GetRequiredService<IOptions<SystemConfig>>().Value;
            Jwt = Provider.GetRequiredService<IOptions<Jwt>>().Value;
            Cors = Provider.GetRequiredService<IOptions<Cors>>().Value;
        }
    }
}
