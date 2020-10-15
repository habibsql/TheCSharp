using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.Nullable
{
    public class NullableClassTest
    {
        private readonly NullableClass nullableObject = new NullableClass();

        [Fact]
        public void ShouldGetAge()
        {
            int age = nullableObject.GetAge();

            age.Should().Be(-1);
        }

        [Fact]
        public void ShouldSetAge()
        {
            int? age = nullableObject.SetAge(50);

            age.Value.Should().Be(50);
        }

        [Fact]
        public void SholdReturnTrueWhenGraterThan50AgeProvided()
        {
            bool greaterThenFifty = nullableObject.IsAgeGreaterThan50(51);

            greaterThenFifty.Should().BeTrue();
        }

    }
}
