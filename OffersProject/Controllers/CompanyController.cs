using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferModels.Models;
using OfferModuleProject.Context;
using OffersProject.Models.CompanyModels;
using OffersProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : Controller
    {

        private readonly CompanyService _companyService;
        //private readonly IMapper _mapper;
        public CompanyController(CompanyService companyService/*, IMapper mapper*/)
        {
            _companyService = companyService;
            //_mapper = mapper;
        }

        [HttpGet("GetCompanyList")]
        public IActionResult GetSummaryList()
        {

            var vResult = _companyService.GetSummaryList();
            //var Result = _mapper.Map<List<CompanySummary>>(vResult);
            return Ok(vResult);
        }

        [HttpGet("GetCompanyList/{searchString}")]
        public IActionResult GetSearchList(string searchString)
        {
            
            var vResult = _companyService.GetSearchList(searchString);
            //var Result = _mapper.Map<List<CompanySummary>>(vResult);
            return Ok(vResult);
        }
        

        [HttpGet("GetCompanyById/{id}")]
        public IActionResult GetInfo (int id)
        {
            var vResult = _companyService.GetInfo(id);
            return Ok(vResult);
        }

        [HttpPost("AddCompany")]
        public async Task<IActionResult> AddCompany(CompanyInfo companyInfo)
        {

            var vResult =await _companyService.AddCompany(companyInfo);
            return Ok(vResult);
        }
        [HttpDelete("DeleteCompany/{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var vResult = await _companyService.DeleteCompany(id);
            return Ok(vResult);
        }
        [HttpPut("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany(CompanyInfo companyInfo)
        {
            var vResult = await _companyService.UpdateCompany(companyInfo);
                return Ok(vResult);
        }
        
        //[HttpPost]
        //public ActionResult Add(Company company)
        //{
        //    var comp = new Company
        //    {
        //        CompanyName = company.CompanyName,
        //        Fax = company.Fax,
        //        OfferNumber = company.OfferNumber,
        //        OfferPrefix = company.OfferPrefix,
        //        Offers = company.Offers,
        //        PhoneNumber = company.PhoneNumber
        //    };
        //    _dataBase.Companies.Add(comp);
        //    _dataBase.SaveChanges();
        //    return CreatedAtAction("Get", new { id = comp.Id }, comp);
        //}
        //[HttpPut("{id}")]
        //public ActionResult Update(int id, Company company)
        //{
        //    var comp = _dataBase.Companies.FirstOrDefault(p => p.Id == id);
        //    if (comp is null)
        //    {
        //        comp = new Company
        //        {
        //            CompanyName = company.CompanyName,
        //            Fax = company.Fax,
        //            PhoneNumber = company.PhoneNumber,
        //            Id = id
        //        };
        //        _dataBase.Companies.Add(comp);
        //        _dataBase.SaveChanges();
        //        return CreatedAtRoute("Get", new { id = id }, comp);
        //    }
        //    comp.CompanyName = company.CompanyName;
        //    comp.Fax = company.Fax;
        //    comp.PhoneNumber = company.PhoneNumber;
        //    _dataBase.SaveChanges();
        //    return NoContent();
        //}
        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    var delete = _dataBase.Companies.FirstOrDefault(x => x.Id == id);
        //    if (delete is null) return NotFound();
        //    _dataBase.Remove(delete);
        //    _dataBase.SaveChanges();
        //    return Ok();
        //}
        //[HttpGet("{id}")]
        //public Company Get(int id)
        //{
        //    return _dataBase.Companies.FirstOrDefault(c => c.Id == id);
        //}
    }
}
