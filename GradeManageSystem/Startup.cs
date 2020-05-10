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
                builder => {
                    builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
            });

            services.AddSingleton<DomainController>();
            services.AddSingleton<JwtHelpers>();
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
            {
                // �����ҥ��ѮɡA�^�����Y�|�]�t WWW-Authenticate ���Y�A�o�̷|��ܥ��Ѫ��Բӿ��~��]
                options.IncludeErrorDetails = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // �z�L�o���ŧi�A�N�i�H�q "sub" ���Ȩó]�w�� User.Identity.Name
                    NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                    // �z�L�o���ŧi�A�N�i�H�q "roles" ���ȡA�åi�� [Authorize] �P�_����
                    RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    // �@�볣�|���� Issuer
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Payload:Claims:Issuer"],

                    // �@�뤣�ӻݭn���� Audience
                    ValidateAudience = false,
                    // �@�볣�|���� Token �����Ĵ���
                    ValidateLifetime = true,
                    // �p�G Token ���]�t key �~�ݭn���ҡA�@�볣�u��ñ���Ӥw
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
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();// ������

            app.UseAuthorization();// �A���v

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
