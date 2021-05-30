using ServiceSubscription.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceSubscription.Repository
{
    public interface ICountriesRepository
    {
        IEnumerable<Country> GetCountries();

        Country GetCountry(int id);
    }
}