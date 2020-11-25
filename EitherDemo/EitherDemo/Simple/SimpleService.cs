using System;
using EitherDemo.Exceptions;

namespace EitherDemo.Simple
{
    public class SimpleService
    {
        public bool Handle()
        {
            var random = new Random();
            var i = random.Next(4);
            return i switch
            {
                0 => true,
                1 => throw new FunctionalException("functionele fout"),
                2 => false,
                _ => throw new TechnicalException("technische fout")
            };
        }
    }

    public class TechnicalException : Exception
    {
        public TechnicalException(string message) : base(message)
        {
        }
    }
}