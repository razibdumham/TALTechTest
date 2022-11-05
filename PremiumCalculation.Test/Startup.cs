using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PremiumCalculation.Infrastructure;
using PremiumCalculation.Infrastructure.UnitOfWork;
using PremiumCalculation.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculation.Test
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PremiumCalculationDBContext>(options =>
            {
                options.UseSqlServer("Server=.\\SQLEXPRESS;Database=PremiumCalculation;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            // Adding the Unit of work to the DI container
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<ICalculationService, CalculationService>();
            services.AddTransient<IOccupationService, OccupationService>();
        }
    }
}
