using System;

namespace EitherDemo
{
    public class Either<TLeft, TRight>
    {
        private readonly TLeft _left;
        private readonly TRight _right;
        private readonly bool _isLeft;

        public Either(TLeft left)
        {
            _isLeft = true;
            _left = left;
        }

        public Either(TRight right)
        {
            _isLeft = false;
            _right = right;
        }

        public void Handle(Action<TLeft> leftAction,
            Action<TRight> rightAction)
        {
            if (_isLeft)
            {
                leftAction(_left);
            }
            else
            {
                rightAction(_right);
            }    
        }
    }
}