using System.Text.Json.Serialization;

namespace BudgetWise.Api.Models.Requests
{
    public class AuthenticationRequest
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}