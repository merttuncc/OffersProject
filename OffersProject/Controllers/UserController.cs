//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using OfferModels.Models;
//using OfferModuleProject.Context;
//using OffersProject.Errors;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OffersProject.Controllers
//{
//    [Route("/controller")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        //private readonly ProjectDataBase _dataBase;

//        //public UserController(ProjectDataBase dataBase)
//        //{
//        //    _dataBase = dataBase;
//        //}

//        // GET /users
//        [HttpGet]
//        public IActionResult Get([FromQuery(Name = "email")] string email)
//        {
//            Users user = LoadUser(email); // whatever

//            if (user != null)
//            {
//                return Ok(user);
//            }
//            else
//            {
//                return NotFound(new NotFoundError("The user was not found"));
//            }
//        }

//        private Users LoadUser(string email)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
