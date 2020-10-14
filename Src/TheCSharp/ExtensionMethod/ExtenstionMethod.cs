using System;
using System.Collections.Generic;
using System.Text;

namespace TheCSharp.ExtensionMethod
{
    public class EmployeeService
    {
        public int CalculatePayableSalary(string employeeId)
        {
            int taxAmount = 100;
            int totalSaalary = 1000;

            if (employeeId.Substring(0) == "A")
            {
                return totalSaalary - taxAmount;
            }

            return totalSaalary;
        }


        public int CalculateBonus(string employeeId)
        {
            int maxBonus = 1000;

            if (employeeId.Length == 3)
            {
                return maxBonus;
            }

            return maxBonus / 2;
        }
    }


    public static class EmployeeServiceExtension
    {
        public static int CalculateDevident(this EmployeeService employeeService, string employeeId, int totalDevident)
        {
            if (null == employeeId || totalDevident == 0)
            {
                return 0;
            }

            if (employeeId.Contains("A"))
            {
                return totalDevident;
            }

            if (employeeId.Contains("B"))
            {
                return totalDevident / 2;
            }

            return totalDevident / 4;
        }
    }

    public static class StringExtension
    {
        public static string FirstTwoCharacters(this string stringValue)
        {
            if (null == stringValue)
            {
                return string.Empty;
            }

            return stringValue.Substring(0, 2);
        }
    }

}
