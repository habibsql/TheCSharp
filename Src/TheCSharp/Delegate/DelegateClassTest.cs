using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.Delegate
{
    public class DelegateClassTest
    {
        private readonly DelegateClass delegateObject = new DelegateClass();

        [Fact]
        public void ShouldReturnDirectorsSalary()
        {
            int directorsTotalSalary = delegateObject.GetTotalSalaryAmount(1);

            directorsTotalSalary.Should().Be(300);
        }

        [Fact]
        public void ShouldReturnConsultantsSalary()
        {
            int consultantsTotalSalary = delegateObject.GetTotalSalaryAmount(0);

            consultantsTotalSalary.Should().Be(200);
        }
    }
}
