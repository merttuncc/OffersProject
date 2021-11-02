using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferModels.Models;

namespace OffersProject.FluentApiConfiguration
{
    public class OfferConfiguration:IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.Property(a => a.CompanyId).IsRequired();
            modelBuilder.Property(a => a.CompanyContactId).IsRequired();
            modelBuilder.Property(a => a.OfferNumber).IsRequired();
            modelBuilder.Property(a => a.Annotations).IsRequired();
            modelBuilder.Property(a => a.CommercialConditions).IsRequired();
            modelBuilder.Property(a => a.TimeInformation).IsRequired();

            
            modelBuilder.Property(a => a.ProfitRate).HasColumnType("decimal(5,2)").IsRequired();

            modelBuilder.Property(a => a.Date).HasColumnType("Datetime").IsRequired();
            modelBuilder.Property(a => a.ValidityDate).HasColumnType("Datetime").IsRequired();
           
            modelBuilder.Property(a => a.Currency).HasColumnType("tinyint").IsRequired();
            modelBuilder.Property(a => a.Status).HasColumnType("tinyint").IsRequired();


            //modelBuilder.HasOne(a => a.OfferDetail)
            //    .WithOne(a => a.Offer).HasForeignKey<Offer>("Id");

            modelBuilder.HasOne(a => a.Company).WithMany(a => a.Offers)
                .HasForeignKey(a => a.CompanyId);

            modelBuilder.HasOne(a => a.User).WithMany(a => a.Offers)
                .HasForeignKey(a => a.UserId);

            //modelBuilder.HasOne(a => a.CompanyContact).WithMany(a => a.Offers)
            //    .HasForeignKey(a => a.Id);




        }
    }
}
