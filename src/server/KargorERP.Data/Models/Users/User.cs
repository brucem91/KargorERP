using System;
using System.ComponentModel.DataAnnotations;

namespace KargorERP.Data.Models.Users
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordMethod { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}