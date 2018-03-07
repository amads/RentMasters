using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentMasters.Models;
using RentMasters.Models.Interfaces;

namespace RentMasters.Controllers
{
    [Produces("application/json")]
    [Route("api/Address")]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpPost]
        [Route("addAddress")]
        public IActionResult AddNewAddress([FromBody]Address address)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _addressRepository.AddAddress(address);
            return new JsonResult(address.AddressId);
        }
    }
}