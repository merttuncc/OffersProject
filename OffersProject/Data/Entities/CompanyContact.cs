
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferModels.Models
{
    public class CompanyContact
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Task { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }

        //Navigation Property
        public virtual Company Company { get; set; }

        //public List<Offer> Offers { get; set; }
        //public ICollection<OfferContact> OfferContacts { get; set; }
    }
}
