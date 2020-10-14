using System;
using System.Collections.Generic;
using System.Text;

namespace TheCSharp.Generic
{
    public abstract class Employee
    {
        public string Id { get; set; }

        public abstract int CalculateSalary();
    }

    public class FullTimeEmployee : Employee
    {
        public override int CalculateSalary()
        {
            return 200;
        }
    }

    public class PartTimeEmployee : Employee
    {
        public override int CalculateSalary()
        {
            return 100;
        }
    }

    /// <summary>
    /// Generic Employee Service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EmployeeRepository<T>  where T : Employee
    {
        private IList<Employee> employees = new List<Employee>();

        public EmployeeRepository()
        {
            employees.Add(new FullTimeEmployee() { Id = "F001" });
            employees.Add(new FullTimeEmployee() { Id = "F002" });
            employees.Add(new PartTimeEmployee() { Id = "P001" });
            employees.Add(new PartTimeEmployee() { Id = "P002" });            
        }

        public IEnumerable<Employee> GetEmployees()
        {          
            return employees;
        }

        public void AddNewEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        /// <summary>
        /// Generic Method -> Generic as return type
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T2 CreateFullTimeEmployeeById<T2>(string id) where T2 : FullTimeEmployee
        {
            return (T2) new FullTimeEmployee { Id = id };
        }

        /// <summary>
        /// Generic type as arguments
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="employee1"></param>
        /// <param name="employee2"></param>
        /// <returns></returns>
        public int CalculateSalary<T2>(T2 employee1, T2 employee2) where T2 : PartTimeEmployee
        {
            int totalSalary = employee1.CalculateSalary() + employee2.CalculateSalary();

            return totalSalary;                
        }
    }


    public abstract class Animal
    {
        public string Name { get; set; }
    }

    public abstract class Bird : Animal
    {
    }

    public abstract class Domistic : Animal
    {
    }

    public class Parot : Bird
    {
    }
    public class Cat : Domistic
    {
    }

    /// <summary>
    /// Value type does not support variantused as Return type.
    /// </summary>
    /// <typeparam name="Animal"></typeparam>
    public interface IAnimalReturnService<out Animal> 
    {
        Animal GetAnimal();
    }

    /// <summary>
    /// Use only argument type
    /// </summary>
    /// <typeparam name="Animal"></typeparam>
    public interface IAnimalAcceptService<in Animal>
    {
        void AcceptAnimal(Animal animal);
    }

    /// <summary>
    /// Capable of both Arguent and Return type
    /// </summary>
    /// <typeparam name="Animal"></typeparam>
    public interface IAnimalAcceptReturnService<Animal>
    {
        Animal AcceptAndReturn(Animal animal);
    }


    public class DefaultAnimalReturnService : IAnimalReturnService<Animal>
    {
        public Animal GetAnimal()
        {
            return new Cat { Name = "Cat-100" };
        }
    }

    public class DefaultAnimalAcceptService : IAnimalAcceptService<Animal>
    {
        private readonly IList<Animal> animals = new List<Animal>();

        public void AcceptAnimal(Animal animal)
        {
            animals.Add(animal);
        }       
    }

    public class DefaultAnimalAcceptReturnService : IAnimalAcceptReturnService<Animal>
    {
        public Animal AcceptAndReturn(Animal animal)
        {
            return animal;
        }
    }

}
