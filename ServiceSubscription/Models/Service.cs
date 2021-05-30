using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceSubscription.Models
{
    public class Service
    {
        [Display(Name = "Country")]
        public string SelectedCountry { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        [Display(Name = "Recurrence")]
        public string SelectedRecurrence { get; set; }
        public IEnumerable<SelectListItem> Recurrences { get; set; }
        public Package SubscriptionPackage { get; set; }

        public string RecommendedPackageName { get; set; }

        public string RecommendedPackagePrice { get; set; }

    }
}