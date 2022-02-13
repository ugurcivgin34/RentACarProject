using Core.CrossCuttingConcers.Cashing;
using Core.CrossCuttingConcers.Cashing.Microsoft;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.IoC;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependecnyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<ITokenHelper, JwtHelper>();
            serviceCollection.AddSingleton<IFileHelper, FileHelperManager>();
            serviceCollection.AddSingleton<Stopwatch>();

        }
    }
}
