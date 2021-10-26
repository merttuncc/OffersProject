<<<<<<< HEAD
﻿using OfferModels.Models;
using System;
=======
﻿using System;
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.TutorialsCurrency.Models
{
    public class CurrencyModel
    {
        public int Unit { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string CrossRateUsd { get; set; }
        public string ForexSelling { get; set; }
        public decimal ForexBuying { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }

<<<<<<< HEAD
        

=======
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
        public static CurrencyModel Map(Tarih_DateCurrency x)
        {
            return new CurrencyModel
            {
                Unit = x.Unit,
                Name = x.CurrencyName,
                CurrencyCode = x.CurrencyCode,
                BanknoteSelling = x.BanknoteSelling,
                BanknoteBuying = x.BanknoteBuying,
                ForexBuying = x.ForexBuying,
                ForexSelling = x.ForexSelling,
                CrossRateUsd = x.CrossRateUSD

            };
        }
    }
}
