using System;
using System.Collections.Generic;
using System.Text;

namespace TheCSharp.Dynamic
{
    public class DynamicType
    {
        public dynamic CreateDynamicEmployee(int id, string name, DateTime dateOfBirth)
        {
            var employee = new Employee
            {
                Id = id,
                Name = name
            };

            dynamic dynamicEmp = employee;
            dynamicEmp.DateOfBirth = dateOfBirth; //once it assigned can not be added diffent property

            return dynamicEmp;
        }

        public Employee Transform(dynamic employee)
        {
            var emp = new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                DateOfBirth = employee.DateOfBirth
            };

            return emp;
        }

        public Employee TransformV2(dynamic employee)
        {
            Employee emp = employee;
            // Employee emp2 = (Employee) employee; // no need to explicit type casting
            return emp;
        }

        public int GetSalary(dynamic employee)
        {
            int salary = employee.GetEmployeeSalary(10);

            return salary;
        }

        public int GetAge(int employeeId)
        {
            return employeeId / 4;
        }

        public int GetAge(dynamic employeeId)
        {
            return employeeId / 4;
        }

        public bool IsDynamicObjectEmployeeType(dynamic employee)
        {
            Type type = employee.GetType();

            return type.Name.Equals("Employee");
        }

    }

    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int GetEmployeeSalary(int taxAmount)
        {
            return 100 + taxAmount;
        }
    }
}
