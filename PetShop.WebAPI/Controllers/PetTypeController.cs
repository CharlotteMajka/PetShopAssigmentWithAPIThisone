using System;
using System.Collections.Generic;
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
    public class PetTypeController : ControllerBase
    {
        private IPetTypeService petTypeService;
        public PetTypeController(IPetTypeService petTypeServ)
        {
            petTypeService = petTypeServ;

        }

        // GET: api/<PetTypeController>
        [HttpGet]
        public ActionResult<FilteredList<PetType>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(petTypeService.ReadAllTypes(filter));

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
         }

        // GET api/<PetTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            try
            {
                return Accepted(petTypeService.GetPetTypeById(id));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        // POST api/<PetTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PetTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType pettype)
        {
            try
            {
                return Accepted( petTypeService.updatePet(id, pettype));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        // DELETE api/<PetTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            try
            {
                return Accepted(petTypeService.DeletePetType(id));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }
    }
}
