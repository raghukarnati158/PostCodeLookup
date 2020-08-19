using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeLookupAPI.Services
{
    public interface IPostcodeLookupService
    {
        string[] GetValidDeliveryOptions(string postcode);
        string[] GetValidNearbyDeliveryOptions(string postcode);
    }
}
