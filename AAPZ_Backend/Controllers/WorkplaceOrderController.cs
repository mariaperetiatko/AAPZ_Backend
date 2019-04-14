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
    [Route("api/WorkplaceOrder")]
    public class WorkplaceOrderController : Controller
    {
        IDBActions<WorkplaceOrder> WorkplaceOrderDB;

        public WorkplaceOrderController()
        {
            WorkplaceOrderDB = new WorkplaceOrderRepository();
        }

        // GET: api/<controller>
        [HttpGet("GetWorkplaceOrdersList")]
        public IEnumerable<WorkplaceOrder> GetWorkplaceOrdersList()
        {
            return WorkplaceOrderDB.GetEntityList();
        }

        // GET api/<controller>/5
        [HttpGet("GetWorkplaceOrderById/{id}")]
        public IActionResult GetWorkplaceOrderById(int id)
        {
            WorkplaceOrder WorkplaceOrder = WorkplaceOrderDB.GetEntity(id);
            if (WorkplaceOrder == null)
                return NotFound();
            return new ObjectResult(WorkplaceOrder);
        }

        // POST api/<controller>
        [HttpPost("CreateWorkplaceOrder")]
        public IActionResult CreateWorkplaceOrder([FromBody]WorkplaceOrder WorkplaceOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            WorkplaceOrderDB.Create(WorkplaceOrder);
            WorkplaceOrderDB.Save();
            return Ok(WorkplaceOrder);
        }

        // PUT api/<controller>
        [HttpPut("UpdateWorkplaceOrder")]
        public IActionResult UpdateWorkplaceOrder([FromBody]WorkplaceOrder WorkplaceOrder)
        {
            if (WorkplaceOrder == null)
            {
                return BadRequest();
            }
            WorkplaceOrderDB.Update(WorkplaceOrder);
            WorkplaceOrderDB.Save();
            return Ok(WorkplaceOrder);
        }

        // DELETE api/<controller>/5

        [HttpDelete("DeleteWorkplaceOrder/{id}")]
        public IActionResult DeleteWorkplaceOrder(int id)
        {
            WorkplaceOrder WorkplaceOrder = WorkplaceOrderDB.GetEntity(id);
            if (WorkplaceOrder == null)
            {
                return NotFound();
            }
            WorkplaceOrderDB.Delete(id);
            WorkplaceOrderDB.Save();
            return Ok(WorkplaceOrder);
        }
    }
}
