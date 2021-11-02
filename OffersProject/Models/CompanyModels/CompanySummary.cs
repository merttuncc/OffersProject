using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Models.CompanyModels
{
    public class CompanySummary
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string OfferPrefix { get; set; }
        public int OfferNumber { get; set; }
    }
}
