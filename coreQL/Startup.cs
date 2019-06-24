using coreQL.Contracts;
using coreQL.Entities.Context;
using coreQL.QL.Schemas;
using coreQL.Repository;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace coreQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<appDbContext>(opt => opt.UseInMemoryDatabase("MyDB"));

            //services.AddDbContext<appDbContext>(opt => opt.UseSqlServer(appDbContext.ConexString));

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<AppSchema>();
            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                          .AddGraphTypes(ServiceLifetime.Scoped)
                          .AddDataLoader();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                             .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }

            var options = new DbContextOptionsBuilder<appDbContext>()
                .UseInMemoryDatabase(databaseName: "MyDB")
                .Options;

            //4. Call the DataGenerator to create sample data
            Dump.Initialize(options);

            // app.UseHttpsRedirection();
            app.UseGraphQL<AppSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

            app.UseMvc();

            // app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); });
        }
    }
}