using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CompulsoryPetshop.Core.ApplicationService;
using CompulsoryPetshop.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PetShopRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        #region Get All Pets
        [HttpGet]
        public ActionResult<Pet> Get()
        {
            try
            {
               return Ok (_petService.GetAllPets());
            }
            catch(Exception e)
            {
               return StatusCode(500, e.Message);
            }
        }
        #endregion
        #region Create New Pet
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet newPet)
        {
            try
            {
                return StatusCode(201,_petService.CreateNewPet(newPet));
            }
            catch(Exception e)
            {
              return StatusCode(500, e.Message);
            }
        }
        #endregion
        #region Update Pet By Id
        [HttpPut("{Id}")]
        public ActionResult<Pet> Put(int id,[FromBody]Pet pet)
        {
            if(id != pet.PetId)
            {
                return BadRequest("Parameter ID and Pet ID must be the same");
            }
            _petService.UpdatePet(id,pet);
            return Accepted();
        }
        #endregion
        #region Get Pet By Id
        [HttpGet("{Id}")]
        public ActionResult<Pet> GetPetById(int id)
        {
            try
            {
                return Ok(_petService.ReadPetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion
        #region Delete Pet By Id
        [HttpDelete("{Id}")]
        public ActionResult<Pet> DeletePetById(int id)
        {
            try
            {
                return Accepted(_petService.DeletePet(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion
    }
}
