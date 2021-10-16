using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.FluentApiConfiguration
{
    public class CompanyConfiguration:IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.Property(a => a.CompanyName)
                .HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            modelBuilder.Property(a => a.Address)
                 .HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            modelBuilder.Property(a => a.PhoneNumber)
                 .HasColumnType("varchar").HasMaxLength(10).IsRequired();
            modelBuilder.Property(a => a.FaxNumber)
                 .HasColumnType("varchar").HasMaxLength(10).IsRequired();
            modelBuilder.Property(a => a.OfferPrefix)
                 .HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            modelBuilder.Property(a => a.OfferNumber)
                 .HasColumnType("int").IsRequired();
            
        }
    }
}
