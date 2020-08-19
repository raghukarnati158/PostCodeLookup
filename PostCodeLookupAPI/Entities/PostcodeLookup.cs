using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeLookupAPI.Entities
{
    public class PostcodeLookup
    {
        public int Id { get; set; }
        public string PostCode { get; set; }
        public string DeliveryInfo { get; set; }
    }
}
