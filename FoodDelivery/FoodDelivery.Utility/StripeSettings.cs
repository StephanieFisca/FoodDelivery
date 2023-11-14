using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Utility
{
    public class StripeSettings
    {
        public string SecretLey { get; set; }
        public string PublishableKey { get; set; }
    }
}
