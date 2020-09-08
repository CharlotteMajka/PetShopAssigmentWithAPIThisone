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
    public class OwnerController : ControllerBase
    {
        private IOwnerService ownerService;

            public OwnerController(IOwnerService service)
        {
            ownerService = service;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult< IEnumerable<Owner>> Get()
        {
            try
            {
                return ownerService.ReadOwners();

            }catch(InvalidDataException e )
            {
                return StatusCode(404, e.Message);
            }
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                
                return ownerService.GetOwnerById(id);
            }
            catch (InvalidDataException e)
            {
                return StatusCode(501, e.Message);
                
            }



        }

        // POST api/<OwnerController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                var Ownerreturn = ownerService.AddNewOwner(owner);
                return Created("",Ownerreturn);
            }
            catch (InvalidDataException e)
            {

                return StatusCode(500, e.Message);
            }

        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {

            try
            {
                return Ok(ownerService.UpdateOwner(id, owner));

            }
            catch (InvalidDataException e)
            {

                return StatusCode(400, e.Message);
            }
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {

            try
            {
                return Ok(ownerService.DeleteOwner(id));

            }
            catch (InvalidDataException e)
            {

                return StatusCode(400, e.Message);
            }
        }
    }
}
