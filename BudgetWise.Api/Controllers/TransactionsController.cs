using System;
using System.Linq;
using System.Reflection.Emit;
using BudgetWise.Api.Entities;
using BudgetWise.Api.Extensions;
using BudgetWise.Api.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetWise.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly BudgetWiseDbContext _dbContext;

        public TransactionsController(BudgetWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateTransaction([FromBody] TransactionCreateRequest request)
        {
            try
            {
                var transaction = new TransactionsEntity()
                {
                    UserId = request.UserId,
                    Amount = request.Amount,
                    DateApplied = request.DateApplied,
                    LabelId = request.LabelId
                };
                _dbContext.Transactions.Add(transaction);

                _dbContext.SaveChanges();

                return Ok(transaction.Id);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var transactions = _dbContext.Transactions
                    .Include(t => t.Label)
                    .Where(t => t.UserId == userId)
                    .ToList();

                return Ok(transactions.Select(t => new
                {
                    t.Id,
                    t.UserId,
                    t.Amount,
                    t.DateApplied,
                    LabelId = t.Label?.Id
                }));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}