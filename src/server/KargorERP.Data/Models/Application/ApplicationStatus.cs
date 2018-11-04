using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargorERP.Data.Models.Application
{
    public class ApplicationStatus
    {
        public bool IsInitialized { get; set; }
    }
}