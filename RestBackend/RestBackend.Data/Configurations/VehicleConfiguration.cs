using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBackend.Core.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBackend.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder
                 .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                 .HasOne(m => m.Type)
                 .WithMany(a => a.Vehicles)
                 .HasForeignKey(m => m.TypeId);

            builder
              .HasOne(m => m.Brand)
              .WithMany(a => a.Vehicles)
              .HasForeignKey(m => m.BrandId);

            builder
                .ToTable("Vehicles");
        }
    }
}
