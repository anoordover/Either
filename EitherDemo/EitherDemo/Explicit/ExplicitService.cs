using System;
using EitherDemo.Exceptions;
using EitherDemo.Simple;

namespace EitherDemo.Explicit
{
    public class ExplicitService
    {
        public Either<bool, Either<FunctionalException, TechnicalException>> Handle()
        {
            var random = new Random();
            var i = random.Next(4);
            return i switch
            {
                0 => new Either<bool, Either<FunctionalException, TechnicalException>>(true),
                1 => new Either<bool, Either<FunctionalException, TechnicalException>>(
                    new Either<FunctionalException, TechnicalException>(
                        new FunctionalException("Functionele fout"))),
                2 => new Either<bool, Either<FunctionalException, TechnicalException>>(false),
                _ => new Either<bool, Either<FunctionalException, TechnicalException>>(
                    new Either<FunctionalException, TechnicalException>(
                        new TechnicalException("Technische fout")))
            };
        }
    }
}