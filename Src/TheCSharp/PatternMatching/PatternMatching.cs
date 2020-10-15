using System;
using System.Collections.Generic;
using System.Text;

namespace TheCSharp.PatternMatching
{
    public class StudentBase
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public class FullTimeStudent : StudentBase
    {
    }

    public class PartTimeStudent : StudentBase
    {
        public int Age { get; set; }
    }

    public class PatternMatching
    {

        /// <summary>
        /// Pattern matching by is operator
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool IsFullTimeStudent(StudentBase student)
        {
            return student is FullTimeStudent;
        }


        /// <summary>
        /// Return countryname from country code using pattern matching
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public string FindCountryName(string countryCode)
        {
            string countryName = countryCode switch
            {
                "bd" => "Bangladesh",
                "in" => "India",
                "pak" => "Pakistan",
                _ => string.Empty
            };

            return countryName;
        }


        public int CalculateBonusPoint(StudentBase student)
        {
            int bonusPoint = student switch
            {
                StudentBase std when std is FullTimeStudent  => 200,
                StudentBase std when std is PartTimeStudent => 100, 
                _ => 0
            };

            return bonusPoint;
        }
    }
}
