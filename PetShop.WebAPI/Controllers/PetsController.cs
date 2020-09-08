using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetService petService;
        public  PetsController(IPetService _petService)
        {
            petService = _petService;
        }
        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<List<Pet>> Get()
        { 
            return petService.getPets();
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet>  GetById(int id)
        { try
            {
                return Ok(petService.GetPetById(id));
            }
            catch (InvalidDataException e) 
            {
                return StatusCode(501, e.Message);            
            }
        }

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                var petReturn = petService.AddNewPet(pet.Name, pet.Type, pet.Dob, pet.Color, pet.PreviousOwner, pet.Price);

                return Created("", petReturn);
            }
            catch (Exception e)
            {

                return StatusCode(501, e.Message);
            }


        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                return Ok(petService.UpdatePet(id, pet));
            }catch(InvalidDataException e)
            {
                return StatusCode(501, e.Message);
            }
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
                return Ok(petService.DeletePet(id));
            } catch(InvalidDataException e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}
