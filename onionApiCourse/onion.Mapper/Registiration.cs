using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace onion.Mapper
{
    public static  class Registiration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {

            services.AddSingleton<onion.Application.Interface.AutoMapper.IMapper, AutoMapper.Mapper>();
        }

    }
}
