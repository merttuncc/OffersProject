using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Models.CompanyContactModels
{
    public class CompanyContactInfo
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Task { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
    }
}
