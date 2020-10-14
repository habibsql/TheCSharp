using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.Generic
{
    public class GenericTest
    {
        private readonly EmployeeRepository<Employee> employeeRepository = new EmployeeRepository<Employee>();

        [Fact]
        public void ShouldReturnAllEmployees()
        {
            IEnumerable<Employee> employees = employeeRepository.GetEmployees();

            employees.Should().HaveCount(4);
        }

        [Fact]
        public void ShouldAddANewEmployee()
        {
            var fullTimeEmployee = new FullTimeEmployee { Id = "F003" };

            employeeRepository.AddNewEmployee(fullTimeEmployee);
        }

        [Fact]
        public void ShouldCreateAFulLTimeEmployeeWhenIdisProvided()
        {
            const string employeeId = "F005";

            Employee employee = employeeRepository.CreateFullTimeEmployeeById<FullTimeEmployee>(employeeId);

            employee.Id.Should().Be(employeeId);
        }
    }

    public class CoContraVarienceTest
    {
        private readonly IAnimalAcceptService<Animal> animalAcceptService = new DefaultAnimalAcceptService();
        private readonly IAnimalReturnService<Animal> animalReturnService = new DefaultAnimalReturnService();
        private readonly IAnimalAcceptReturnService<Animal> animalAcceptReturnService = new DefaultAnimalAcceptReturnService();

        [Fact]
        public void ShouldAcceptAnyAnimal()
        {
            var parot = new Parot { Name = "MyParot-1" };

            animalAcceptService.AcceptAnimal(parot);
        }

        [Fact]
        public void ShouldReturnAnyAnimal()
        {
            var cat = (Cat)animalReturnService.GetAnimal();

            cat.Should().NotBeNull();
        }

        [Fact]
        public void ShouldAcceptAndReturnAnyAnimal()
        {
            var cat = new Cat { Name = "MyCat-1" };

            Cat returnCat = (Cat)animalAcceptReturnService.AcceptAndReturn(cat);

            returnCat.Should().NotBeNull();
        }
    }
}
