using Microsoft.EntityFrameworkCore;
using OfferModels.Models;
using OffersProject.FluentApiConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferModuleProject.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyContact> Contacts { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferDetail> OfferDetails { get; set; }
        public DbSet<User> Users { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentApiCompany için

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyContactConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new OfferDetailConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Company>()
            //    .Property<bool>("IsDeleted");

        }

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    OnBeforeSaving();
        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    OnBeforeSaving();
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}

        //private void OnBeforeSaving()
        //{
        //    foreach (var entry in ChangeTracker.Entries<Company>())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.CurrentValues["IsDeleted"] = false;
        //                break;

        //            case EntityState.Deleted:
        //                entry.State = EntityState.Modified;
        //                entry.CurrentValues["IsDeleted"] = true;
        //                break;
        //        }
        //    }
        //}

    }
}





//HasDefaultSchema() ==>>       Varsayılan veritabanı şemasını belirtir.
//ComplexType()      ==>>       Sınıfı karmaşık tür olarak yapılandırır.
//HasIndex()         ==>>       Varlık türü için dizin özelliğini yapılandırır.
//HasKey()           ==>>       Varlık türü için birincil anahtar özelliğini yapılandırır.
//HasMany()          ==>>       Bire çoğa veya çoktan çoğa ilişkiler için Çok ilişkisini yapılandırır.
//HasOptional()     ==>>        Veritabanında boş bırakılabilir bir yabancı anahtar oluşturacak isteğe bağlı bir ilişki yapılandırır.
//HasRequired()      ==>>       Veritabanında null yapılamayan bir yabancı anahtar sütunu oluşturacak gerekli ilişkiyi yapılandırır.
//Ignore()           ==>>       Sınıf veya özelliğin bir tablo veya sütunla eşlenmemesi gerektiğini yapılandırır.
//Map()              ==>>       Varlığın veritabanı şemasına nasıl eşlendiğiyle ilgili gelişmiş yapılandırmaya izin verir.
//MapToStoredProcedures() ==>> Varlık türünü INSERT, UPDATE ve DELETE saklı yordamlarını kullanacak şekilde yapılandırır.
//ToTable()          ==>>       Varlık için tablo adını yapılandırır.
//HasColumnAnnotation() ==>>    Özelliği depolamak için kullanılan veritabanı sütunu için modelde bir açıklama ayarlar.
//IsRequired()          ==>>    SaveChanges() üzerinde gerekli olacak özelliği yapılandırır.
//IsConcurrencyToken() ==>>     İyimser eşzamanlılık belirteci olarak kullanılacak özelliği yapılandırır.
//IsOptional()           ==>>   Özelliği isteğe bağlı olacak şekilde yapılandırır ve bu, veritabanında null yapılabilir bir sütun oluşturur.
//HasParameterName()    ==>>    Özellik için saklı yordamda kullanılan parametrenin adını yapılandırır.
//HasDatabaseGeneratedOption() ==>> Veritabanındaki ilgili sütun için değerin nasıl oluşturulacağını yapılandırır, ör. hesaplanmış, kimlik veya hiçbiri.
//HasColumnOrder()      ==>>    Özelliği depolamak için kullanılan veritabanı sütununun sırasını yapılandırır.
//HasColumnType()      ==>>     Veritabanındaki bir özelliğin ilgili sütununun veri türünü yapılandırır.
//HasColumnName()      ==>>     Veritabanındaki bir özelliğin ilgili sütun adını yapılandırır.

