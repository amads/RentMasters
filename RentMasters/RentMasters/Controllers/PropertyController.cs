using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentMasters.Models.Interfaces;

namespace RentMasters.Controllers
{
    [Produces("application/json")]
    [Route("api/Property")]
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IOwnerRepository _ownerRepository; 

        public PropertyController(IPropertyRepository propertyRepository, IAddressRepository addressRepository, IOwnerRepository ownerRepository)
        {
            _propertyRepository = propertyRepository;
            _addressRepository = addressRepository;
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetProperties()
        {
            return new JsonResult(_propertyRepository.GetAllProperties());
        }

        [HttpPost]
        [Route("addProperty")]
        public IActionResult AddNewProperty([FromBody] Property property)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = _ownerRepository.GetOwner(property.OwnerId); // głupi chuj nie widzi ownerId
            if(owner == null)
            {
                return NotFound("Cannot find owner with provided ownerId");
            }

            var addressTemp = _addressRepository.GetAddress(property.AddressId); // i adresID
            if(addressTemp == null)
            {
                return NotFound("Cannot find address with provided addressId");
            }

            _propertyRepository.AddNewProperty(property, addressTemp, owner); //a tu kurwa property chuj wie czemu nie widzi
            return new JsonResult(property.Id); //i tu Id
        }

    }
}