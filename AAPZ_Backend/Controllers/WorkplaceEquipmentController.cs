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
    public class WorkplaceEquipmentController : Controller
    {
        IDBActions<WorkplaceEquipment> WorkplaceEquipmentDB;

        public WorkplaceEquipmentController()
        {
            WorkplaceEquipmentDB = new WorkplaceEquipmentRepository();
        }

        // GET: api/<controller>
        [HttpGet("GetWorkplaceEquipmentsList")]
        public IEnumerable<WorkplaceEquipment> GetWorkplaceEquipmentsList()
        {
            return WorkplaceEquipmentDB.GetEntityList();
        }

        // GET api/<controller>/5
        [HttpGet("GetWorkplaceEquipmentById/{id}")]
        public IActionResult GetWorkplaceEquipmentById(int id)
        {
            WorkplaceEquipment WorkplaceEquipment = WorkplaceEquipmentDB.GetEntity(id);
            if (WorkplaceEquipment == null)
                return NotFound();
            return new ObjectResult(WorkplaceEquipment);
        }

        // POST api/<controller>
        [HttpPost("CreateWorkplaceEquipment")]
        public IActionResult CreateWorkplaceEquipment([FromBody]WorkplaceEquipment WorkplaceEquipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            WorkplaceEquipmentDB.Create(WorkplaceEquipment);
            WorkplaceEquipmentDB.Save();
            return Ok(WorkplaceEquipment);
        }

        // PUT api/<controller>
        [HttpPut("UpdateWorkplaceEquipment")]
        public IActionResult UpdateWorkplaceEquipment([FromBody]WorkplaceEquipment WorkplaceEquipment)
        {
            if (WorkplaceEquipment == null)
            {
                return BadRequest();
            }
            WorkplaceEquipmentDB.Update(WorkplaceEquipment);
            WorkplaceEquipmentDB.Save();
            return Ok(WorkplaceEquipment);
        }

        // DELETE api/<controller>/5

        [HttpDelete("DeleteWorkplaceEquipment/{id}")]
        public IActionResult DeleteWorkplaceEquipment(int id)
        {
            WorkplaceEquipment WorkplaceEquipment = WorkplaceEquipmentDB.GetEntity(id);
            if (WorkplaceEquipment == null)
            {
                return NotFound();
            }
            WorkplaceEquipmentDB.Delete(id);
            WorkplaceEquipmentDB.Save();
            return Ok(WorkplaceEquipment);
        }
    }
}
