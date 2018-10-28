using System;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace KargorERP.Data.Models
{
    public abstract class Model
    {
        [Key]
        [JsonProperty(Order = 1)]
        public Guid Id { get; set; }
        [JsonProperty(Order = 1000)]
        public DateTime CreatedOn { get; set; }
        [JsonProperty(Order = 1001)]
        public DateTime UpdatedOn { get; set; }
        [JsonProperty(Order = 1002)]
        public DateTime? DeletedOn { get; set; }

        public bool ShouldSerializeDeletedOn()
        {
            return (DeletedOn != null);
        }
    }
}