using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OffersProject.TutorialsCurrency.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private ICurrencyService service;

        public CurrencyController()
        {
             service = new CurrencyService();   
        }
        
        [HttpGet]
        public IActionResult Get_Today()
        {
            var result =  service.GetToday();
            return Ok(result);
        }
    }
}
