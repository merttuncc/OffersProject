using OfferModels.Models.Enums;
using OffersProject.Models.CurrencyModel;
using OffersProject.Models.OfferDetailsModel;
using System;
using System.Collections.Generic;

namespace OfferModels.Models
{
    public class OfferInfo
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


        public List<OfferDetailInfo> OfferDetailsInfo { get; set; }
        

    }
}
