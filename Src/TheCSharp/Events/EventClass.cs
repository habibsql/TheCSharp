using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TheCSharp.Events
{
    public class EmployeeService
    {
        // declaring delegate and event
        public delegate void AccountLockedDelegate(string employeeId, string employeeName);
        public event AccountLockedDelegate AccountLockedEvent;
        private readonly AccountService accountService;

        public EmployeeService(AccountService accountService)
        {
            this.accountService = accountService;
        }

        public bool ResigneEmployee(string employeeId)
        {
            Debug.WriteLine($"Resign Employee={employeeId}");

            bool accountLocked = accountService.LockEmployeeAccount(employeeId);

            if (accountLocked && AccountLockedEvent != null)
            {
                AccountLockedEvent(employeeId, $"Mr.{employeeId}");
            }

            return true;
        }
    }

    /// <summary>
    /// Employee Account Service
    /// </summary>
    public class AccountService
    {
        /// <summary>
        /// Employee Account lock 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public bool LockEmployeeAccount(string employeeId)
        {
            Debug.WriteLine($"Locked Employee={employeeId}");

            return true;
        }
    }
}
