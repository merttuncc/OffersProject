using OfferModels.Models;
using OfferModuleProject.Context;
using OffersProject.Common;
using OffersProject.Models.CompanyContactModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Services
{
    public class CompanyContactService
    {
        Context _context;

        public CompanyContactService(Context context)
        {
            _context = context;
        }
        // CompanyContactModels yerine string yapabiliriz
        public Result<List<CompanyContactSummary>> GetCompanyContactNamesByCompanyId(int companyId)
        {
            var nameList = _context.Contacts
                .Where(contact => contact.CompanyId == companyId)
                .Select(contact => new CompanyContactSummary()
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Task = contact.Task,
                    PhoneNumber = contact.PhoneNumber,
                    Mail = contact.Mail
                }).ToList();

            //var nameListV2 = (from contact in _context.Contacts
            //                  where contact.CompanyId == companyId
            //                  select new CompanyContactSummary() 
            //                  { 
            //                      FirstName = contact.FirstName,

            //                  } 
            //                  ).ToList();

            return Result<List<CompanyContactSummary>>.PrepareSuccess(nameList);
        }

        public async Task<Result> AddCompanyContact(CompanyContactInfo companyContactInfo)
        {
            try
            {
                var vResult = new CompanyContact
                {
                    Id = companyContactInfo.Id,
                    CompanyId = companyContactInfo.CompanyId,
                    FirstName = companyContactInfo.FirstName,
                    LastName = companyContactInfo.LastName,
                    PhoneNumber = companyContactInfo.PhoneNumber,
                    Task = companyContactInfo.Task,
                    Mail = companyContactInfo.Mail
                };

                _context.Contacts.Add(vResult);
                await _context.SaveChangesAsync();
                return Result.PrepareSuccess();
            }
            catch (Exception vEx)
            {

                return Result.PrepareFailure(vEx.Message);
            }
        }
        public async Task<Result> CompanyContactDelete(int id)
        {
            try
            {
                var vResult = _context.Contacts.FirstOrDefault(contact => contact.Id == id);
                _context.Contacts.Remove(vResult);
                await _context.SaveChangesAsync();
                return Result.PrepareSuccess();
            }
            catch (Exception vEx)
            {
                return Result.PrepareFailure(vEx.Message);
                throw;
            }

            

            
        }
        public async Task<Result> CompanyContactUpdate(CompanyContactInfo companyContactInfo)
        {
            try
            {
                var vContact = _context
                .Contacts.FirstOrDefault(contact => contact.Id == companyContactInfo.Id);

            vContact.CompanyId = companyContactInfo.CompanyId;
            vContact.FirstName = companyContactInfo.FirstName;
            vContact.LastName = companyContactInfo.LastName;
            vContact.Task = companyContactInfo.Task;
            vContact.PhoneNumber = companyContactInfo.PhoneNumber;
            vContact.Mail = companyContactInfo.Mail;

            await _context.SaveChangesAsync();
                return Result.PrepareSuccess();

            }
            catch (Exception vEx)
            {

                return Result.PrepareFailure(vEx.Message);
            }
            

            
        }
    }
}

//public Result<List<CompanyContactModels>> GetCompanyContactNamesByCompanyId(int companyId)
//{
//    var nameList = _context.Contacts
//        .Where(a => a.CompanyId == companyId)
//        .Select(a => a.FirstName).ToList();
//            return Result<List<CompanyContactModels>>.PrepareSuccess(nameListV2);