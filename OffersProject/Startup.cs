using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OfferModuleProject.Context;
using OffersProject.Helpers;
using OffersProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffersProject
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
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:Token").Value);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin());
                    //.WithOrigins("http://localhost:8080", "http://10.0.0.105:5001", "http://10.0.0.206:8080", "http://10.0.0.203:8080"));
            });
            services.AddDbContext<Context>(x => x.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<CompanyService>();
            services.AddScoped<CompanyContactService>();
            services.AddScoped<OfferService>();
            services.AddScoped<OfferDetailsService>();
            services.AddScoped<IAuthRepository,AuthRepository>();
            //services.AddScoped<CurrencyServiceTest>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey=new SymmetricSecurityKey(key),
                    ValidateIssuer=false,
                    ValidateAudience=false
                };
            });
            services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OffersProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OffersProject v1"));
            }
            //app.UseExceptionHandler("/errors/");

            //app.UseStatusCodePagesWithReExecute("/errors/{0}");

            //app.UseCors(builder => builder.WithOrigins("http://localhost:8080").AllowAnyHeader());

            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
