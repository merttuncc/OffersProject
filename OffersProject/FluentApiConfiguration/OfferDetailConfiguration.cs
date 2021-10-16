using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.FluentApiConfiguration
{
    public class OfferDetailConfiguration:IEntityTypeConfiguration<OfferDetail>
    {
        public void Configure(EntityTypeBuilder<OfferDetail> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.Property(a => a.UnitPrice).HasColumnType("decimal(5,2)").IsRequired();
            modelBuilder.Property(a => a.TotalPrice).HasColumnType("decimal(5,2)").IsRequired();
            modelBuilder.Property(a => a.UnitProfit).HasColumnType("decimal(5,2)").IsRequired();
            modelBuilder.Property(a => a.UnitCost).HasColumnType("decimal(5,2)").IsRequired();
            

            modelBuilder.HasOne(a => a.Offer).WithMany(a => a.OfferDetail).HasForeignKey(a => a.OfferId);


        }
    }
}
