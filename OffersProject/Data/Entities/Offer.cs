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
        public int CompanyId { get; set; }
        public int CompanyContactId { get; set; }
        public int OfferNumber { get; set; }
        public string Annotations { get; set; }
        public string CommercialConditions { get; set; }//Ticari Açıklama
        public string TimeInformation { get; set; }
        public decimal ProfitRate { get; set; }//Kar Oranı

        public DateTime Date { get; set; }
        public DateTime ValidityDate { get; set; }//Geçerlilik Tarihi      


        public Currency Currency { get; set; } //Para Birimi
        public Status Status { get; set; }// Durum=Olumlu,Olumsuz,Beklemede

        

        //Navigation Property
        public virtual Company Company { get; set; }

        public virtual CompanyContact CompanyContact { get; set; }

        public virtual List<OfferDetail> OfferDetail { get; set; } 

        public virtual User User { get; set; }

        //public ICollection<OfferContact> OfferContacts { get; set; }
    }
}
