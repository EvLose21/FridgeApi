using FridgeProduct.Auditable.Data;
using FridgeProduct.Auditable.Data.Models;
using FridgeProduct.Auditable.Data.Repositories;
using FridgeProduct.Auditable.Data.Repositories.Abstracts;
using FridgeProduct.Auditable.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeProduct.Auditable
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
            services.AddDbContext<RecieveMessageContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FridgeProduct.Auditable", Version = "v1" });
            });
            services.AddSingleton<Func<List<RecieveMessage>, RecieveMessageContext, int>>(serviceProvider =>
            (messages, context)=>
            {
                context.Messages.AddRange(messages);
                return context.SaveChanges();
            });
            //services.AddScoped<IRecieveMessageRepository, RecieveMessageRepository>();
            services.AddScoped<IRecieveMessageRepository, RecieveMessageRepository>();
            services.AddSingleton<IDbContextFactory, DbContextFactory>();
            //services.AddSingleton<RabbitMqConfiguration>(provider=>new RabbitMqConfiguration() { Hostname = "localhost", QueueName = "fridges", Enabled = true});
            //services.AddDbContextFactory<RecieveMessageContext>(options => options
            //    .UseSqlServer(Configuration.GetConnectionString("sqlConnection")), ServiceLifetime.Singleton);
            services.AddHostedService<Listener>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FridgeProduct.Auditable v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
