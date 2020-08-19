using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostCodeLookupAPI.Services;

namespace PostCodeLookupAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostcodeLookupController : ControllerBase
    {
        private IPostcodeLookupService _postcodeLookupService;
        private IMapper _mapper;

        public PostcodeLookupController(
            IPostcodeLookupService postcodeLookupService,
            IMapper mapper)
        {
            _postcodeLookupService = postcodeLookupService;
            _mapper = mapper;
        }

        [HttpGet("{postcode}")]
        //[Route("{postcode}")]
        public IActionResult GetDeliveryOptionsByPostCode(string postcode)
        {
            var deliveryOptions = _postcodeLookupService.GetValidDeliveryOptions(postcode);
            return Ok(deliveryOptions);
        }
    }
}
