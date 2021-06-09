using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.IoC;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace MicroRabbit.Transfer.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<TransferDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("TransferDbConnection"));
			});

			services.AddControllers();
			RegisterServices(services);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microservice v1"));
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			ConfigureEventBus(app);
		}

		private static void ConfigureEventBus(IApplicationBuilder app)
		{
			var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
			eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();
		}

		private void RegisterServices(IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Transfer Microservice",
					Version = "v1",
					Description = "Transfer.Api Microservice"
				});

				c.IncludeXmlComments(GetXmlCommentsPath());
			});

			//services.AddMediatR(typeof(Startup));
			DependencyContainer.RegisterServices(services);
		}

		private static string GetXmlCommentsPath()
		{
			var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
			return xmlPath;
		}
	}
}
