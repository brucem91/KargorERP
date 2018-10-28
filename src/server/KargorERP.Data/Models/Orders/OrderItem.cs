using System;
using System.ComponentModel.DataAnnotations;

namespace KargorERP.Data.Models.Orders
{
    public class OrderItem : Model
    {
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
    }
}