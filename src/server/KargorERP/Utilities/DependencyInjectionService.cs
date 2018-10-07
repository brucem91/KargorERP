using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using KargorERP.Data;
using KargorERP.Models;
using KargorERP.ViewModels;

namespace KargorERP.Utilities
{
    public static class DependencyInjectionService
    {
        public static void RegisterAllClassesThatInheritType<T>(this IServiceCollection services)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t != typeof(T) && typeof(T).IsAssignableFrom(t));

            foreach (var type in types)
            {
                services.AddTransient(type);
            }
        }
    }
}