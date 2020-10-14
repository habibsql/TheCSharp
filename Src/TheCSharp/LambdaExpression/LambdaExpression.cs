using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheCSharp.LambdaExpression
{
    public class LambdaExpression
    {
        private readonly IList<Student> students = new List<Student>();

        public LambdaExpression()
        {
            students.Add(new Student { Id = 1, Name = "Student-1", Language = "Bangla" });
            students.Add(new Student { Id = 2, Name = "Student-2", Language = "English" });
            students.Add(new Student { Id = 3, Name = "Student-3", Language = "Bangla" });

        }

        public IEnumerable<StudentDto> ExpressionLambda()
        {
            // Select is builtin lambda function
            IEnumerable<StudentDto> studentDtoList = students.Select(item => new StudentDto { StudentId = item.Id, StudentName = item.Name });

            return studentDtoList;
        }

        public IEnumerable<StudentDto> GetBanglaStudents()
        {
            // SelectCustom is newly created by me lambda function 
            IEnumerable<StudentDto> studentDtoList = students.SelectCustom(item => new StudentDto { StudentId = item.Id, StudentName = item.Name });

            return studentDtoList;
        }


    }

    public class Student
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Language { get; set; }
    }

    public class StudentDto
    {
        public long StudentId { get; set; }

        public string StudentName { get; set; }
    }

    public static class LambdaExtension
    {
        public static IEnumerable<StudentDto> SelectCustom(this IEnumerable<Student> students, Func<Student, StudentDto> func)
        {
            var list = new List<StudentDto>();

            foreach (Student student in students)
            {
                if (student.Language.Equals("Bangla"))
                {
                    StudentDto studentDto = func(student);
                    list.Add(studentDto);
                }
            }

            return list;
        }
    }
}
