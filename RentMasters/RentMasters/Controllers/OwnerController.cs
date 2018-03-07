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
    [Route("api/Owners")]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpPost]
        [Route("addOwner")]
        public IActionResult AddOwner([FromBody] Owner owner)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ownerRepository.AddOwner(owner);
            return new JsonResult(owner.OwnerId);
        }
    }
}