using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Persistence.Configurations;

internal class PatientConfig: IEntityTypeConfiguration<Patient>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(250);

        builder.ComplexProperty(prop=> prop.Email, action=>
            action.Property(e=>e.Value).HasColumnName("Email").HasMaxLength(254)
        );
    }
}
