﻿using OfferModels.Models.Enums;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferModels.Models
{
    public class User
=======
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Models.UserModels
{
<<<<<<< HEAD:OffersProject/Models/UserModels/UserForRegister.cs
    public class UserForRegister
=======
    public class User
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a:OffersProject/Data/Entities/User.cs
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegistrationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
<<<<<<< HEAD
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public Roles Role { get; set; }

        public virtual List<Offer> Offers { get; set; } 

=======
        public Roles Role { get; set; }
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
    }
}
