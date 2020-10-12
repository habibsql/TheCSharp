using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.Delegate
{
    public class MulticastDelegateClassTest
    {
        private readonly MulticastDelegateClass multicastDelegateObject = new MulticastDelegateClass();

        [Fact]
        public void ShouldReturnAllEmployeesCount()
        {
            int totalEmployeesCount = multicastDelegateObject.CountTotalEmployees();

            totalEmployeesCount.Should().Be(300);            
        }

    }
}
