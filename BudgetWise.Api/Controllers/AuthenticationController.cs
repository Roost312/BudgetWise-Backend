using System;
using System.Net;
using BudgetWise.Api.Entities;
using BudgetWise.Api.Models.Requests;
using BudgetWise.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetWise.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly BudgetWiseDbContext _dbContext;
        private readonly AuthenticationService _authService;

        public AuthenticationController(BudgetWiseDbContext dbContext, AuthenticationService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }
        
        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Login([FromBody] AuthenticationRequest request)
        {
            UsersEntity? user = null;
            
            try
            {
                user = _authService.Authenticate(request);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
            
            if (user is not null)
            {
                return Ok(new
                {
                    token = _authService.BuildToken(user)
                });
            }

            return Unauthorized();
        }
    }
}