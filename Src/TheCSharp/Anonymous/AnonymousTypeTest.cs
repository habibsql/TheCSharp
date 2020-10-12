using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.Anonymous
{
    public class AnonymousTypeTest
    {
        private readonly AnonymousType anonymousType = new AnonymousType();

        [Fact]
        public void ShouldReturnStudentAnonymousType()
        {           
            var student = anonymousType.CreateAnonymousStudent("1", "Student-1");

            student.Should().NotBeNull();
        }

        [Fact]
        public void ShuoldReturnStudentAnonymousTypeId()
        {
            var student = new { Id = 100, Name = "Student-100" };

            int studentId = anonymousType.ExtractAnonymousStudentId(student);

            studentId.Should().Be(100);
        }

        [Fact]
        public void ShuoldReturnStudentAnonymousTypeIdV2()
        {
            var student = new { Id = 100, Name = "Student-100" };

            int studentId = anonymousType.ExtractAnonymousStudentIdV2(student);

            studentId.Should().Be(100);
        }
    }

}
