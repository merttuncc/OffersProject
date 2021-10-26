using OfferModels.Models.Enums;
<<<<<<< HEAD
<<<<<<< HEAD
=======
using OffersProject.Models.CurrencyModel;
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
=======
using OffersProject.Models.CurrencyModel;
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Models.OfferDetailsModel
{
    public class OfferDetailInfo
    {
        public int Id { get; set; }
        public int OfferId { get; set; }

        public int RowNumber { get; set; }//Sıra Numarası
        public int Quantity { get; set; }//Miktar
        public string Description { get; set; }//Açıklama
        public decimal UnitPrice { get; set; }//Birim Fiyat
        public decimal TotalPrice { get; set; }//Toplam Fiyat
        public string Definition { get; set; }//Tanım
        public Boolean Optional { get; set; }//Opsiyonel
        public decimal UnitProfit { get; set; }//Birim kar
        public decimal UnitCost { get; set; }

        public Currency Currency { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
=======

        
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
=======

        
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
    }
}
