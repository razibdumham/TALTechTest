using Microsoft.EntityFrameworkCore;
using PremiumCalculation.Domain;
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

        public virtual DbSet<Occupation> Occupations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
