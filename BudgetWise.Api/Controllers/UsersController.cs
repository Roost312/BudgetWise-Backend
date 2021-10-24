﻿using System.Linq;
using BudgetWise.Api.Entities;
using BudgetWise.Api.Models.Requests;
using BudgetWise.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetWise.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly BudgetWiseDbContext _dbContext;
        private readonly AuthenticationService _authService;

        public UsersController(BudgetWiseDbContext dbContext, AuthenticationService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] UserCreateRequest request)
        {
            var user = new UsersEntity()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Password = request.Password,
                Salt = _authService.GenerateSalt()
            };
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return Ok(user.Id);
        }

        [HttpGet]
        public IActionResult GetCurrentUser()
        {
            var userId = int.Parse(HttpContext.User.Claims.Single(claim => claim.Type.Equals("budgetwise_user_id")).Value);
            var user = _dbContext.Users.Single(u => u.Id == userId);
            return Ok(new
            {
                id = user.Id,
                firstName = user.FirstName,
                lastName = user.LastName,
                username = user.Username
            });
        }
        
    }
}