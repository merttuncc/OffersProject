using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferModels.Models;
using OfferModuleProject.Context;
using OffersProject.Common;
using OffersProject.Models.OfferDetailsModel;
using OffersProject.Models.OfferModels;
using OffersProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class OfferController : Controller
    {
        private readonly OfferService _offerService;
        public OfferController(OfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet("GetListOffer")]
        public IActionResult GetOfferByDefinition()
        {
            var definition = _offerService.GetOfferSummary();
            return Ok(definition);
        }
      
        [HttpPost("AddOffer")]
        public async Task<IActionResult> AddOffer(OfferInfo offerInfo)
        {
            var offers = await _offerService.AddOffer(offerInfo);
            return Ok(offers);
        }
        [HttpDelete("DeleteOffer/{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var delete = await _offerService.DeleteOffer(id);
            return Ok(delete);
        }
        [HttpPut("UpdateOffer")]
        public async Task<IActionResult> UpdateOffer(OfferInfo offerInfo)
        {
            var offer = await _offerService.UpdateOffer(offerInfo);
            return Ok(offer);
        }
        

        //[HttpGet]
        //public IEnumerable<Offer> Get()
        //{
        //    return _database.Offers.ToList();
        //}

        //[HttpGet("id")]
        //public ActionResult<Offer> Get(int id)
        //{
        //    var offer = _database.Offers.FirstOrDefault(x => x.Id == id);
        //    if (offer == null) return Ok();
        //    return offer;
        //}

        //[HttpPost("add")]
        //public 
        //{


        //    //var ofer = new Offer
        //    //{
        //    //    OfferBusinessInformation = offer.OfferBusinessInformation,
        //    //    OfferDate = offer.OfferDate,
        //    //    OfferDefinition = offer.OfferDefinition,
        //    //    ValidityDate = offer.ValidityDate,
        //    //    OfferWaitTime = offer.OfferWaitTime,
        //    //    Rate = offer.Rate,
        //    //    Profit = offer.Profit
        //    //};

        //    //_database.Offers.Add(ofer);
        //    //_database.SaveChanges();
        //    //return CreatedAtAction("Get", new { id = offer.Id }, offer);
        //}

//        [HttpPut("{id}")]
//        public ActionResult<Offer> Put(int id, Offer offer)
//        {
//            var ofer = _database.Offers.FirstOrDefault(x => x.Id == id);
//            if (ofer == null)
//            {
//                ofer = new Offer
//                {
//                    OfferBusinessInformation = offer.OfferBusinessInformation,
//                    OfferDate = offer.OfferDate,
//                    OfferDefinition = offer.OfferDefinition,
//                    ValidityDate = offer.ValidityDate,
//                    OfferWaitTime = offer.OfferWaitTime,
//                    Rate = offer.Rate,
//                    Profit = offer.Profit
//                };
//                _database.Offers.Add(ofer);
//                _database.SaveChanges();
//                return CreatedAtRoute("Get", new { id = id }, ofer);
//            }

//            ofer.OfferBusinessInformation = offer.OfferBusinessInformation;
//            ofer.OfferDate = offer.OfferDate;
//            ofer.OfferDefinition = offer.OfferDefinition;
//            ofer.ValidityDate = offer.ValidityDate;
//            ofer.OfferWaitTime = offer.OfferWaitTime;
//            ofer.Rate = offer.Rate;
//            ofer.Profit = offer.Profit;
//            _database.SaveChanges();
//            return NoContent();

//        }
//        [HttpDelete("{id}")]
//        public ActionResult Delete(int id)
//        {
//            var offer = _database.Offers.FirstOrDefault(x => x.Id == id);
//            if (offer == null) return NotFound();

//            _database.Remove(offer);
//            _database.SaveChanges();
//            return NoContent();


//        }
    }
}
