using CompulsoryPetshop.Core.ApplicationService;
using CompulsoryPetshop.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        #region Get All Owners
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _ownerService.getAllOwners();
        }
        #endregion
        #region Get Owner By Id
        [HttpGet("{Id}")]
        public Owner GetOwnerById(int id)
        {
            return _ownerService.getOwnerById(id);
        }
        #endregion
        #region Create New Owner
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner newOwner)
        {
            try
            {
                return StatusCode(201,(_ownerService.CreateOwner(newOwner)));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion
        #region Update Owner By Id
        [HttpPut("{Id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id != owner.OwnerID)
            {
                return BadRequest("Parameter ID and Owner ID don't match");
            }
            _ownerService.UpdateOwner(id, owner);
            return Accepted();
        }
        #endregion
        #region Delete Owner By Id
        [HttpDelete("{Id}")]
        public ActionResult<Owner> DeleteOwnerById(int id)
        {
            try
            {
                return Accepted(_ownerService.DeleteOwner(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }
        #endregion
    }
}
