using Logic.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			
			var commandsConnectionString = new CommandsConnectionString(Configuration["ConnectionString"]);
			var queriesConnectionString = new QueriesConnectionString(Configuration["QueriesConnectionString"]);
			services.AddSingleton(commandsConnectionString);
			services.AddSingleton(queriesConnectionString);

			services.AddSingleton<Logic.Utils.Messages>();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
		}
	}
}
