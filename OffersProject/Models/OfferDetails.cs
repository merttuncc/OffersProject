using OfferModels.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferModels.Models
{
    public class OfferDetails
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal KDV { get; set; }
        public Currency currency { get; set; }
        public string Definition { get; set; }
        public string OptionNumber { get; set; }
        public Boolean Optional { get; set; }
        public decimal Profit { get; set; }
    }
}
