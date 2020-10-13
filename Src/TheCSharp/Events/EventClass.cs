using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TheCSharp.Events
{
    public class EmployeeService
    {
        // declaring delegate and event
        public delegate string ResignDelegate(string employeeId);
        public event ResignDelegate EmployeeResigned;

        public string ResigneEmployee(string employeeId)
        {
            Debug.WriteLine($"Resign Employee={employeeId}");

           string status = EmployeeResigned(employeeId);

            return status;
        }       
    }

    public class AccountService
    {
        private readonly EmployeeService employeeService;

        public AccountService(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
            this.employeeService.EmployeeResigned += OnLockEmployeeAccount;
        }

        /// <summary>
        /// Employee resign event handler
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public string OnLockEmployeeAccount(string employeeId)
        {
            Debug.WriteLine($"Locked Employee={employeeId}");

            return "LOCKED";
        }
    }
}
