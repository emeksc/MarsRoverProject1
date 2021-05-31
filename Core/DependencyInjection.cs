using Core.Abstract;
using Core.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class DependencyInjection
    {
        public static ServiceProvider Configure()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
           .AddTransient<IRoverPosition, RoverPosition>()
           .AddTransient<IRover, Rover>()
           .AddTransient<IPlateau, Plateau>()
           .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
