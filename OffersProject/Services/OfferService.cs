<<<<<<< HEAD
﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
=======
﻿using Microsoft.EntityFrameworkCore;
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
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
<<<<<<< HEAD
        IMapper _mapper;
        public OfferService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
=======
        public OfferService(Context context)
        {
            _context = context;
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
        }

        public Result<List<OfferSummary>> GetOfferSummary()
        {
            try
            {
<<<<<<< HEAD
                var vCompanyList = _context.Offers
                    .Include(offer => offer.Company)
                    .Include(offer => offer.CompanyContact);
                var vCompanySummaryList = _mapper.Map<List<OfferSummary>>(vCompanyList);
                //.Select(offer => new OfferSummary
                //{
                //    Id = offer.Id,
                //    CompanyName = offer.Company.CompanyName,
                //    ContactName = offer.CompanyContact.FirstName + " " + offer.CompanyContact.LastName,
                //    OfferNumber = offer.OfferNumber,
                //    Date = offer.Date,
                //    ValidityDate = offer.ValidityDate,
                //    ProfitRate = offer.ProfitRate,
                //    Annotations = offer.Annotations,
                //    CommercialConditions = offer.CommercialConditions,
                //    TimeInformation = offer.TimeInformation
                //})
                //.ToList();
=======
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
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a

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
<<<<<<< HEAD
                //Offer offer = _mapper.Map<Offer>(offerInfo);
=======
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
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
<<<<<<< HEAD
                    OfferDetail = offerDetails.ToList()
                };

                _context.Offers.Add(vOffer);
=======
                    Currency=offerInfo.Currency,
                    OfferDetail = offerDetails.ToList()



                }; _context.Offers.Add(vOffer);
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
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
<<<<<<< HEAD

=======
                
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a

                var updateOffer = _context.Offers
                    .FirstOrDefault(offers => offers.Id == offerInfo.Id);

<<<<<<< HEAD

=======
                
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
                updateOffer.CompanyId = offerInfo.CompanyId;
                updateOffer.CompanyContactId = offerInfo.CompanyContactId;
                updateOffer.OfferNumber = offerInfo.OfferNumber;
                updateOffer.Annotations = offerInfo.Annotations;
                updateOffer.CommercialConditions = offerInfo.CommercialConditions;
                updateOffer.TimeInformation = offerInfo.TimeInformation;
                updateOffer.ProfitRate = offerInfo.ProfitRate;
                updateOffer.Date = offerInfo.Date;
                updateOffer.OfferDetail = offerDetails.ToList();
<<<<<<< HEAD


=======
                        
                
>>>>>>> 72024d9eb0e793f886469af9499a3bb2a5c8b90a
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

