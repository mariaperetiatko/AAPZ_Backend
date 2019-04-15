using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AAPZ_Backend;
using AAPZ_Backend.Repositories;
using AAPZ_Backend.BusinessLogic.Ordering;
using AAPZ_Backend.Models;


namespace AAPZ_Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/WorkplaceOrder")]
    public class WorkplaceOrderController : Controller
    {
        IDBActions<WorkplaceOrder> WorkplaceOrderDB;
        OrderWorkplace OrderWorkplace;
        public WorkplaceOrderController(ClientRepository clientRepository)
        {
            WorkplaceOrderDB = new WorkplaceOrderRepository();
            OrderWorkplace = new OrderWorkplace(clientRepository);
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

            
            if(OrderWorkplace.isFree(WorkplaceOrder.ClientId, WorkplaceOrder.WorkplaceId,
                WorkplaceOrder.StartTime, WorkplaceOrder.FinishTime))
            {
                WorkplaceOrder.SumToPay = (int)OrderWorkplace.CreateOrder(WorkplaceOrder.ClientId, WorkplaceOrder.WorkplaceId,
                WorkplaceOrder.StartTime, WorkplaceOrder.FinishTime);

                WorkplaceOrderDB.Create(WorkplaceOrder);
                WorkplaceOrderDB.Save();
                WorkplaceOrder.Client =null;
                WorkplaceOrder.Workplace = null;

                return Ok(WorkplaceOrder);

            }
            return Ok("Busy");
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
