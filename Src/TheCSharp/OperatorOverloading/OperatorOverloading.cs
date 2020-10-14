using System;
using System.Collections.Generic;
using System.Text;

namespace TheCSharp.OperatorOverloading
{
    public class Budget
    {
        public long Amount { get; private set; }

        public Budget()
        {
        }

        public Budget(long amount)
        {
            this.Amount = amount;
        }

        public static Budget operator +(Budget budge1, Budget budge2)
        {
            var budget = new Budget
            {
                Amount = budge1.Amount + budge2.Amount
            };

            return budget;
        }

    }
}
