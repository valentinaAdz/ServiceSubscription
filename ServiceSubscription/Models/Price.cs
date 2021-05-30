using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceSubscription.Models
{
    public class Price
    {
        public int Id { get; set; }
        public Recurrence Reccurence { get; set; }
        public decimal Value { get; set; }
    }
}