using Core;
using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Core.Concrete;

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
                Console.WriteLine(_plateau.CreatePlateau(plateauSize) ? "Plateau is ready" : "");
            }


            Console.WriteLine("Rover position :");
            var roverPosition = Console.ReadLine();
            Console.WriteLine("Rover command :");
            var roverCommand = Console.ReadLine();

            if (_rover.PutRoverInPosition(roverPosition))
            {
                _rover.Plateau = _plateau;
                _rover.CommandParse(roverCommand);
            }



            IRoverPosition result = _rover.Calculate();

            Console.WriteLine($"{result.X} " +
                   $"{result.Y} " +
                   $"{result.Direction.ToString()}");

            Console.ReadLine();

            #region test

            //var plateauTest = new Plateau(5, 5);

            //// 1 2 N
            //var roverPositionTest = new RoverPosition(Directions.N, 1, 2);
            //var roverTest = new Rover(roverPositionTest, plateauTest);

            //// LMLMLMLMM
            //roverTest.Commands.Add(() => roverTest.TurnLeft());
            //roverTest.Commands.Add(() => roverTest.Move());
            //roverTest.Commands.Add(() => roverTest.TurnLeft());
            //roverTest.Commands.Add(() => roverTest.Move());
            //roverTest.Commands.Add(() => roverTest.TurnLeft());
            //roverTest.Commands.Add(() => roverTest.Move());
            //roverTest.Commands.Add(() => roverTest.TurnLeft());
            //roverTest.Commands.Add(() => roverTest.Move());
            //roverTest.Commands.Add(() => roverTest.Move());


            //IRoverPosition resultTest = roverTest.Calculate();

            //Console.WriteLine($"{resultTest.X} " +
            //       $"{resultTest.Y} " +
            //       $"{resultTest.Direction.ToString()}");
            //Console.ReadLine();
            ////Expected test result:1 3 N
            ///
            #endregion
        }
    }
}
