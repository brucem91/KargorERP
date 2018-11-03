using System;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace KargorERP.Data.Models
{
    public abstract class Model
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Guid? DeletedBy { get; set; }

        public bool ShouldSerializeDeletedOn()
        {
            return (DeletedOn != null);
        }

        public bool ShouldSerializedDeletedBy()
        {
            return (DeletedBy != null);
        }
    }
}