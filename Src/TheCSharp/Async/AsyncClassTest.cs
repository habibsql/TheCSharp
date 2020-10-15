using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TheCSharp.Async
{
    public class AsyncClassTest
    {
        private readonly AsyncClass asyncObject = new AsyncClass();

        [Fact]
        public Task ProcessAsynchronously()
        {
            Task task1 = asyncObject.Process1Async();
            Countring();
            Task task2 = asyncObject.Process2Async();
            Countring();

            Task.WaitAll(task1, task2); // block the thread untill finish all the executions

            return Task.CompletedTask;
        }

        [Fact]
        public Task ShouldExecuteSyncMethodAsynchronously()
        {
            Task task = asyncObject.ExecuteAsync();

            task.Wait();

            return Task.CompletedTask;
        }

        [Fact]
        public async Task ShouldCancelCurrentAsynchonousExecution()
        {
            await Assert.ThrowsAsync<OperationCanceledException>(asyncObject.ExecutewithCancelSupportAsync);           
        }

        private void Countring()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
            }
            Debug.WriteLine($"counting completed from 0 to {int.MaxValue - 1}");
        }
    }
}
