using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculation.Infrastructure
{
    public class PremiumCalculationDBContext:DbContext
    {
        public PremiumCalculationDBContext(DbContextOptions<PremiumCalculationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
