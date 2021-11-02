using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.FluentApiConfiguration
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
            modelBuilder.Property(a => a.LastName).HasMaxLength(100).IsRequired();
            modelBuilder.Property(a => a.RegistrationNumber).HasMaxLength(100).IsRequired();
            modelBuilder.Property(a => a.PhoneNumber).HasMaxLength(10).IsRequired();
            modelBuilder.Property(a => a.Mail).HasMaxLength(255).IsRequired();
            modelBuilder.Property(a => a.Password).HasMaxLength(255).IsRequired();
            modelBuilder.Property(a => a.PasswordHash).HasMaxLength(255).IsRequired();
            modelBuilder.Property(a => a.PasswordSalt).HasMaxLength(255).IsRequired();
            

            


        }
    }
}
