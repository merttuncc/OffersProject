using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferModels.Models;
using OffersProject.Models.OfferDetailsModel;
using OffersProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OfferDetailsController : ControllerBase
    {
        OfferDetailsService _offerDetailsService;
        public OfferDetailsController(OfferDetailsService offerDetailsService)
        {
            _offerDetailsService = offerDetailsService;
        }
        [HttpGet("GetDetailByOfferId/{offerId}")]
        public IActionResult GetOfferDetailsByOffer(int offerId)
        {
            var vResult = _offerDetailsService.GetOfferDetailsByOfferId(offerId);
            return Ok(vResult);
        }
        //[HttpPost("AddOfferDetail")]
        //public async Task<IActionResult> AddOfferDetails(OfferDetailSummary offerDetailSummary)
        //{
        //    var vResult =await _offerDetailsService.AddOfferDetails(offerDetailSummary);
        //    return Ok(vResult);
        //}
        [HttpPut("UpdateOfferDetail")]
        public async Task<IActionResult> UpdateOfferDetails(OfferDetailInfo offerDetailInfo)
        {
            var vResult = await _offerDetailsService.UpdadeOfferDetails(offerDetailInfo);
            return Ok(vResult);
        }
    }
}
