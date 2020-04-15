using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyAirportGraphQL.GraphQLType;
using GraphQL.Types;
using MASB.MyAirport.EF;
using GraphQL;
using GraphQL.Server;
using MyAirportGraphQL;
using Microsoft.EntityFrameworkCore;

namespace MyAirportGraphQL
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

            ///test =https://localhost:5001/graphql/?Query={bagages{bagageID}}

            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddScoped<BagageType>();
            services.AddScoped<VolType>();
            services.AddScoped<AirportQuery>();
            services.AddScoped<AirportSchema>();
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            });

            services.AddDbContext<MyAirportContext>(option =>
            option.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database = MyAirport; Trusted_Connection = True"));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQL<AirportSchema>();

            app.UseGraphiQLServer(new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions { GraphiQLPath = "/graphiql" });

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