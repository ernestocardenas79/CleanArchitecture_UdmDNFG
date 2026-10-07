using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanTeeth.Persistence.Configurations;

internal class AppoimentConfig : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.OwnsOne(prop => prop.TimeInterval, action =>
        {
            action.Property(p => p.Start).HasColumnName("Start");
            action.Property(p => p.End).HasColumnName("End");
        });
    }
}
