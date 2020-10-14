using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.ExceptionHandling
{
    public class ExceptionHanderTest
    {
        private readonly ExceptionHander exceptionHandler = new ExceptionHander();

        [Fact]
        public void ShouldThrowCustomException()
        {
            int value = -1;
            Assert.Throws<MyCustomException>(() =>
                exceptionHandler.ThrowACustomException(value)
            );
        }

        [Fact]
        public void ShouldCatchRethrowAnException()
        {
            try
            {
                exceptionHandler.HandleExceptionAndThenRethrow();
            }
            catch (DivideByZeroException ex)
            {
            }
        }


        [Fact]
        public void ShouldHandleException()
        {
            exceptionHandler.HandleException();
        }

        [Fact]
        public void ShouldHandleNestedException()
        {
            exceptionHandler.HandleNestedException();
        }

        [Fact]
        public void ShouldFilterException()
        {
            exceptionHandler.FilterException();
        }

    }
}
