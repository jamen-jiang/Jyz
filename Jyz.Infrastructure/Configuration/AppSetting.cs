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
        public static Connection Connection { get; private set; }
        public static Jwt Jwt { get; private set; }
        public static Project Project { get; private set; }
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
            services.Configure<Connection>(Configuration.GetSection("Connection"));
            services.Configure<Jwt>(Configuration.GetSection("Jwt"));
            services.Configure<Project>(Configuration.GetSection("Project"));
            services.Configure<Cors>(Configuration.GetSection("Cors"));
            Provider = services.BuildServiceProvider();
            Connection = Provider.GetRequiredService<IOptions<Connection>>().Value;
            Jwt = Provider.GetRequiredService<IOptions<Jwt>>().Value;
            Project = Provider.GetRequiredService<IOptions<Project>>().Value;
            Cors = Provider.GetRequiredService<IOptions<Cors>>().Value;
        }
    }
}
