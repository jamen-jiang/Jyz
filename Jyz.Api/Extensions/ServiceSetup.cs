using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Jyz.Api.Extensions
{
    public static class ServiceSetup
    {
        public static void AddServiceSetup(this IServiceCollection services, string assemblyName
 , ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            var basePath = AppContext.BaseDirectory;
            var servicesDllFile = Path.Combine(basePath,$"{assemblyName}.dll");
            if (!(File.Exists(servicesDllFile)))
            {
                throw new Exception("service.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。");
            }
            var assembly = Assembly.LoadFrom(servicesDllFile);

            var types = assembly.GetTypes();
            var list = types.Where(u => u.IsClass && !u.IsAbstract && !u.IsGenericType).ToList();

            foreach (var type in list)
            {
                var interfaceList = type.GetInterfaces();
                if (interfaceList.Any())
                {
                    var inter = interfaceList.First();

                    switch (serviceLifetime)
                    {
                        case ServiceLifetime.Transient:
                            services.AddTransient(inter, type);
                            break;
                        case ServiceLifetime.Scoped:
                            services.AddScoped(inter, type);
                            break;
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(inter, type);
                            break;
                    }
                    services.AddScoped(inter, type);
                }
            }
        }
    }
}
