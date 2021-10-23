using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetWise.Api.Entities
{
    [Table("Users")]
    public class UsersEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("salt")]
        public string Salt { get; set; }
        
        public IEnumerable<CategoriesEntity> UserCategories { get; set; }
        public IEnumerable<TransactionsEntity> UserTransactions { get; set; }
    }
}