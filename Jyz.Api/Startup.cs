using Jyz.Api.Extensions;
using Jyz.Api.Filter;
using Jyz.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

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
            //var connection = "Data Source=.;Initial Catalog=System;User ID=sa;Password=19911004";
            //string conStr = Config.GetVal<string>("ConStr");
            //services.AddDbContext<JyzContext>(options => options.UseSqlServer(conStr));
            services.AddAppSettingSetup(Env);
            services.AddControllers();
            services.AddSwaggerSetup();
            services.AddMvc(mvc =>
            {
                mvc.Filters.Add<TokenFilter>();
                mvc.Filters.Add<ValidateModelFilter>();
            });
            // Automapper 注入
            services.AddAutoMapperSetup();
            //services.AddServiceSetup("Blog.Core.Services");
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", "Jyz.Api v1");
                //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

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
