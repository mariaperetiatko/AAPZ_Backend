using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AAPZ_Backend;
using AAPZ_Backend.Repositories;


namespace AAPZ_Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Building")]
    public class BuildingController : Controller
    {
        IDBActions<Building> BuildingDB;

        public BuildingController()
        {
            BuildingDB = new BuildingRepository();
        }

        // GET: api/<controller>
        [HttpGet("GetBuildingsList")]
        public IEnumerable<Building> GetBuildingsList()
        {
            return BuildingDB.GetEntityList();
        }

        // GET api/<controller>/5
        [HttpGet("GetBuildingById/{id}")]
        public IActionResult GetBuildingById(int id)
        {
            Building Building = BuildingDB.GetEntity(id);
            if (Building == null)
                return NotFound();
            return new ObjectResult(Building);
        }

        // POST api/<controller>
        [HttpPost("CreateBuilding")]
        public IActionResult CreateBuilding([FromBody]Building Building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            BuildingDB.Create(Building);
            BuildingDB.Save();
            return Ok(Building);
        }

        // PUT api/<controller>
        [HttpPut("UpdateBuilding")]
        public IActionResult UpdateBuilding([FromBody]Building Building)
        {
            if (Building == null)
            {
                return BadRequest();
            }
            BuildingDB.Update(Building);
            BuildingDB.Save();
            return Ok(Building);
        }

        // DELETE api/<controller>/5

        [HttpDelete("DeleteBuilding/{id}")]
        public IActionResult DeleteBuilding(int id)
        {
            Building Building = BuildingDB.GetEntity(id);
            if (Building == null)
            {
                return NotFound();
            }
            BuildingDB.Delete(id);
            BuildingDB.Save();
            return Ok(Building);
        }
    }
}
