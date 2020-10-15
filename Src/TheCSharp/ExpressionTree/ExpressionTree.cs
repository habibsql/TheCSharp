using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace TheCSharp.ExpressionTree
{
    public class ExpressionTree
    {
        private Expression<Func<int, int, int>> lambdaExpresion;

        /// <summary>
        /// Add 2 variables using Expression Tree
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Add(int x, int y)
        {
            Expression<Func<int, int, int>> expressionTree = (num1, num2) => num1 + num2;
            Func<int, int, int> func = expressionTree.Compile();

            return func(x, y);
        }

        /// <summary>
        /// Multiply 2 variables
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Multiply(int x, int y)
        {
            ConstantExpression left = Expression.Constant(x);
            ConstantExpression right = Expression.Constant(y);

            BinaryExpression binaryExpression = Expression.Multiply(left, right);

            Expression<Func<int>> lambdaExpresion = Expression.Lambda<Func<int>>(binaryExpression);

            int sum = lambdaExpresion.Compile()();

            return sum;
        }

        /// <summary>
        /// Calculate Factorial using Expression Tree => fact = n * (n-1) * (n-2) * .... 1
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        public int GetFactorial(int intValue)
        {
            ParameterExpression valueExpression = Expression.Parameter(typeof(int), "value");
            ParameterExpression resultExpression = Expression.Parameter(typeof(int), "result");
            LabelTarget labelTarget = Expression.Label(typeof(int));

            BlockExpression blockExpression = Expression.Block(
                new[] { resultExpression },
                Expression.Assign(resultExpression, Expression.Constant(1)),
                Expression.Loop( // loop block
                    Expression.IfThenElse(
                        Expression.GreaterThan(valueExpression, Expression.Constant(1)),
                        Expression.MultiplyAssign(resultExpression, Expression.PostDecrementAssign(valueExpression)), // multiplication operation
                        Expression.Break(labelTarget, resultExpression)), // break condition
                        labelTarget)
            );

            int factorial = Expression.Lambda<Func<int, int>>(blockExpression, valueExpression).Compile()(intValue); // executing code

            return factorial;
        }
    }
}
