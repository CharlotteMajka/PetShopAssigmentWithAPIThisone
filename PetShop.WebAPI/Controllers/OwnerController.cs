﻿using System;
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
    public class OwnerController : ControllerBase
    {
        private IOwnerService ownerService;

            public OwnerController(IOwnerService service)
        {
            ownerService = service;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult<FilteredList<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(ownerService.ReadOwners(filter));

            }catch(InvalidDataException e )
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
              
                return Ok(ownerService.GetOwnerById(id));
                
            }
            catch (InvalidDataException e)
            {
                
                return StatusCode(500, e.Message);
                
                
            }
            catch(ArgumentNullException e)
            {
                return StatusCode(404, e.Message);
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
                if(id == owner.id)
                return Accepted(ownerService.UpdateOwner(id, owner));
                else
                {
                    return StatusCode(400, "ID's does not match");
                    //throw new InvalidDataException("");
                }
            }
            catch (InvalidDataException e)
            {

                return StatusCode(500, e.Message);
                
            }

            catch(ArgumentNullException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {

            try
            {
                return Accepted(ownerService.DeleteOwner(id));

            }
            catch (InvalidDataException e)
            {

                return StatusCode(500, e.Message);
                            }
            catch (ArgumentNullException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
