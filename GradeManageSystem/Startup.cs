using GradeManageSystem.Helpers;
using GradeManageSystem.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GradeManageSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.AllowAnyHeader().AllowAnyOrigin());

            });

            services.AddSingleton<DomainController>();
            services.AddSingleton<JwtHelpers>();
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
            {
                // 當驗證失敗時，回應標頭會包含 WWW-Authenticate 標頭，這裡會顯示失敗的詳細錯誤原因
                options.IncludeErrorDetails = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // 透過這項宣告，就可以從 "sub" 取值並設定給 User.Identity.Name
                    NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                    // 透過這項宣告，就可以從 "roles" 取值，並可讓 [Authorize] 判斷角色
                    RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    // 一般都會驗證 Issuer
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Payload:Claims:Issuer"],

                    // 一般不太需要驗證 Audience
                    ValidateAudience = false,
                    // 一般都會驗證 Token 的有效期間
                    ValidateLifetime = true,
                    // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Payload:Claims:SignKey"]))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowMyOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();// 先驗證

            app.UseAuthorization();// 再授權

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
