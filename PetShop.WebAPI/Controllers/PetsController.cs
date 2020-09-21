using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;

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
        public ActionResult<FilteredList<Pet>> Get([FromQuery] Filter filter)
        {  try
            {
                return Ok(petService.GetAllPets(filter));
            }
            catch(InvalidDataException e )
            {
                return StatusCode(500, e.Message);
            }   
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
                return StatusCode(500, e.Message);            
                //404 kode mangler
            }
            catch (ArgumentNullException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                var pettype = pet.Type;
                var petReturn = petService.AddNewPet(pet.Name,  pet.Type, pet.Dob, pet.Color, pet.PreviousOwner, pet.Price, pet.SoldDate);

                return Created("", petReturn);
            }
            catch (Exception e)
            {

                return StatusCode(418, e.Message);
            }


        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                return Accepted(petService.UpdatePet(id, pet));

            }catch(InvalidDataException e)
            {
                return StatusCode(500, e.Message);
               
            } catch (ArgumentNullException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
                return Accepted(petService.DeletePet(id));

            } catch(ArgumentNullException e)
            {
                return StatusCode(404, e.Message);
                
            }
            catch(InvalidDataException e)
            {
                return StatusCode(500, e.Message); 
            }
        }
    }
}
