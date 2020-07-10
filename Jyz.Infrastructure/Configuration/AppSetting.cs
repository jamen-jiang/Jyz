using Jyz.Domain.Models;
using Jyz.Domain.Models.AppSetting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Jyz.Infrastructure.Configuration
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
            var provider = services.BuildServiceProvider();
            Connection = provider.GetRequiredService<IOptions<Connection>>().Value;
            Jwt = provider.GetRequiredService<IOptions<Jwt>>().Value;
            Project = provider.GetRequiredService<IOptions<Project>>().Value;
        }
    }
}
