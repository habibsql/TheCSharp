using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.ExpressionTree
{
    public class ExpressionTreeTest
    {
        private readonly ExpressionTree expressionTree = new ExpressionTree();

        [Fact]
        public void ShouldAddWhenProvidTwoNumber()
        {
            int x = 20;
            int y = 10;

            int z = expressionTree.Add(x, y);

            z.Should().Be(30);
        }

        [Fact]
        public void ShouldMultiplyWhenProvidTwoNumberV2()
        {
            int x = 20;
            int y = 10;

            int z = expressionTree.Multiply(x, y);

            z.Should().Be(200);
        }

        [Fact]
        public void ShouldReturnFactorialWhenAnyIntegerProvided()
        {
            int value = 6;

            int factorial = expressionTree.GetFactorial(value);

            factorial.Should().Be(720);
        }
    }
}
