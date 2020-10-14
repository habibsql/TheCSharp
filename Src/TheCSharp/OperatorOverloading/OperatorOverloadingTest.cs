using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.OperatorOverloading
{
    public class OperatorOverloadingTest
    {
        [Fact]
        public void ShouldSumBudge()
        {
            var budget1 = new Budget(100);
            var budget2 = new Budget(200);

            Budget budget3 = budget1 + budget2;

            budget3.Amount.Should().Be(300);
        }
    }
}
