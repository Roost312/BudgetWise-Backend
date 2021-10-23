using System.Linq;
using BudgetWise.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BudgetWise.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly BudgetWiseDbContext _dbContext;

        public UsersController(BudgetWiseDbContext dbContext)
        {
            _dbContext = dbContext;
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
                Salt = "S123om12312e123123salt12312edt1231hing23123y"
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