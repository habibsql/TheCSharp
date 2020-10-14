using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TheCSharp.ExceptionHandling
{
    public class ExceptionHander
    {
        /// <summary>
        /// Throw a custom Exception when argument is less than 1
        /// </summary>
        /// <param name="value"></param>
        [DebuggerStepThrough]
        public void ThrowACustomException(int value)
        {
            if (value < 1)
                throw new MyCustomException("Value should not be 0 or negative. Learning purpose only!");            
        }

        /// <summary>
        /// Demonastare simple  handling exception best practice
        /// </summary>
        /// <returns></returns>
        public int HandleException()
        {
            // try-catch-finally -> finally is optional
            try
            {
                throw new MyCustomException("Learning purpose only!");
            }
            catch(MyCustomException ex)
            {
                Debug.WriteLine(ex.Message); // Good practice and it should be (specific exception handle),
            }
            catch(Exception ex) // base exception (Generale exception handling)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Debug.WriteLine("Finally block is executing...");
            }

            return 1;
        }

        /// <summary>
        /// Demonastrate Nesting Exception
        /// </summary>
        public void HandleNestedException()
        {
            int value = 0;
            int totalValue = 100;
            int result = 0;

            try
            {
               result = totalValue / value;
            }
            catch(DivideByZeroException e)
            {
                try
                {
                    result = result / 0;
                }
                catch(DivideByZeroException ex)
                {
                    Debug.Write("Message from inner exception");
                }
            }
        }

        public void HandleExceptionAndThenRethrow()
        {
            int firstValue = 100;
            int secondValue = 0;

            try
            {
                int result = firstValue / secondValue;
            }
            catch(DivideByZeroException ex)
            {
                // exception reported
                Debug.WriteLine("Sorry! first value should not be devided by zero. It is forbedden.");

                throw;

                /* 1:
                throw; // throwing               
                */

                /* 2:
                 * throwing and rethowing has difference. rethrowing change the stack trace of the original exception
                throw ex; // retrhowing
                */

                /* 3:
                 * Another way. In this case the original exception will be in inner Exception                 
                throw new Exception("Sorry! Should not be allowed to devide by zero", ex);
                */
            }
        }

        /// <summary>
        /// Filtering exception based on logic
        /// </summary>
        public void FilterException()
        {
            int value = -1;
            try
            {
                throw new ArgumentNullException("The argument should not be null");
            }
            catch(Exception ex) when (WillExceptionHandled(value)) // only when WillExceptionHandled method return true then it will be handled 
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private bool WillExceptionHandled(int value)
        {
            return  value <1 ? true : false;
        }
    }


    /// <summary>
    /// Creating a Custom Exception
    /// </summary>
    public class MyCustomException : ApplicationException
    {
        public MyCustomException()
        {
        }
        public MyCustomException(string message) : base(message)
        {
        }
    }
}
