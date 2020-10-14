using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.LambdaExpression
{
    public class LambdaExpressionTest
    {
        private readonly LambdaExpression lambdaExpression = new LambdaExpression();

        [Fact]
        public void ShouldReturnAllStudents()
        {
            IEnumerable<StudentDto> studentList = lambdaExpression.ExpressionLambda();

            studentList.Should().HaveCount(3);
        }


        [Fact]
        public void ShouldReturnBanglaStudents()
        {
            IEnumerable<StudentDto> studentList = lambdaExpression.GetBanglaStudents();

            studentList.Should().HaveCount(2);
        }
    }
}
