using System;
using System.ComponentModel.DataAnnotations;

namespace KargorERP.ViewModels.Application
{
    public class InitializeApplicationViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}