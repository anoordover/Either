using System;
using EitherDemo.Exceptions;
using EitherDemo.Explicit;
using EitherDemo.Simple;

namespace EitherDemo
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SimpleDemo();
            Console.WriteLine();
            ExplicitDemo();
        }

        private static void SimpleDemo()
        {
            Console.WriteLine("SimpleDemo");
            Console.WriteLine("==========");
            var service = new SimpleService();
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine(service.Handle() ? "Goed" : "Fout");
                }
                catch (FunctionalException functionalException)
                {
                    Console.WriteLine(functionalException.Message);
                }
                catch (TechnicalException technicalException)
                {
                    Console.WriteLine(technicalException.Message);
                }
            }
            Console.WriteLine("-----------------");
        }

        private static void ExplicitDemo()
        {
            Console.WriteLine("ExplicitDemo");
            Console.WriteLine("============");
            var service = new ExplicitService();
            for (var i = 0; i < 10; i++)
            {
                var result = service.Handle();
                result.Handle(b => Console.WriteLine(b ? "Goed" : "Fout"),
                    e => e.Handle(
                        fe => Console.WriteLine(fe.Message),
                        te => Console.WriteLine(te.Message)));
            }
            Console.WriteLine("-----------------");
        }
    }
}