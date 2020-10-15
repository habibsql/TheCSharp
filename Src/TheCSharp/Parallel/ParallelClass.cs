using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TheCSharp.Parallel1
{

    public class Data
    {
        public int Id { get; set; }

        public int Value { get; set; }
    }


    public class ParallelClass
    {
        /// <summary>
        /// Process data list using parallel programming -> using foreach loop
        /// </summary>
        /// <param name="data"></param>
        public void ProcessData(IEnumerable<Data> data)
        {           
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2
            };            

            Parallel.ForEach(data, options, item =>
            {
                Debug.WriteLine($"{item.Id}- {item.Value}");
            });
        }

        /// <summary>
        ///  Process data list using parallel programming -> using for loop
        /// </summary>
        /// <param name="data"></param>

        public void ProcessData(Data[] data)
        {
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2
            };

            Parallel.For(0, data.Length - 1, options, i =>
            {
                Data local = data[i];

                Debug.WriteLine($"{local.Id}- {local.Value}");
            });
        }

        /// <summary>
        /// Process data list using parallel programming -> using ParallelQuery
        /// </summary>
        /// <param name="data"></param>
        public void ProcessDataUsingParallelQuery(IEnumerable<Data> data)
        {
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2
            };

            data.AsParallel().ForAll(item =>
            {
                Debug.WriteLine(item.Value);
            });
        }

        /// <summary>
        /// Execute list of methods parallelly - using Invoke()
        /// </summary>
        /// <param name="executionList"></param>
        public void Process(Action method1, Action method2)
        {
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 3
            };

            Parallel.Invoke(options,  method1,  method2);
        }

    }
}
