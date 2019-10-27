using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using PluralSightCoreProject_CityInfo.Entities;
using PluralSightCoreProject_CityInfo.Models;
using PluralSightCoreProject_CityInfo.Services;

namespace PluralSightCoreProject_CityInfo
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration /*IHostingEnvironment env*/)
        {
            Configuration = configuration;

            //Configuration = new ConfigurationBuilder()
            //.SetBasePath(env.ContentRootPath)
            //.AddJsonFile("appsettings.json", optional:false, reloadOnChange:true).Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions(options => options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

            services.Configure<EmailConfigurationModel>(Configuration.GetSection("mailSettings"));
            services.Configure<ConnectionStringsModel>(Configuration.GetSection("ConnectionStrings"));

            // services.AddDbContext<CityInfoContext>(o=> o.UseSqlServer(""));

            services.AddDbContext<CityInfoContext>();
#if DEBUG
            services.AddSingleton<IMailService, LocalMailService>();

#else
            services.AddSingleton<IMailService, CloudMailService>();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CityInfoContext context)
        {
            // loggingBuilder.AddProvider(new NLogLoggerProvider());
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            context.EnsureSeedDataForContext();
            app.UseStatusCodePages();
            app.UseMvc();

            //app.Run(async (context) => throw new Exception("Blah"));
        }
    }
}