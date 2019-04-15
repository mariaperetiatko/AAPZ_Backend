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
    [Route("api/[controller]")]
    public class EquipmentController : Controller
    {
        IDBActions<Equipment> EquipmentDB;

        public EquipmentController()
        {
            EquipmentDB = new EquipmentRepository();
        }

        // GET: api/<controller>
        [HttpGet("GetEquipmentsList")]
        public IEnumerable<Equipment> GetEquipmentsList()
        {
            return EquipmentDB.GetEntityList();
        }

        // GET api/<controller>/5
        [HttpGet("GetEquipmentById/{id}")]
        public IActionResult GetEquipmentById(int id)
        {
            Equipment Equipment = EquipmentDB.GetEntity(id);
            if (Equipment == null)
                return NotFound();
            return new ObjectResult(Equipment);
        }

        // POST api/<controller>
        [HttpPost("CreateEquipment")]
        public IActionResult CreateEquipment([FromBody]Equipment Equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            EquipmentDB.Create(Equipment);
            EquipmentDB.Save();
            return Ok(Equipment);
        }

        // PUT api/<controller>
        [HttpPut("UpdateEquipment")]
        public IActionResult UpdateEquipment([FromBody]Equipment Equipment)
        {
            if (Equipment == null)
            {
                return BadRequest();
            }
            EquipmentDB.Update(Equipment);
            EquipmentDB.Save();
            return Ok(Equipment);
        }

        // DELETE api/<controller>/5

        [HttpDelete("DeleteEquipment/{id}")]
        public IActionResult DeleteEquipment(int id)
        {
            Equipment Equipment = EquipmentDB.GetEntity(id);
            if (Equipment == null)
            {
                return NotFound();
            }
            EquipmentDB.Delete(id);
            EquipmentDB.Save();
            return Ok(Equipment);
        }
    }
}
