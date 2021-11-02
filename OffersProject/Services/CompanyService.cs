using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OfferModels.Models;
using OfferModuleProject.Context;
using OffersProject.Common;
using OffersProject.Models.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Services
{
    public class CompanyService
    {
        Context _context;
        IMapper _mapper;
        public CompanyService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result<List<CompanySummary>> GetSummaryList()
        {
            try
            {
                var vCompanyList = _context.Companies;
                var vCompanySummaryList = _mapper.Map<List<CompanySummary>>(vCompanyList)
                //.Select(company => new CompanySummary
                //{
                //    Id = company.Id,
                //    CompanyName = company.CompanyName,
                //    PhoneNumber = company.PhoneNumber,
                //    OfferPrefix = company.OfferPrefix,
                //    OfferNumber = company.OfferNumber
                //})
                .ToList();
                
                
                return Result<List<CompanySummary>>.PrepareSuccess(vCompanySummaryList); 
            }
            catch (Exception vEx)
            {
                return Result<List<CompanySummary>>.PrepareFailure(vEx.Message);
            }
        }
        
        
        public Result<List<CompanySearch>> GetSearchList(string searchString)
        {
            
            try
            {
                List<CompanySearch> vCompanyList=new List<CompanySearch>();


                if (searchString.Length>2)
                {
                    
                    vCompanyList = _context.Companies
                    .Select(company => new CompanySearch
                    {

                        CompanyName = company.CompanyName

                    }).Where(s => s.CompanyName.Contains(searchString)).ToList();
            
                }

                //if (!String.IsNullOrEmpty(searchString))
                //{

                //    vCompanyList = vCompanyList.Where(s => s.CompanyName.Contains(searchString));
                //}
                
                return Result<List<CompanySearch>>.PrepareSuccess(vCompanyList);
            }
            catch (Exception vEx)
            {
                return Result<List<CompanySearch>>.PrepareFailure(vEx.Message);
            }
        }



        public Result<CompanySummary> GetInfo(int id)
        {


            var vCompany = _context.Companies;
            var vCompanyInfo = _mapper.Map<List<CompanySummary>>(vCompany)
                .FirstOrDefault(company => company.Id == id);
            //.Select(company => new CompanyInfo
            //{
            //    Id = company.Id,
            //    CompanyName = company.CompanyName,
            //    Address = company.Address,
            //    PhoneNumber = company.PhoneNumber,
            //    FaxNumber = company.FaxNumber,
            //    OfferPrefix = company.OfferPrefix,
            //    OfferNumber = company.OfferNumber
            //})


            return Result<CompanySummary>.PrepareSuccess(vCompanyInfo);
        }

        //public Result<CompanyInfo> GetInfo(int id)
        //{


        //    var vCompanyInfo = _context.Companies


        //    return Result<CompanyInfo>.PrepareSuccess(vCompanyInfo);
        //}

        public async Task<Result> AddCompany(CompanyInfo companyInfo)
        {
            try
            {
                //Company company = _mapper.Map<Company>(companyInfo);

                var vCompany = new Company
                {
                    Id = companyInfo.Id,
                    CompanyName = companyInfo.CompanyName,
                    Address = companyInfo.Address,
                    PhoneNumber = companyInfo.PhoneNumber,
                    FaxNumber = companyInfo.FaxNumber,
                    OfferPrefix = companyInfo.OfferPrefix,
                    OfferNumber = companyInfo.OfferNumber
                };

                _context.Companies.Add(vCompany);
                await _context.SaveChangesAsync();

                return Result.PrepareSuccess();
            }
            catch (Exception vEx)
            {
                return Result.PrepareFailure(vEx.Message);
            }

        }
        public async Task<Result> UpdateCompany(CompanyInfo companyInfo)
        {
            try
            {
                var vCompany = _context.Companies
                    .FirstOrDefault(company => company.Id == companyInfo.Id);

                vCompany.CompanyName = companyInfo.CompanyName;
                vCompany.Address = companyInfo.Address;
                vCompany.PhoneNumber = companyInfo.PhoneNumber;
                vCompany.FaxNumber = companyInfo.FaxNumber;
                vCompany.OfferPrefix = companyInfo.OfferPrefix;

                await _context.SaveChangesAsync();

                return Result.PrepareSuccess();
            }
            catch (Exception vEx)
            {
                return Result.PrepareFailure(vEx.Message);
            }
        }

        public async Task<Result> DeleteCompany(int id)
        {
            try
            {
                var vCompanyInfo = _context.Companies
                    .FirstOrDefault(company => company.Id == id);

                _context.Remove(vCompanyInfo);

                var isSuccess = await _context.SaveChangesAsync() > 0;
                return isSuccess
                    ? Result.PrepareSuccess()
                    : Result.PrepareFailure("Silme işlemi başarısız");
            }
            catch (Exception vEx)
            {
                return Result.PrepareFailure(vEx.Message);
            }

        }
    }
}

/*
                var vCompanyList = _context.Companies                       
                       .ToList();

                var vCompanySummaryList = new List<CompanySummary>();
                foreach (var vCompany in vCompanyList)
                {
                    var vCompanySummary = new CompanySummary
                    {
                        Id = vCompany.Id,
                        CompanyName = vCompany.CompanyName,
                        PhoneNumber = vCompany.PhoneNumber,
                        OfferPrefix = vCompany.OfferPrefix,
                        OfferNumber = vCompany.OfferNumber
                    };

                    vCompanySummaryList.Add(vCompanySummary);
                }
                */
//Result<List<CompanySummary>> vResult = new Result<List<CompanySummary>>();
//vResult.Success = true;
//vResult.Payload = vCompanyList;
/*
            var vCompany  = await _context.Companies               
                .FirstOrDefaultAsync(company => company.Id == id);

            if (vCompany != null)
                var vCompanyInfo = new CompanyInfo
                {
                    Id = vCompany.Id,
                    CompanyName = vCompany.CompanyName,
                    Address = vCompany.Address,
                    PhoneNumber = vCompany.PhoneNumber,
                    FaxNumber = vCompany.FaxNumber,
                    OfferPrefix = vCompany.OfferPrefix,
                    OfferNumber = vCompany.OfferNumber
                };
            */