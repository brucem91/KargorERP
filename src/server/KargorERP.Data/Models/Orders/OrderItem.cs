using System;
using System.ComponentModel.DataAnnotations;

namespace KargorERP.Data.Models.Orders
{
    public class OrderItem
    {
        [Key]
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        [Required]
        [MaxLength(256)]
        public string ItemNumber { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}