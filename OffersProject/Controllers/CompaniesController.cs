using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferModels.Models;
using OfferModuleProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ProjectDataBase _dataBase;
        public CompaniesController(ProjectDataBase dataBase)
        {
            _dataBase = dataBase;
        }
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _dataBase.Companies.ToList();
        }
        //[HttpGet("{id}")]
        //public Company Get(int id)
        //{
        //    return _dataBase.Companies.FirstOrDefault(c => c.Id == id);
        //}

        [HttpGet("id")]
        public ActionResult<Company> Get(int id)
        {
            var company = _dataBase.Companies.FirstOrDefault(c => c.Id == id);
            if (company is null) return NotFound();
            return company;
        }
        [HttpPost]
        public ActionResult Post(Company company)
        {
            var comp = new Company
            {
                CompanyName = company.CompanyName,
                Fax = company.Fax,
                OfferNumber = company.OfferNumber,
                OfferPrefix = company.OfferPrefix,
                Offers = company.Offers,
                PhoneNumber = company.PhoneNumber
            };
            _dataBase.Companies.Add(comp);
            _dataBase.SaveChanges();
            return CreatedAtAction("Get", new { id = comp.Id }, comp);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, Company company)
        {
            var comp = _dataBase.Companies.FirstOrDefault(p => p.Id == id);
            if (comp is null)
            {
                comp = new Company
                {
                    CompanyName = company.CompanyName,
                    Fax = company.Fax,
                    PhoneNumber = company.PhoneNumber,
                    Id = id
                };
                _dataBase.Companies.Add(comp);
                _dataBase.SaveChanges();
                return CreatedAtRoute("Get", new { id = id }, comp);
            }
            comp.CompanyName = company.CompanyName;
            comp.Fax = company.Fax;
            comp.PhoneNumber = company.PhoneNumber;
            _dataBase.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var delete = _dataBase.Companies.FirstOrDefault(x => x.Id == id);
            if (delete is null) return NotFound();
            _dataBase.Remove(delete);
            _dataBase.SaveChanges();
            return NoContent();
        }
    }
}
