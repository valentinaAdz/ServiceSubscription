using ServiceSubscription.Models;
using ServiceSubscription.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceSubscription.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            var countryRepo = new CountriesRepository();
            var model = new Service
            {
                Countries = GetCountries(countryRepo),
                Recurrences = GetRecurrences()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Service service)
        {
            var countryRepo = new CountriesRepository();
            var packageRepo = new PackagesRepository();

            var country = countryRepo.GetCountry(int.Parse(service.SelectedCountry));
            var package = packageRepo.GetPackage(country.Region);

            var recommendedPackage = packageRepo.CreateRecommendedPackage(package, country.Vat, (Recurrence)Enum.Parse(typeof(Recurrence), service.SelectedRecurrence));

            var model = new Service
            {
                Countries = GetCountries(countryRepo),
                SelectedCountry = service.SelectedCountry,
                Recurrences = GetRecurrences(),
                SelectedRecurrence = service.SelectedRecurrence,
                RecommendedPackageName = recommendedPackage.Name,
                RecommendedPackagePrice = recommendedPackage.Price.FirstOrDefault()?.Value.ToString()
            
            };

            return View(model);
        }

        public IEnumerable<SelectListItem> GetCountries(CountriesRepository countriesRepository)
        {
            var countries = countriesRepository.GetCountries();

            return countries.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }

        public IEnumerable<SelectListItem> GetRecurrences()
        {
            var recurrences = new List<Recurrence>
            {
                Recurrence.Monthly,
                Recurrence.Yearly
            };

            return recurrences.Select(r => new SelectListItem { 
                Value = r.ToString(),
                Text = r.ToString()
            }).ToList();
        }
    }

}
