using System;
using System.Collections.Generic;

// using Microsoft.AspNetCore.Mvc;

namespace KargorERP.Services
{
    public class ServiceResult<T>
    {
        public T Data { get; set; }
        public List<string> Messages { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }

        // public static implicit operator IActionResult(ServiceResult<T> source)
        // {
        //     return "Hello World";
        // }
    }
}