using OfferModels.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferModels.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public int OfferDetailsId { get; set; }

        public int CompanyId { get; set; }

        public int CompanyContactId { get; set; }
        public string CompanyName { get; set; }
        public string OfferNumber { get; set; }
        public DateTime OfferDate { get; set; }
        public DateTime ValidityDate { get; set; }
        public Currency Currency { get; set; }
        public DateTime OfferWaitTime { get; set; }
        public string OfferDefinition { get; set; }
        public string OfferBusinessInformation { get; set; }
        public decimal Rate { get; set; }
        public decimal Profit { get; set; }
        public Status Status{ get; set; }

        //Navigation Property
        public virtual Company Company { get; set; }
    }
}
