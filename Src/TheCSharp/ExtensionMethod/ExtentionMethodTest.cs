using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.ExtensionMethod
{
    public class ExtentionMethodTest
    {
        private readonly EmployeeService employeeService = new EmployeeService();

        [Fact]
        public void ShouldGetEmployeeDevident()
        {
            int employeeDevident1 = employeeService.CalculateDevident(null, 100);
            int employeeDevident2 = employeeService.CalculateDevident("A01", 0);
            int employeeDevident3 = employeeService.CalculateDevident("A01", 100);
            int employeeDevident4 = employeeService.CalculateDevident("B01", 100);
            int employeeDevident5 = employeeService.CalculateDevident("C01", 100);

            employeeDevident1.Should().Be(0);
            employeeDevident2.Should().Be(0);
            employeeDevident3.Should().Be(100);
            employeeDevident4.Should().Be(50);
            employeeDevident5.Should().Be(25);
        }

        [Fact]
        public void ShouldReturnFirstCharacterWhenValidStringProvided()
        {
            string countryName = "Bangladesh";

            string firstTwoCharacter = countryName.FirstTwoCharacters();

            firstTwoCharacter.Should().Be("Ba");


            // you cal call Extension method as static method as well

            string firstTwo = StringExtension.FirstTwoCharacters(countryName);

            firstTwo.Should().Be("Ba");
        }
    }
}
