using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Models.OfferDetailsModel
{
    public class OfferDetailSummary
    {
        public int Id { get; set; }
        public int OfferId { get; set; }
        public int RowNumber { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Definition { get; set; }
        public Boolean Optional { get; set; }
        public decimal UnitProfit { get; set; }
        public decimal UnitCost { get; set; }
    }
}
