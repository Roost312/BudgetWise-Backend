using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BudgetWise.Api.Extensions
{
    public static class HttpContextExtensions
    {
        public static int GetCurrentUserId(this HttpContext context)
        {
            return int.Parse(context.User.Claims.Single(claim => claim.Type.Equals("budgetwise_user_id")).Value);
        }
    }
}