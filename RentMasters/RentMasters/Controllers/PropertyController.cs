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

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetProperties()
        {
            return new JsonResult(_propertyRepository.GetAll());
        }

        [HttpPost]
        [Route("addProperty")]
        public IActionResult AddNewProperty([FromBody]Property property)
        {
            return NotFound();
        }

    }
}