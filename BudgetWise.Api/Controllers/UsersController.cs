using System.Linq;
using BudgetWise.Api.Entities;
using BudgetWise.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetWise.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult CreateUser(string firstName, string lastName, string username, string password)
        {
            var user = new UsersEntity()
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password,
                Salt = _authService.GenerateSalt()
            };
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return Ok(user.Id);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            return Ok(_dbContext.Users.Single(u => u.Id == id));
        }
        
    }
}