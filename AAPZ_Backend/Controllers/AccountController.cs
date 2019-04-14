using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AAPZ_Backend.Models;
using AAPZ_Backend.Models.Tokens;
using AAPZ_Backend.ViewModels;
using AAPZ_Backend.Helpers;
using AutoMapper;

namespace AAPZ_Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly SheringDBContext _appDbContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public AccountController(UserManager<User> userManager, IMapper mapper, SheringDBContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            result = await _userManager.AddToRoleAsync(userIdentity, model.Role);

            if (model.Role == "member")
            {

                Client customer = new Client
                {
                    IdentityId = userIdentity.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    IsInBlackList = 0,
                    Email = model.Email,
                    Birthday = model.Birthday,
                    PassportNumber = model.PassportNumber

                };
                await _appDbContext.Client.AddAsync(customer);

                //Customer cust = _appDbContext.Customer.Where(x => x.IdentityId == customer.IdentityId)
                //    .SingleOrDefault();

                try
                {
                    var x = await _appDbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return new ObjectResult(e.Message);
                };

                return new OkObjectResult("Account created");
            }
            return new OkObjectResult("Last");

        }
    }
}