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
using System.Linq;

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
            services.AddServiceSetup("Jyz.Application");
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
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //开发环境
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //异常中间件
            app.UseExceptionHandlerMiddleware();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{AppSetting.Project.Name} v1");
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
