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
            var TypesToRegister = new List<Type>();
            var all = Assembly.GetEntryAssembly().GetReferencedAssemblies().Select(Assembly.Load).SelectMany(x => x.DefinedTypes).Where(type => typeof(T).GetTypeInfo().IsAssignableFrom(type.AsType()));

            foreach (var ti in all)
            {
                Console.WriteLine(ti.Name);
                var t = ti.AsType();
                if (t.Equals(typeof(T)))
                {
                    Console.WriteLine(t.Name);
                }
            }

            // return default(T);
        }
    }
}