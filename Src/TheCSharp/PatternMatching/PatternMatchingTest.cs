using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.PatternMatching
{
    public class PatternMatchingTest
    {
        private readonly PatternMatching patternMatching = new PatternMatching();

        [Fact]
        public void ShouldCheckSpecificType()
        {
            StudentBase student = new FullTimeStudent { Id = 1, Name = "FullTimeStudent-1" };

            bool yes = patternMatching.IsFullTimeStudent(student);

            yes.Should().BeTrue();
        }

        [Fact]
        public void ShouldRetrunCountryNameWhenCountryCodeProvided()
        {
            string countryCode = "bd";

            string countryName = patternMatching.FindCountryName(countryCode);

            countryName.Should().Be("Bangladesh");
        }

        [Fact]
        public void ShouldCalculateBonusPoint()
        {
            StudentBase fullTimeStudent = new FullTimeStudent { Id = 1 };
            StudentBase partTimeStudent = new PartTimeStudent { Id = 100 };

            int bonusPointForFullTimeStudent = patternMatching.CalculateBonusPoint(fullTimeStudent);
            int bonusPointForPartTimeStudent = patternMatching.CalculateBonusPoint(partTimeStudent);

            bonusPointForFullTimeStudent.Should().Be(200);
            bonusPointForPartTimeStudent.Should().Be(100);
        }

    }
}
