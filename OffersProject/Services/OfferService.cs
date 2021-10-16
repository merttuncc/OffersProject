using Microsoft.EntityFrameworkCore;
using OfferModels.Models;
using OfferModuleProject.Context;
using OffersProject.Common;
using OffersProject.Models.OfferDetailsModel;
using OffersProject.Models.OfferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Services
{
    public class OfferService
    {
        Context _context;
        public OfferService(Context context)
        {
            _context = context;
        }

        public Result<List<OfferSummary>> GetOfferSummary()
        {
            try
            {
                var vCompanySummaryList = _context.Offers
                    .Include(offer => offer.Company)
                    .Include(offer => offer.CompanyContact)
                    .Select(offer => new OfferSummary
                    {
                        Id = offer.Id,
                        CompanyName = offer.Company.CompanyName,
                        ContactName = offer.CompanyContact.FirstName + " " + offer.CompanyContact.LastName,
                        OfferNumber = offer.OfferNumber,
                        Date = offer.Date,
                        ValidityDate = offer.ValidityDate,
                        ProfitRate = offer.ProfitRate,
                        Annotations = offer.Annotations,
                        CommercialConditions = offer.CommercialConditions,
                        TimeInformation = offer.TimeInformation
                    })
                    .ToList();

                return Result<List<OfferSummary>>.PrepareSuccess(vCompanySummaryList);
            }
            catch (Exception vEx)
            {
                return Result<List<OfferSummary>>.PrepareFailure(vEx.Message);

            }
        }


        public async Task<Result> AddOffer(OfferInfo offerInfo)
        {
            try
            {
                var offerDetails = offerInfo.OfferDetailsInfo.Select(offerDetail => new OfferDetail
                {
                    Id = offerDetail.Id,
                    OfferId = offerDetail.OfferId,
                    RowNumber = offerDetail.RowNumber,
                    Quantity = offerDetail.Quantity,
                    Description = offerDetail.Description,
                    UnitPrice = offerDetail.UnitPrice,
                    TotalPrice = offerDetail.TotalPrice,
                    Definition = offerDetail.Definition,
                    Optional = offerDetail.Optional,
                    UnitProfit = offerDetail.UnitProfit,
                    UnitCost = offerDetail.UnitCost,
                    Currency = offerDetail.Currency

                }
                    );

                var vOffer = new Offer
                {

                    Id = offerInfo.Id,
                    CompanyId = offerInfo.CompanyId,
                    CompanyContactId = offerInfo.CompanyContactId,
                    OfferNumber = offerInfo.OfferNumber,
                    Annotations = offerInfo.Annotations,
                    CommercialConditions = offerInfo.CommercialConditions,
                    TimeInformation = offerInfo.TimeInformation,
                    ProfitRate = offerInfo.ProfitRate,
                    Date = offerInfo.Date,
                    ValidityDate = offerInfo.ValidityDate,
                    OfferDetail = offerDetails.ToList()



                }; _context.Offers.Add(vOffer);
                await _context.SaveChangesAsync();

                return Result.PrepareSuccess();
            }
            catch (Exception vEx)
            {
                return Result.PrepareFailure(vEx.Message);

            }
        }
        public async Task<Result> UpdateOffer(OfferInfo offerInfo)
        {

            try
            {
                var offerDetails = offerInfo.OfferDetailsInfo.Select(offerDetail => new OfferDetail
                {
                    Id = offerDetail.Id,
                    OfferId = offerDetail.OfferId,
                    RowNumber = offerDetail.RowNumber,
                    Quantity = offerDetail.Quantity,
                    Description = offerDetail.Description,
                    UnitPrice = offerDetail.UnitPrice,
                    TotalPrice = offerDetail.TotalPrice,
                    Definition = offerDetail.Definition,
                    Optional = offerDetail.Optional,
                    UnitProfit = offerDetail.UnitProfit,
                    UnitCost = offerDetail.UnitCost,
                    Currency = offerDetail.Currency

                }
                    );
                

                var updateOffer = _context.Offers
                    .FirstOrDefault(offers => offers.Id == offerInfo.Id);

                
                updateOffer.CompanyId = offerInfo.CompanyId;
                updateOffer.CompanyContactId = offerInfo.CompanyContactId;
                updateOffer.OfferNumber = offerInfo.OfferNumber;
                updateOffer.Annotations = offerInfo.Annotations;
                updateOffer.CommercialConditions = offerInfo.CommercialConditions;
                updateOffer.TimeInformation = offerInfo.TimeInformation;
                updateOffer.ProfitRate = offerInfo.ProfitRate;
                updateOffer.Date = offerInfo.Date;
                updateOffer.OfferDetail = offerDetails.ToList();
                        
                
                await _context.SaveChangesAsync();
                return Result.PrepareSuccess();
            }
            catch (Exception vEx)
            {

                return Result.PrepareFailure(vEx.Message);
            }

        }

        public async Task<Result> DeleteOffer(int id)
        {
            try
            {

                var delete = _context.Offers.FirstOrDefault(offer => offer.Id == id);
                _context.Offers.Remove(delete);
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

