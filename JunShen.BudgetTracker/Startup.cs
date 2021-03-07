using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BudgetTracker.Infrastructure;
using BudgetTracker.Core.ServiceInterface;
using BudgetTracker.Infrastructure.Services;
using BudgetTracker.Core.RepositoryInterface;
using BudgetTracker.Infrastructure.Repositories;
using BudgetTracker.Core.Entities;
using BudgetTracker.Core;

namespace JunShen.BudgetTracker
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JunShen.BudgetTracker", Version = "v1" });
            });

            services.AddDbContext<BudgetTrackerDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("BudgetTrackerDbConnection"))
            );

            services.AddHttpContextAccessor();

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();
            services.AddTransient<IExpenditureRepository, ExpenditureRepository>();

            services.AddTransient<IAsyncRepository<User>, EfRepository<User>>();
            services.AddTransient<IAsyncRepository<Income>, EfRepository<Income>>();
            services.AddTransient<IAsyncRepository<Expenditure>, EfRepository<Expenditure>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JunShen.BudgetTracker v1"));
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader()
                    .AllowAnyMethod().AllowCredentials();
            });


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
