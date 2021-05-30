using ServiceSubscription.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceSubscription.Repository
{
    public interface IPackagesRepository
    {
        IEnumerable<Package> GetPackages();

        Package GetPackage(Region region);

        Package CreateRecommendedPackage(Package package, int vat, Recurrence reccurence);
    }
}