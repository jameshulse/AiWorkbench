using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Diagnostics;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Hosting;
using System;

namespace AiWorkbench.Web
{
    public class Startup
    {
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

            services.AddSignalR(o =>
            {
                o.Hubs.EnableDetailedErrors = true;
            });

            services.AddLogging();
		}

		public void Configure(
			IApplicationBuilder builder,
			IHostingEnvironment environment,
			ILoggerFactory loggerfactory)
		{
			SetupMiddleware(builder, environment);

            loggerfactory.AddConsole();
		}

		private static void SetupMiddleware(IApplicationBuilder builder, IHostingEnvironment environment)
        {
            // Add the following to the request pipeline only in development environment.
            if (string.Equals(environment.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
            {
                //builder.UseBrowserLink();
                builder.UseErrorPage(ErrorPageOptions.ShowAll);
            }
            else
            {
                builder.UseErrorHandler("/Error");
            }

            builder.UseErrorPage(ErrorPageOptions.ShowAll);
            builder.UseStaticFiles();
			builder.UseMvc(r => r.MapRoute("default", "{controller=Workbench}/{action=Index}/{id?}"));
            builder.UseSignalR();
        }
	}
}