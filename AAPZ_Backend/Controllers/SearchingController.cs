using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AAPZ_Backend.Models;
using AAPZ_Backend.BusinessLogic.Classes;
using AAPZ_Backend.BusinessLogic.Searching;


namespace AAPZ_Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SearchingController : ControllerBase
    {
        SearchWorkplaces searchWorkplaces;

        public SearchingController()
        {
            searchWorkplaces = new SearchWorkplaces();
        }

        [HttpPost("SearhcForWorcplaces")]
        public IActionResult SearcForWorcplaces([FromBody] SearchingViewModel searchingViewModel)
        {
            List<FindedWorkplace> findedWorkplaces = searchWorkplaces.PerformSearching(searchingViewModel);

            return new ObjectResult(findedWorkplaces);
        }

    }
}