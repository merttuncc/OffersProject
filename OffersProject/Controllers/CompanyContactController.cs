using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfferModels.Models;
using OfferModuleProject.Context;
using OffersProject.Common;
using OffersProject.Models.CompanyContactModels;
using OffersProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyContactController : ControllerBase
    {
        private readonly CompanyContactService _companyContactService;

        public CompanyContactController(CompanyContactService companyContactService)
        {
            this._companyContactService = companyContactService;
        }

        [HttpGet("GetCompanyList/{companyId}")]
        public IActionResult GetCompanyList(int companyId)
        {
            var response = _companyContactService.GetCompanyContactNamesByCompanyId(companyId);
            return Ok(response);
        }
        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContact(CompanyContactInfo companyContactInfo)
        {
            var vResult = await _companyContactService.AddCompanyContact(companyContactInfo);
            return Ok(vResult);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> CompanyContactDelete(int id)
        {
            var vResult = await _companyContactService.CompanyContactDelete(id);
            return Ok(vResult);
        }
        [HttpPut("UpdateContact")]
        public async Task<IActionResult> CompanyContactUpdate(CompanyContactInfo companyContactInfo)
        {
            var vResult =await _companyContactService.CompanyContactUpdate(companyContactInfo);
            return Ok(vResult);
        }
    //    [HttpGet("{id}")]
    //    public IActionResult GetCompanyContactByCompany(int id)
    //    {
    //        return _context.Set<CompanyContact>().Find(id);
    //    }
    }
}
