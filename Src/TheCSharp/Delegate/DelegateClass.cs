using System;
using System.Collections.Generic;
using System.Text;

namespace TheCSharp.Delegate
{
    public class DelegateClass
    {
        private delegate int GetTotalSalary();

        public int GetTotalSalaryAmount(int employeeType)
        {
            GetTotalSalary getTotalSalary = null;

            if (employeeType == 0) //consultant
            {
                getTotalSalary = GetConsultantsTotalSalary;
            }
            else if (employeeType == 1) //director
            {
                getTotalSalary = GetDirectorsTotalSalary;
            }
            else if (employeeType == 20) //general employee
            {
                getTotalSalary = GetEmployeesTotalSalary;
            }
            else
            {
                throw new ApplicationException("Sorry! Not a valid employee type.");
            }

            int totalSalaryAmount = getTotalSalary();

            return totalSalaryAmount;
        }

        private int GetConsultantsTotalSalary()
        {
            return 200;
        }

        private int GetEmployeesTotalSalary()
        {
            return 100;
        }

        private int GetDirectorsTotalSalary()
        {
            return 300;
        }



    }
}
