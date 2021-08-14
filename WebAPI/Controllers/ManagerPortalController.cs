using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerPortalController : ControllerBase
    {
        private IBL _BL;
        public ManagerPortalController(IBL p_BL)
        {
            _BL = p_BL;
        }

        // GET: api/<ManagerPortalController>
        [HttpGet("getAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            // Ok method return status code
            return Ok(await _BL.GetAllCustomers());
        }

        // GET api/<ManagerPortalController>/5
        [HttpGet("getACustomer/{p_id}")]
        public async Task<IActionResult> GetACustomer(int p_id)
        {
            return Ok(await _BL.GetACustomer(p_id));
        }

        // POST api/<ManagerPortalController>
        [HttpPost("addCustomer")]
        public IActionResult AddCustomer([FromBody] Customer p_customer)
        {
            // Created method return status code when an object is created
            return Created("api/ManagerPortal/addCustomer", _BL.AddCustomer(p_customer));
        }

        [HttpGet("getAllStoreFronts")]
        public async Task<IActionResult> GetAllStoreFronts()
        {
            return Ok(await _BL.GetAllStoreFronts());
        }

        //--------------------------------------------------------------------------------------------
        // PUT api/<ManagerPortalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ManagerPortalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
