using ServiceSubscription.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceSubscription.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        public IEnumerable<Country> GetCountries()
        {
            var countries = new List<Country>
            {
                new Country
                {
                    Id = 1, Name="UK", Region= Region.Europe, Vat=15
                },
                new Country
                {
                    Id = 2, Name="France", Region= Region.Europe, Vat=18
                },
                new Country
                {
                    Id = 3, Name="USA", Region= Region.USA, Vat=0
                }
            };

            return countries;
        }

        public Country GetCountry(int id)
        {
            return GetCountries().FirstOrDefault(c => c.Id == id);
        }
    }
}