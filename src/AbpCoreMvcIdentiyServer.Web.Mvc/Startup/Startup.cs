using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using AbpCoreMvcIdentiyServer.Authentication.JwtBearer;
using AbpCoreMvcIdentiyServer.Configuration;
using AbpCoreMvcIdentiyServer.Identity;
using AbpCoreMvcIdentiyServer.Web.Resources;
using Abp.AspNetCore.SignalR.Hubs;
using AbpCoreMvcIdentiyServer.Authentication;
using AbpCoreMvcIdentiyServer.Authorization.Users;
using Abp.IdentityServer4;

namespace AbpCoreMvcIdentiyServer.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            );

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                    .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                    .AddInMemoryClients(IdentityServerConfig.GetClients())
                    .AddAbpPersistedGrants<IAbpPersistedGrantDbContext>()
                    .AddAbpIdentityServer<User>();

            services.AddScoped<IWebResourceManager, WebResourceManager>();

            services.AddSignalR();

            // Configure Abp and Dependency Injection
            return services.AddAbp<AbpCoreMvcIdentiyServerWebMvcModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); // Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            // 
            if (bool.Parse(_appConfiguration["Authentication:JwtBearer:IsEnabled"]))
            {
                app.UseAuthentication();
                app.UseJwtTokenMiddleware();
            }
            else if (bool.Parse(_appConfiguration["Authentication:IdentityServer4:IsEnabled"]))
            {
                app.UseJwtTokenMiddleware("IdentityBearer");
                app.UseIdentityServer();
            }


            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });


            app.UseMvcWithDefaultRoute();
        }
    }
}
