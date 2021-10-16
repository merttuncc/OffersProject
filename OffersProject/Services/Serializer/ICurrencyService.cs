using OffersProject.TutorialsCurrency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersProject.TutorialsCurrency.Serializer
{
    public interface ICurrencyService
    {
        Task<CurrencyModel[]> GetToday();

        Task<CurrencyModel[]> GetByDate(DateTime date);
    }
}
