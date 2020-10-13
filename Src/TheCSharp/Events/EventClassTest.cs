using FluentAssertions;
using System;
using System.Collections.Generic;
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
            employeeService = new EmployeeService();
            accountService = new AccountService(employeeService);
        }

        [Fact]
        public void LockEmployeeAccountWhenEmployeeResigned()
        {
            string employeeId = "E001";

            string result = employeeService.ResigneEmployee(employeeId);

            result.Should().Be("LOCKED");
        }
    }
}
