using System;
using System.ComponentModel.DataAnnotations;

namespace KargorERP.ViewModels.Application
{
    public class InitializeApplicationViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(256)]
        [MinLength(3)]
        public string EmailAddress { get; set; }
        [Required]
        [Phone]
        [MaxLength(256)]
        [MinLength(3)]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(256)]
        public string Password { get; set; }
    }
}