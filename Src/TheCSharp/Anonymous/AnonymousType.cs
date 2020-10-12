using System;
using System.Collections.Generic;
using System.Text;

namespace TheCSharp.Anonymous
{
    /// <summary>
    /// A custom class to show Anonymous Type
    /// </summary>
    public class AnonymousType
    {
        /// <summary>
        /// A anonymous type
        /// </summary>
        /// <returns>a student with 2 properties Id & Name</returns>
        public object CreateAnonymousStudent(string id, string name)
        {
            var student = new
            {
                Id = id,
                Name = name
            };

            return student;
        }

        public int ExtractAnonymousStudentId(object student)
        {
            dynamic studentLocal = student;

            int studentId = studentLocal.Id;

            return studentId;
        }

        public int ExtractAnonymousStudentIdV2(object student)
        {
            object studentId = student.GetType().GetProperty("Id").GetValue(student);

            return (int)studentId;
        }

    }

}
