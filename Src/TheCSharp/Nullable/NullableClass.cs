using System;
using System.Collections.Generic;
using System.Text;

namespace TheCSharp.Nullable
{
    public class NullableClass
    {
        // Nullable<int> = int?
        private int? age = null; // assign null

        public int GetAge()
        {
            int newAge = age ?? -1; // retrive value from nullable type

            return newAge;
        }

        public int? SetAge(int? age)
        {
            this.age = age;

            return this.age;
        }

        public bool IsAgeGreaterThan50(int? age)
        {
            if (age.HasValue && age.Value > 50) // checking nullable type
            {
                return true;
            }

            return false;
        }

    }
}
