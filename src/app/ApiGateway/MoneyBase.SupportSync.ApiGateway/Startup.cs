﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.Extensions.Hosting;

namespace MoneyBase.SupportSync.ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();
            services.AddSwaggerForOcelot(Configuration);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            
            app.UseSwaggerForOcelotUI(opt =>
            {
                if (!env.IsDevelopment())
                    opt.DownstreamSwaggerEndPointBasePath = "/MoneyBase.SupportSync.ApiGateway/swagger/docs";
                else
                    opt.PathToSwaggerGenerator = "/swagger/docs";
            })
            .UseOcelot()
            .Wait();
        }
    }
}
