using ServiceSubscription.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceSubscription.Repository
{
    public class PackagesRepository : IPackagesRepository
    {
        public IEnumerable<Package> GetPackages()
        {
            var packages = new List<Package>
            {
                new Package
                {
                    Id = 1, Name="EU Recommended", 
                    Region= Region.Europe, 
                    Price= new List<Price>
                    {
                        new Price
                        {
                            Id=1,
                            Reccurence= Recurrence.Monthly,
                            Value=15
                        },
                        new Price
                        {
                            Id=2,
                            Reccurence= Recurrence.Yearly,
                            Value=150
                        }
                    }
                },
                new Package
                {
                    Id = 2, 
                    Name="Enterprise Recommended", 
                    Region= Region.USA,
                    Price= new List<Price>
                    {
                        new Price
                        {
                            Id=1,
                            Reccurence= Recurrence.Monthly,
                            Value=25
                        },
                        new Price
                        {
                            Id=2,
                            Reccurence= Recurrence.Yearly,
                            Value=250
                        }
                    }
                }
            };

            return packages;
        }

        public Package GetPackage(Region region)
        {
            return GetPackages().FirstOrDefault(c => c.Region == region);
        }

        public Package CreateRecommendedPackage(Package package, int vat, Recurrence recurrence)
        {
            var price = package.Price.FirstOrDefault(p => p.Reccurence == recurrence);
                
            return new Package
            {
                Id = package.Id,
                Name = package.Name,
                Region = package.Region,
                Price = new List<Price>
                {
                    new Price
                    {
                        Id = 5,
                        Reccurence = recurrence,
                        Value = price.Value + (price.Value * vat) / 100
                    }
                }
            };
        }
    }
}