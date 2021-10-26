using AutoMapper;
using OfferModels.Models;
using OffersProject.Models.CompanyContactModels;
using OffersProject.Models.CompanyModels;
using OffersProject.Models.OfferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Company, CompanySummary>();
            CreateMap<CompanySummary, Company>();

            CreateMap<OfferSummary, Offer>();
            CreateMap<Offer, OfferSummary>()
                .ForMember(member1 => member1.CompanyName, member2 => member2.MapFrom(x => x.Company.CompanyName))
                .ForMember(member1 => member1.ContactName, member2 => member2.MapFrom(x => x.CompanyContact.FirstName));

            //.IncludeMembers(x => x.Company);

            CreateMap<Offer, OfferDetail>();
            CreateMap<OfferDetail, Offer>();
            CreateMap<CompanyContact, CompanyContactSummary>();
            CreateMap<CompanyContactSummary, CompanyContact>();



        }
    }
}
