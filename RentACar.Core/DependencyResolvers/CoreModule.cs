using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.DependencyResolvers
{
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
