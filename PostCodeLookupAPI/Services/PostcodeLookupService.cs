using PostCodeLookupAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PostCodeLookupAPI.Services
{
    public class PostcodeLookupService : IPostcodeLookupService
    {
        private DataContext _context;

        public PostcodeLookupService(DataContext context)
        {
            _context = context;
        }

        public string[] GetValidDeliveryOptions(string postcode)
        {
            return GetDeliveryOptions(postcode);
        }

        public string[] GetValidNearbyDeliveryOptions(string postcode)
        {
            return GetDeliveryOptions(postcode, true);
        }

        private string[] GetDeliveryOptions(string postcode, bool includeNearbyDeliveries = false)
        {
            List<string> postCodesInDB = _context.PostCodeLookup.Select(x => x.PostCode).ToList();
            string[] deliveryOptions; 

            if (includeNearbyDeliveries)
            {
                deliveryOptions = _context.PostCodeLookup.Where(x => x.PostCode.Contains(postcode)).Select(x => x.DeliveryInfo).ToArray();
            }
            else
            {
                string closestMatchingPostcode = GetClosestPostcode(postCodesInDB, postcode);
                if (string.IsNullOrEmpty(closestMatchingPostcode))
                {
                    deliveryOptions = _context.PostCodeLookup.Where(x => x.PostCode.Equals("")).Select(x => x.DeliveryInfo).ToArray();
                }
                else
                {
                    deliveryOptions = _context.PostCodeLookup.Where(x => x.PostCode.Equals(closestMatchingPostcode)).Select(x => x.DeliveryInfo).ToArray();
                }
            }
            return deliveryOptions;
        }

        //TODO: ******This method can be improved significantly by avoiding the code repetition but sticking to this for now.*********
        private static string GetClosestPostcode(List<string> dbPostcodes, string postcode)
        {
            string closestPostCode = "";
            //postcode = postcode.Replace(" ", "");
            //dbPostcodes = dbPostcodes.Select(x => x.Replace(" ", "")).ToList();

            //If the postcode entered by user is found in DB, then get its corresponding delivery option
            closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(postcode, StringComparison.CurrentCultureIgnoreCase));
            if (!string.IsNullOrEmpty(closestPostCode))
            {
                return closestPostCode;
            }

            string trimmedPostCode = "";
            //Match the first 8 characters
            if (postcode.Length == 8)
            {
                trimmedPostCode = postcode.Substring(0, 7);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 7 characters
                trimmedPostCode = postcode.Substring(0, 6);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 6 characters
                trimmedPostCode = postcode.Substring(0, 5);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 5 characters
                trimmedPostCode = postcode.Substring(0, 4);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 4 characters
                trimmedPostCode = postcode.Substring(0, 3);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 3 characters
                trimmedPostCode = postcode.Substring(0, 2);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 2 characters
                trimmedPostCode = postcode.Substring(0, 1);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                return closestPostCode;
            }


            //Match the first 7 characters
            if (postcode.Length == 7)
            {
                trimmedPostCode = postcode.Substring(0, 6);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 6 characters
                trimmedPostCode = postcode.Substring(0, 5);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 5 characters
                trimmedPostCode = postcode.Substring(0, 4);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 4 characters
                trimmedPostCode = postcode.Substring(0, 3);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 3 characters
                trimmedPostCode = postcode.Substring(0, 2);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 2 characters
                trimmedPostCode = postcode.Substring(0, 1);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                return closestPostCode;
            }

            //Match the first 6 characters
            if (postcode.Length == 6)
            {
                trimmedPostCode = postcode.Substring(0, 5);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 5 characters
                trimmedPostCode = postcode.Substring(0, 4);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 4 characters
                trimmedPostCode = postcode.Substring(0, 3);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 3 characters
                trimmedPostCode = postcode.Substring(0, 2);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 2 characters
                trimmedPostCode = postcode.Substring(0, 1);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                return closestPostCode;
            }

            //Match the first 5 characters
            if (postcode.Length == 5)
            {
                //Match first 5 characters
                trimmedPostCode = postcode.Substring(0, 4);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 4 characters
                trimmedPostCode = postcode.Substring(0, 3);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 3 characters
                trimmedPostCode = postcode.Substring(0, 2);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                //Match first 2 characters
                trimmedPostCode = postcode.Substring(0, 1);
                closestPostCode = dbPostcodes.FirstOrDefault(x => x.Equals(trimmedPostCode, StringComparison.CurrentCultureIgnoreCase));
                if (!string.IsNullOrEmpty(closestPostCode))
                {
                    return closestPostCode;
                }

                return closestPostCode;
            }

            return closestPostCode;
        }
    }
}
