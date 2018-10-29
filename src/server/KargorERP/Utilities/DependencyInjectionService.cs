using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace KargorERP.Utilities
{
    public static class DependencyInjectionService
    {
        public static void RegisterAllClassesThatInheritType<T>(this IServiceCollection services)
        {
            var types = Assembly.GetEntryAssembly().GetReferencedAssemblies().Select(Assembly.Load).SelectMany(x => x.DefinedTypes);

            foreach (var type in types.Where(t => t != typeof(T) && typeof(T).IsAssignableFrom(t)))
            {
                services.AddTransient(type);
            }
        }
    }
}