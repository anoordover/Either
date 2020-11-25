using System;

namespace EitherDemo.Exceptions
{
    public class FunctionalException : Exception
    {
        public FunctionalException(string message) : base(message)
        {
        }
    }
}