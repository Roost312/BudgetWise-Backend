using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BudgetWise.Api.Models.Requests
{
    public class UserCreateRequest
    {
        [Required]
        [MinLength(1)]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1)]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [Required]
        [MinLength(3)]
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [Required]
        [MinLength(6)]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}