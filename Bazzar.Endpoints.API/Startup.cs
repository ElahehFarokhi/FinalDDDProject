using Bazzar.Core.ApplicationServices.Advertisements.CommandHandler;
using Bazzar.Core.ApplicationServices.UserProfiles.CommandHandlers;
using Bazzar.Domain.Advertisements.Data;
using Bazzar.Domain.UserProfiles.Data;
using Bazzar.Infrastructure.Data.Fake1.Advertisements;
using Bazzar.Infrastructures.Data.EventsSourcings;
using Bazzar.Infrastructures.Data.SqlServer.Advertisments;
using Bazzar.Infrastructures.Data.SqlServer.UserProfiles;
using Bazzar.Infrastructures.Data.SQLServer;
using Bazzar.Infrastructures.Data.SQLServer.Advertisements;
using EventStore.ClientAPI;
using Framework.Domain.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Bazzar.Endpoints.API
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
            services.AddControllers();
            //services.AddScoped(c=>new SqlConnection(Configuration.GetConnectionString("Advertisement")));
            services.AddRazorPages();
            services.AddMvcCore().AddApiExplorer();

            var esConnection = EventStoreConnection.Create(Configuration["EventStore:ConnectionString"], ConnectionSettings.Create().KeepReconnecting(), Environment.ApplicationName);
            var store = new BazzarEventSource(esConnection);
            services.AddSingleton(esConnection);
            services.AddSingleton<IEventSource>(store);

            services.AddScoped<IAdvertisementRepository, EFAdvertisementRepository>();
            services.AddScoped<IUserProfileRepository, EFUserProfileRepository>();

            //services.AddScoped<IAdvertisementQueryService, AdvertisementQueryService>();
            services.AddScoped(c => new SqlConnection(Configuration.GetConnectionString("AdvertisementCnn")));

            services.AddScoped<IUnitOfWork, AdvertisementUnitOfWork>();

            services.AddDbContext<AdvertisementDBContext>(c => c.UseSqlServer(Configuration.GetConnectionString("AdvertisementCnn")));

            services.AddScoped<CreateHandler>();
            services.AddScoped<SetTitleHandler>();
            services.AddScoped<UpdateTextHandler>();
            services.AddScoped<UpdatePriceHandler>();
            services.AddScoped<RequestToPublishHandler>();

            services.AddScoped<RegisterUserHandler>();
            services.AddScoped<UpdateUserNameHandler>();
            services.AddScoped<UpdateUserEmailHandler>();
            services.AddScoped<UpdateUserDisplayNameHandler>();

            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Advertisement", Version = "v1" });
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c=> 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Advertisement API V1");
            }
            );
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
