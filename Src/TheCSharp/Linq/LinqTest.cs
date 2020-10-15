using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TheCSharp.Linq
{
    public class LinqTest
    {
        private readonly EntityRepository entityRepository = new EntityRepository();

        [Fact]
        public void ShouldReturnEmployeesWhoHasDepartment()
        {
            IEnumerable<EmployeeDepartmentDto> employees = entityRepository.FindEmployeesWhoHasDepartment();

            employees.Should().HaveCount(3);
            employees.Any(item => item.EmployeeName.Equals("Employee-E001")).Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnDepartwiseEmployeeCount()
        {
            IEnumerable<DepartmentEmployeeCountDto> departmentEmployeeCountDtos = entityRepository.CountDepartmentEmployees();

            departmentEmployeeCountDtos.First(item => item.DepartmentName == "IT").NoofEmployees.Should().Be(2);
            departmentEmployeeCountDtos.First(item => item.DepartmentName == "Finance").NoofEmployees.Should().Be(1);                
        }

        [Fact]
        public void ShouldReturnEmployeeWhoHasNoDepartment()
        {
            IEnumerable<EmployeeDepartmentDto> employeeDepartments = entityRepository.FindEmployeesWhoHasDepartment();

            employeeDepartments.Should().HaveCount(2);
        }

        [Fact]
        public void ShouldFilterEmployees()
        {
            IEnumerable<Employee> employees = entityRepository.FilterEmployees(item => item.DepartmentId == "IT");
            IEnumerable<Employee> employees2 = entityRepository.FilterEmployees(item => item.DepartmentId == "IT" && item.Manager == "Manager-3");

            employees.Should().HaveCount(2);
            employees2.Should().HaveCount(1);
        }
    }
}
