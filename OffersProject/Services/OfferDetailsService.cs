using OfferModels.Models;
using OfferModuleProject.Context;
using OffersProject.Common;
using OffersProject.Models.OfferDetailsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.Services
{
    public class OfferDetailsService
    {
        Context _context;
        public OfferDetailsService(Context context)
        {
            _context = context;
        }

        public Result<List<OfferDetailSummary>> GetOfferDetailsByOfferId(int offerId)
        {


            var vResult = _context.OfferDetails
            .Where(x => x.OfferId == offerId)
            .Select(x => new OfferDetailSummary
            {
                OfferId = x.OfferId,
                Quantity = x.Quantity,
                RowNumber=x.RowNumber,
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                TotalPrice = x.TotalPrice,
                Definition = x.Definition,
                Optional = x.Optional,
                UnitProfit=x.UnitProfit,
                UnitCost=x.UnitCost
                
            }).ToList();
            return Result<List<OfferDetailSummary>>.PrepareSuccess(vResult);
        }
        public async Task<Result> AddOfferDetails(OfferDetailSummary offerDetailSummary)
        {

            try
            {
                var vResult = new OfferDetail
                {
                    Id = offerDetailSummary.Id,
                    OfferId = offerDetailSummary.OfferId,
                    RowNumber = offerDetailSummary.RowNumber,
                    Quantity = offerDetailSummary.Quantity,
                    Description = offerDetailSummary.Description,
                    UnitPrice = offerDetailSummary.UnitPrice,
                    TotalPrice = offerDetailSummary.TotalPrice,
                    Definition = offerDetailSummary.Definition,
                    Optional = offerDetailSummary.Optional,
                    UnitProfit = offerDetailSummary.UnitProfit,
                    UnitCost = offerDetailSummary.UnitCost


                };
                _context.OfferDetails.Add(vResult);
                await _context.SaveChangesAsync();
                return Result.PrepareSuccess();
            }
            catch (Exception vEx)
            {

                return Result.PrepareFailure(vEx.Message);
            }
        }
        public async Task<Result> UpdadeOfferDetails(OfferDetailInfo offerDetailInfo)
        {
            
            try
            {
                var vResult = _context.OfferDetails.FirstOrDefault(details => details.Id == offerDetailInfo.Id);
                vResult.Id = offerDetailInfo.Id;
                vResult.OfferId = offerDetailInfo.OfferId;
                vResult.RowNumber = offerDetailInfo.RowNumber;
                vResult.Quantity = offerDetailInfo.Quantity;
                vResult.Description = offerDetailInfo.Description;
                vResult.UnitPrice = offerDetailInfo.UnitPrice;
                vResult.TotalPrice = offerDetailInfo.TotalPrice;
                vResult.Definition = offerDetailInfo.Definition;
                vResult.Optional = offerDetailInfo.Optional;
                vResult.UnitProfit = offerDetailInfo.UnitProfit;
                vResult.UnitCost = offerDetailInfo.UnitCost;

                await _context.SaveChangesAsync();
                return Result.PrepareSuccess();
            }
            catch (Exception vEx)
            {

                return Result.PrepareSuccess(vEx.Message);
            }
                    
        }
    }
}