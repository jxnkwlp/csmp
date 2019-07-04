using CSMP.Portal.Data;
using CSMP.Portal.Web.Jobs;
using CSMP.Portal.Web.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

namespace CSMP.Portal.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services
                .AddDbContext<AppDbContext>(options =>
                {
                    // options.UseSqlServer(_configuration.GetConnectionString("Default"), config => config.CommandTimeout(30).EnableRetryOnFailure(5));

                    options.UseInMemoryDatabase("csmp");
#if DEBUG
                    options.EnableDetailedErrors(true);
                    options.EnableSensitiveDataLogging(true);
#endif
                })
                .AddUnitOfWork<AppDbContext>();

            services.AddMemoryCache();

            services.AddSpaStaticFiles(options =>
            {
                options.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddAuthentication()
                .AddAgentAuthentication()
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        // ValidAudience = "web",
                        // ValidIssuer = "web",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eb86d203-62a9-4e32-ad2d-adc93484a2d6"))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                                            .RequireAuthenticatedUser()
                                            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme, AgentAuthenticationOptions.AuthenticationScheme)
                                            .Build();

                options.AddPolicy("Agent", (b) => { b.RequireRole("Agent"); });
            });


            //services.AddHostedService<SnapshotDataQueueHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1");
            });

            app.UseSpa(config =>
            {
                config.Options.SourcePath = "ClientApp";
            });
        }
    }
}
