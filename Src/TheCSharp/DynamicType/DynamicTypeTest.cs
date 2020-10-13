using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.Dynamic
{
    public class DynamicTypeTest
    {
        private readonly DynamicType dynamicType = new DynamicType();

        [Fact]
        public void ShouldCreateDynamicEmployeeWhenEmployeePropertiesProvided()
        {
            var dateOfBirth = new DateTime(1970, 5, 6);

            dynamic employee = dynamicType.CreateDynamicEmployee(1999, "Employee-1", dateOfBirth);

            int employeeId = employee.Id;
            DateTime employeeDateOfBirth = employee.DateOfBirth;

            employeeId.Should().Be(1999);
            employeeDateOfBirth.Should().Be(dateOfBirth);
        }

        [Fact]
        public void ShouldTransformEmployeeWhenDynamicEmployeeProvided()
        {
            var dateOfBirth = new DateTime(1970, 5, 6);
            dynamic dynamicEmployee = new Employee();
            dynamicEmployee.Id = 11;
            dynamicEmployee.Name = "Empoyee-11";
            dynamicEmployee.DateOfBirth = dateOfBirth;

            Employee employee = dynamicType.Transform(dynamicEmployee);

            employee.Id.Should().Be(11);
            employee.Name.Should().Be("Empoyee-11");
            employee.DateOfBirth.Should().Be(dateOfBirth);
        }

        [Fact]
        public void ShouldTransformEmployeeV2WhenDynamicEmployeeProvided()
        {
            var dateOfBirth = new DateTime(1970, 5, 6);
            dynamic dynamicEmployee = new Employee();
            dynamicEmployee.Id = 11;
            dynamicEmployee.Name = "Empoyee-11";
            dynamicEmployee.DateOfBirth = dateOfBirth;

            Employee employee = dynamicType.TransformV2(dynamicEmployee);

            employee.Id.Should().Be(11);
            employee.Name.Should().Be("Empoyee-11");
            employee.DateOfBirth.Should().Be(dateOfBirth);
        }

        [Fact]
        public void ShouldReturnSalaryWhenEmployeeDynamicObjectProvided()
        {
            dynamic employee = new Employee();

            int salary = dynamicType.GetSalary(employee);

            salary.Should().Be(110);
        }

        [Fact]
        public void PolymorphismTest()
        {
            int staticAge = 100;
            dynamic dynamicAge = staticAge;

            int staticReturnAge = dynamicType.GetAge(staticAge);
            int dynamicReturnAge = dynamicType.GetAge(dynamicAge);

            staticReturnAge.Should().Be(dynamicReturnAge);
        }

        [Fact]
        public void DynamicTypeCheck()
        {
            dynamic dynamicEmployee = new Employee { Id = 1 };

            bool employeeType = dynamicType.IsDynamicObjectEmployeeType(dynamicEmployee);

            employeeType.Should().BeTrue();
        }
    }
}
