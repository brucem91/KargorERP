using System;
using System.ComponentModel.DataAnnotations;

namespace KargorERP.Data.Models
{
    public class Model
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}