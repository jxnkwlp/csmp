using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSMP.Portal.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

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

			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(_configuration.GetConnectionString("Default"));
#if DEBUG
				options.EnableDetailedErrors(true);
				options.EnableSensitiveDataLogging(true);
#endif
			});

			services.AddSpaStaticFiles(options =>
			{
				options.RootPath = "ClientApp/dist";
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
			});

			//services.AddAuthentication()
			//	.AddJwtBearer();
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
