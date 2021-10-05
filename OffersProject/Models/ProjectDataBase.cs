using Microsoft.EntityFrameworkCore;
using OfferModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferModuleProject.Context
{
    public class ProjectDataBase:DbContext
    {
        public ProjectDataBase(DbContextOptions<ProjectDataBase> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyContact> Contacts { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferDetails> offerDetails { get; set; }
        public DbSet<Users> users { get; set; }

    }
}