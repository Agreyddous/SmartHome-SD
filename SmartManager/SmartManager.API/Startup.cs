using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SmartManager.Domain.SmartContext.Handlers;
using SmartManager.Domain.SmartContext.Repositories;
using SmartManager.Domain.SmartContext.Services;
using SmartManager.Infra.SmartContext.DataContext;
using SmartManager.Infra.SmartContext.Repositories;
using SmartManager.Infra.SmartContext.Services;
using SmartManager.Shared.SmartShared;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SmartManager.API
{
	public class Startup
	{
		private readonly IHostingEnvironment _hostingEnvironment;

		public static IConfiguration Configuration { get; set; }

		public Startup(IHostingEnvironment hostingEnvironment) => _hostingEnvironment = hostingEnvironment;

		public void ConfigureServices(IServiceCollection services)
		{
			Configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile(_hostingEnvironment.IsProduction() ? "appsettings.json" : $"appsettings.{_hostingEnvironment.EnvironmentName}.json", false, false)
				.Build();

			Settings.ConnectionString = $"{Configuration["connectionString"]}";
			Settings.DatabaseName = $"{Configuration["databaseName"]}";

			services.AddScoped<SmartDataContext, SmartDataContext>();

			services.AddTransient<SmartObjectCommandHandler, SmartObjectCommandHandler>();
			services.AddTransient<ISmartObjectRepository, SmartObjectRepository>();
			services.AddTransient<ISmartObjectCommunicationService, SmartObjectCommunicationService>();

			services.AddMvc().AddJsonOptions(options =>
			{
				options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			});

			services.AddResponseCompression();

			services.AddDistributedMemoryCache();

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Info
				{
					Version = "v1",
					Title = "Smart API",
					Description = "Smart Project",
					TermsOfService = "None"
				});

				options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

			app.UseMvc();

			app.UseResponseCompression();

			app.UseSwagger();

			app.UseSwaggerUI(options =>
			{
				options.DocumentTitle = "Smart";

				options.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart - V1");
				options.RoutePrefix = string.Empty;

				options.InjectStylesheet(Path.Combine(AppContext.BaseDirectory, "swagger.css"));

				options.DefaultModelsExpandDepth(-1);
				options.DocExpansion(DocExpansion.None);
			});
		}
	}
}
