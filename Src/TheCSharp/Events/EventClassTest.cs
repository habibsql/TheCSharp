using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace TheCSharp.Events
{
    public class EventClassTest
    {
        private readonly EmployeeService employeeService;
        private readonly AccountService accountService;

        public EventClassTest()
        {
            accountService = new AccountService();
            employeeService = new EmployeeService(accountService);

            employeeService.AccountLockedEvent += delegate (string employeeId, string employeeName)
            {
                Debug.WriteLine($"Locked Employee Name={employeeName}");
            };
        }

        [Fact]
        public void LockEmployeeAccountWhenEmployeeResigned()
        {
            string employeeId = "E001";

            bool succeed = employeeService.ResigneEmployee(employeeId);

            succeed.Should().Be(true);
        }
    }
}
