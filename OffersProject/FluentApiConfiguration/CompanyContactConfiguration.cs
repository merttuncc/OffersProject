using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.FluentApiConfiguration
{
    public class CompanyContactConfiguration:IEntityTypeConfiguration<CompanyContact>
    {
        public void Configure(EntityTypeBuilder<CompanyContact> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.Property(a => a.CompanyId).IsRequired();
            modelBuilder.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
            modelBuilder.Property(a => a.LastName).HasMaxLength(100).IsRequired();
            modelBuilder.Property(a => a.Task).HasMaxLength(100).IsRequired();
            modelBuilder.Property(a => a.PhoneNumber).HasMaxLength(10).IsRequired();
            modelBuilder.Property(a => a.Mail).HasMaxLength(255).IsRequired();

            modelBuilder.HasOne(a => a.Company)
                .WithMany(a => a.CompanyContacts).HasForeignKey(a => a.CompanyId);


        }
    }
}
