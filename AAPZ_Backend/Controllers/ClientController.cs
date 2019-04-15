using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AAPZ_Backend;
using AAPZ_Backend.Repositories;
using AAPZ_Backend.Models;


namespace AAPZ_Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Client")]
    public class ClientController : Controller
    {
        ClientRepository clientDB;

        public ClientController(ClientRepository repository)
        {
            clientDB = repository;
        }

        // GET: api/<controller>
        [HttpGet("GetClientsList")]
        public IEnumerable<Client> GetClientsList()
        {
            return clientDB.GetEntityList();
        }

        // GET api/<controller>/5
        [HttpGet("GetClientById/{id}")]
        public IActionResult GetClientById(int id)
        {
            Client client = clientDB.GetEntity(id);
            if (client == null)
                return NotFound();
            return new ObjectResult(client);
        }

        // POST api/<controller>
        [HttpPost("CreateClient")]
        public IActionResult CreateClient([FromBody]Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            clientDB.Create(client);
            return Ok(client);
        }

        // PUT api/<controller>
        [HttpPut("UpdateClient")]
        public IActionResult UpdateClient([FromBody]Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            clientDB.Update(client);
            return Ok(client);
        }

        // DELETE api/<controller>/5

        [HttpDelete("DeleteClient/{id}")]
        public IActionResult DeleteClient(int id)
        {
            Client client = clientDB.GetEntity(id);
            if (client == null)
            {
                return NotFound();
            }
            clientDB.Delete(id);
            return Ok(client);
        }
    }
}
