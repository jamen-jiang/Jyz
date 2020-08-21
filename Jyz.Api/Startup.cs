using Autofac;
using Autofac.Extras.DynamicProxy;
using Jyz.Api.Attributes;
using Jyz.Api.Extensions;
using Jyz.Api.Filter;
using Jyz.Api.Middlewares;
using Jyz.Application;
using Jyz.Domain;
using Jyz.Infrastructure;
using Jyz.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Jyz.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //接口注入
            //services.AddServiceSetup("Jyz.Application");
            //配置文件注入
            services.AddAppSettingSetup(Env);
            //配置Swagger
            services.AddSwaggerSetup();
            //配置jwt
            services.AddJwtSetup();
            //Automapper 注入
            services.AddAutoMapperSetup();
            //跨域配置
            services.AddCorsSetup();
            services.AddControllers()
             //全局配置Json序列化处理
            .AddNewtonsoftJson(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            }); ;
            services.AddControllers(controller =>
            {
                controller.Filters.Add<LogActionFilter>();
            });
            #region 缓存
            if (AppSetting.SystemConfig.CacheType == (int)CacheTypeEnum.Redis)
            {
                services.AddSingleton<ICache, RedisCache>();
            }
            else
            {
                services.AddMemoryCache();
                services.AddSingleton<ICache, MemoryCache>();
            }
            #endregion
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var servicesDllFile = Path.Combine(AppContext.BaseDirectory, "Jyz.Application.dll");
            // AOP 开关，如果想要打开指定的功能，只需要在 appsettigns.json 对应对应 true 就行。
            var cacheType = new List<Type>();
            builder.RegisterType<RedisCacheAop>();
            cacheType.Add(typeof(RedisCacheAop));
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerDependency()
                      .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                      .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //开发环境
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{AppSetting.SystemConfig.Name} v1");
                //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });
            app.UseCors("Jyz");

            app.UseHttpsRedirection();

            var serviceProvider = app.ApplicationServices;
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            CurrentUser.Configure(httpContextAccessor);

            app.UseRouting();

            app.UseResultMiddleware();
            
            //认证
            app.UseAuthentication();
            //授权
            app.UseAuthorization();

            //异常中间件
            app.UseExceptionHandlerMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Api}/{action=ProcessRequest}/{id?}");
            });
        }
    }
}
