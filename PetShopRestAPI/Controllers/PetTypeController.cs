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
    public class PetTypeController : ControllerBase
    {

        private readonly IPetTypeService _petTypeService;
        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        #region Get All PetTypes
        [HttpGet]
        public ActionResult<PetType> Get()
        {
            try
            {
                return Ok(_petTypeService.getAllPetTypes());
            }
            catch(Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }
        #endregion
        #region Get PetType By Id
        [HttpGet("{Id}")]
        public ActionResult GetPetTypeById(int id)
        {
            try
            {
                return Ok(_petTypeService.getTypeById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
           
        }
        #endregion
        #region Create New PetType
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType newPetType)
        {
            try
            {
                return StatusCode(201,_petTypeService.Createtype(newPetType));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion
        #region Update PetType By Id
        [HttpPut("{Id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType)
        {
            if (id != petType.PetTypeId)
            {
                return StatusCode(500, "Parameter ID and PetType ID don't match");
            }
            _petTypeService.UpdatePetType(id, petType);
            return Accepted();
        }
        #endregion
        #region Delete PetType By Id
        [HttpDelete("{Id}")]
        public ActionResult<PetType> DeletePetTypeById(int id)
        {
            try
            {
                return Accepted(_petTypeService.DeletePetType(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion
    }
}
