using CleanTheet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Persistance;

public class CleanTeethDbContext:DbContext
{
    public CleanTeethDbContext(DbContextOptions<CleanTeethDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanTeethDbContext).Assembly);
    }

    public DbSet<DentalOffice> DentalOffices { get; set; }
}
