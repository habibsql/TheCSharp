using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheCSharp.Linq
{

    public abstract class EntityBase
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public class Employee : EntityBase
    {
        public string Manager { get; set; }

        public string DepartmentId { get; set; }
    }

    public class Department : EntityBase
    {
        public string DepartmentHead { get; set; }
    }

    public class EmployeeDepartmentDto
    {
        public string EmployeeName { get; set; }

        public string DepartmentName { get; set; }
    }

    public class DepartmentEmployeeCountDto
    {
        public string DepartmentName { get; set; }

        public int NoofEmployees { get; set; }
    }

    public class EntityRepository
    {
        private readonly IList<Employee> employees = new List<Employee>();
        private readonly IList<Department> departments = new List<Department>();

        public EntityRepository()
        {
            departments.Add(new Department { Id = "IT", Name = "IT", DepartmentHead = "MR. IT" });
            departments.Add(new Department { Id = "Finance", Name= "Finance", DepartmentHead = "MR. Finance" });

            employees.Add(new Employee { Id = "E001", Name = "Employee-E001", Manager = "Manager-3", DepartmentId = "IT" });
            employees.Add(new Employee { Id = "E002", Name = "Employee-E002", Manager = "Manager-1", DepartmentId = "IT" });
            employees.Add(new Employee { Id = "E003", Name = "Employee-E003", Manager = "Manager-1", DepartmentId = "Finance" });
            employees.Add(new Employee { Id = "E004", Name = "Employee-E004", Manager = "Manager-2", DepartmentId = null });
            employees.Add(new Employee { Id = "E005", Name = "Employee-E005", Manager = "Manager-2", DepartmentId = null });
        }

        /// <summary>
        /// Demonastrate Inner join
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeDepartmentDto> FindEmployeesWhoHasDepartment()
        {
            IEnumerable<EmployeeDepartmentDto> employeeDtoList = employees.Join( //outer sequence
                departments, // inner sequence
                emp => emp.DepartmentId, // outer key 
                dept => ((Department)dept).Id, // inner key
                (emp, dept) => new EmployeeDepartmentDto
                {
                    EmployeeName = emp.Name,
                    DepartmentName = dept.Name
                });

            return employeeDtoList;
        }

        /// <summary>
        /// Count no of employees per department using Groupby operator
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepartmentEmployeeCountDto> CountDepartmentEmployees()
        {
            IEnumerable<EmployeeDepartmentDto> employeeDepartmentDtos = employees.Join(departments, emp => emp.DepartmentId,
                dept => ((Department)dept).Id, (emp, dept) => new EmployeeDepartmentDto
                {
                    DepartmentName = dept.Name,
                    EmployeeName = emp.Name
                }).ToList();

            // First grouping then counting and finally sorting by department name
           IEnumerable<DepartmentEmployeeCountDto> departwiseEmployeeCount = employeeDepartmentDtos.GroupBy(item => item.DepartmentName).Select(
                g => new DepartmentEmployeeCountDto { DepartmentName = g.First().DepartmentName, NoofEmployees = g.Count() })
                .OrderBy(item => item.DepartmentName); // order by departmentname

            return departwiseEmployeeCount;
        }

        public IEnumerable<Employee> FindEmployeesWhoHasNoDepartment()
        {
            return employees.Where(employee => employee.DepartmentId == null).OrderByDescending(item => item.Name);
        }

        /// <summary>
        /// Filter clause from client side as form of Func<T,T> delegate
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public IEnumerable<Employee> FilterEmployees(Func<Employee, bool> func)
        {
            return employees.Where(func);
        }
    }
}
