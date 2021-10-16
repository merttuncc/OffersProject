using OfferModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Models.OfferModels
{
    public class OfferSummary
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public int OfferNumber { get; set; }
        public string Annotations { get; set; }
        public string CommercialConditions { get; set; }//Ticari Açıklama
        public string TimeInformation { get; set; }
        public decimal ProfitRate { get; set; }//Kar Oranı


        public DateTime Date { get; set; }
        public DateTime ValidityDate { get; set; }//Geçerlilik Tarihi                
    }
}