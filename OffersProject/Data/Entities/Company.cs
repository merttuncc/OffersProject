using System.Collections.Generic;

namespace OfferModels.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string OfferPrefix { get; set; }//Teklif Öneki
        public int OfferNumber { get; set; }

        //Navigation Properties
        public virtual List<CompanyContact> CompanyContacts { get; set; }
        public virtual List<Offer> Offers { get; set; }
        
    }
}
