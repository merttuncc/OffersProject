using OfferModels.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Models.UserModels
{
<<<<<<< HEAD:OffersProject/Models/UserModels/UserForRegister.cs
    public class UserForRegister
=======
    public class User
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a:OffersProject/Data/Entities/User.cs
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegistrationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}
