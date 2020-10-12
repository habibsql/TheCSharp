using System;
using System.Collections.Generic;
using System.Text;

namespace TheCSharp.Anonymous
{ 
    /// <summary>
    /// A custom class to implement/show anonymous method
    /// </summary>
    public class AnonymousMethod
    {
        private delegate int AddDelegate(int x, int y);

        /// <summary>
        /// Add 2 variables using anonymous method.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Add(int x, int y)
        {
            AddDelegate add = delegate (int x, int y)
            {
                return x + y;
            };

            return add(x, y);
        }
    }

}
