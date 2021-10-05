using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferModels.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string OfferPrefix { get; set; }
        public string OfferNumber { get; set; }
        public List<CompanyContact> CompanyContacts { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
