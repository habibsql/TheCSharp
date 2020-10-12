using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TheCSharp.Delegate
{
    public class MulticastDelegateClass
    {
        private delegate int CalculateEmployees();
        private List<CalculateEmployees> calculateEmployeeDelegates = new List<CalculateEmployees>();
        private readonly System.Delegate allDelegate;

        public MulticastDelegateClass()
        {
            calculateEmployeeDelegates.Add(CalculateFullTimeEmployees);
            calculateEmployeeDelegates.Add(CalculatePartTimeEmployees);
            allDelegate = MulticastDelegate.Combine(calculateEmployeeDelegates.ToArray());
        }

        public int CountTotalEmployees()
        {
            int totalEmployees = 0;
            foreach(System.Delegate calculate in allDelegate.GetInvocationList())
            {
                totalEmployees += (int) calculate.DynamicInvoke();
            }

            return totalEmployees;
        }

        private int CalculateFullTimeEmployees()
        {
            return 100;
        }

        private int CalculatePartTimeEmployees()
        {
            return 200;
        }
    }
}
