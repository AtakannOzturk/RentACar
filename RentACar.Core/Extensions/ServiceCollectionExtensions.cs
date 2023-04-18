using Microsoft.Extensions.DependencyInjection;
using RentACar.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection servicesCollection,
            ICoreModule[] modules) 
        {
            foreach (var module in modules) 
            {
                module.Load(servicesCollection);
            }

            return ServiceTool.Create(servicesCollection);
        }
    }
}
