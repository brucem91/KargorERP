using System;
using System.ComponentModel.DataAnnotations;

namespace KargorERP.Data.Models.Users
{
    public class UserPassword
    {
        [Key]
        public string UserPasswordId { get; set; }
        public string HashingAlgorithm { get; set; }
        public string Password { get; set; }
    }
}