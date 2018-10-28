using System;
using System.ComponentModel.DataAnnotations;

namespace KargorERP.Data.Models.Identity
{
    public class UserPassword : Model
    {
        public string HashingAlgorithm { get; set; }
        public string Password { get; set; }
    }
}