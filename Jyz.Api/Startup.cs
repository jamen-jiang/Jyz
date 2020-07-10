using Jyz.Api.Extensions;
using Jyz.Api.Filter;
using Jyz.Api.Middlewares;
using Jyz.Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            //�ӿ�ע��
            services.AddServiceSetup("Jyz.Application");
            //�����ļ�ע��
            services.AddAppSettingSetup(Env);
            //����Swagger
            services.AddSwaggerSetup();
            //����jwt
            services.AddJwtSetup();
            // Automapper ע��
            services.AddAutoMapperSetup();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
            services.AddMvc(mvc =>
            {
                //Ȩ����֤����
                mvc.Filters.Add<PrivilegeFilter>();
                //ģ����֤�����ؽ������
                mvc.Filters.Add<ApiResultAndValidateModelFilterAttribute>();
            });
            services.AddScoped<PrivilegeFilter>();
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
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{AppSetting.Project.Name} v1");
                //·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ����������뻻һ��·����ֱ��д���ּ��ɣ�����ֱ��дc.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
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
