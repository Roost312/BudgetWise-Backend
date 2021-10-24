namespace BudgetWise.Api
{
    public class JwtSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SigningKey { get; set; }
        public bool RequireExpirationTime { get; set; }
        public int? ExpirationDays { get; set; }
        public int? ExpirationHours { get; set; }
        public int? ExpirationMinutes { get; set; }
    }
}