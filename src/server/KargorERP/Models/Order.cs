using System;

namespace KargorERP.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; }
        public Guid AccountId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}