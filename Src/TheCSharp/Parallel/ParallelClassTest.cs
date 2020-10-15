using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace TheCSharp.Parallel1
{
    public class ParallelClassTest
    {
        private readonly ParallelClass parallelObject = new ParallelClass();

        [Fact]
        public void ShouldProcessWhenDataProvided()
        {
            var dataList = new List<Data> { new Data { Id = 1, Value = 100 }, new Data { Id = 2, Value = 200 }, new Data { Id = 3, Value = 300 }, };
            Data[] dataArray = dataList.ToArray();

            parallelObject.ProcessData(dataList);           
            parallelObject.ProcessData(dataArray);        
        }

        [Fact]
        public void ShouldProcessWhenDataProvidedUsingParallelQuery()
        {
            var dataList = new List<Data> { new Data { Id = 1, Value = 100 }, new Data { Id = 2, Value = 200 }, new Data { Id = 3, Value = 300 }, };

            parallelObject.ProcessDataUsingParallelQuery(dataList);
        }

        [Fact]
        public void SholdProcesWhenMethodListProvided()
        {
            var method1 = new Action(() => { Console.WriteLine("Hello World!"); } );

            var method2 = new Action(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Debug.WriteLine($"Hello Wold {i}!");
                }
            });

            parallelObject.Process(method1, method2);
        }
    }
}
