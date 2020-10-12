using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.Anonymous
{
    public class AnonymousMethodTest
    {
        private readonly AnonymousMethod anonymousMethod = new AnonymousMethod();

        [Fact]
        public void ShouldReturnSumWhenXandYValueProvided()
        {
            int x = 20;
            int y = 10;
            int z = anonymousMethod.Add(x, y);

            z.Should().Be(30);
        }
 
    }

}
