using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.Partial
{
    public class PartialMethodTest
    {
        private readonly UserService userService = new UserService();

        [Fact]
        public void ShouldTrackUserWhenValidUserIdProvided()
        {
            bool valid = userService.IsUserValid(Guid.NewGuid().ToString());

            valid.Should().BeTrue();
        }

    }
}
