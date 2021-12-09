using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BudgetWise.Api.Models.Requests
{
    public class TransactionCreateRequest
    {
        [Required]
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        [Required]
        [JsonPropertyName("date_applied")]
        public DateTime DateApplied { get; set; }
        [JsonPropertyName("label_id")]
        public int? LabelId { get; set; }
    }
}