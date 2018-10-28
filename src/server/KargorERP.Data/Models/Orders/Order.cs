using System;

namespace KargorERP.Data.Models.Orders
{
    public class Order : Model
    {
        public string OrderNumber { get; set; }
        public Guid AccountId { get; set; }
    }
}