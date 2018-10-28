using System;
using System.ComponentModel.DataAnnotations;

namespace KargorERP.Data.Models.Accounts
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string AccountNumber { get; set; }
        [MaxLength(256)]
        public string AddressLine1 { get; set; }
        [MaxLength(256)]
        public string AddressLine2 { get; set; }
        [MaxLength(256)]
        public string AddressLine3 { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}