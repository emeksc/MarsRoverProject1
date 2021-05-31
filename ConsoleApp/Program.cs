using Core;
using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider service = DependencyInjection.Configure();
            IPlateau _plateau = service.GetService<IPlateau>();
            IRover _rover = service.GetService<IRover>();

            while (!_plateau.IsReady)
            {
                Console.WriteLine("Plateau size :");
                var plateauSize = Console.ReadLine();
                Console.WriteLine(_plateau.CreatePlateau(plateauSize));
            }

            var addAnotherRover = true;

            while (addAnotherRover)
            {
                Console.WriteLine("Rover position :");
                var roverPosition = Console.ReadLine();
                Console.WriteLine("Rover command :");
                var roverCommand = Console.ReadLine();

                if (_rover.PutRoverInPosition(roverPosition))
                {
                    _rover.Plateau = _plateau;
                    _rover.CommandParse(roverCommand);
                }

                addAnotherRover = false;
            }

            IRoverPosition result = _rover.Calculate();

            Console.WriteLine($"{result.X} " +
                   $"{result.Y} " +
                   $"{result.Direction.ToString()}");

            Console.ReadLine();
        }
    }
}
