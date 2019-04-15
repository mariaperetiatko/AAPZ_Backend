using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AAPZ_Backend.Models;
using AAPZ_Backend.BusinessLogic.Classes;
using AAPZ_Backend.BusinessLogic.Statistics;

namespace AAPZ_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        WorkplaceStatistics workplaceStatistics;

        public StatisticsController()
        {
            workplaceStatistics = new WorkplaceStatistics();
        }

        [HttpGet("GetStatisticsByYear/{year}, {buildingId}")]
        public IActionResult GetStatisticsByYear(int year, int buildingId)
        {
            return new ObjectResult(workplaceStatistics.GetStatisticsByYear(year, buildingId));
        }

        [HttpGet("GetStatisticsByMonth/{year}, {month}, {buildingId}")]
        public IActionResult GetStatisticsByMonth(int year, int month, int buildingId)
        {
            return new ObjectResult(workplaceStatistics.GetStatisticsByMonth(year, month, buildingId));
        }

        [HttpGet("GetAverageStatisticsByWeek/{buildingId}")]
        public IActionResult GetAverageStatisticsByWeek(int buildingId)
        {
            return new ObjectResult(workplaceStatistics.GetAverageStatisticsByWeek(buildingId));
        }



    }
}