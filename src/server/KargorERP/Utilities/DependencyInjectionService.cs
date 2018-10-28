using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

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