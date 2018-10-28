using System;
using System.ComponentModel.DataAnnotations;

namespace KargorERP.Data.Models.Identity
{
    public class User : Model
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}