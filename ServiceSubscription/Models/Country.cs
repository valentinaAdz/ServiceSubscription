using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceSubscription.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
        public int Vat { get; set; }
    }
}