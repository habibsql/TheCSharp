using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheCSharp.Async
{
    /// <summary>
    /// Demonastrate Async features
    /// </summary>
    public class AsyncClass
    {
        /// <summary>
        /// 3 seconds needed to complete this
        /// </summary>
        /// <returns></returns>
        public Task Process1Async()
        {
            Task task = Task.Delay(3000); // does not block the current thread

            return task;
        }

        /// <summary>
        /// 4 seconds needed to complete this
        /// </summary>
        /// <returns></returns>
        public Task Process2Async()
        {
            Task task = Task.Delay(4000); // does not block the current thread

            return task;
        }

        /// <summary>
        /// Execute Synchonous Method Asynchonously
        /// </summary>
        /// <returns></returns>
        public Task ExecuteAsync()
        {
            var action = new Action(VisitIntegerNumbers);

            var task = new Task(action);
            task.Start();

            return task;
        }

        public Task ExecutewithCancelSupportAsync()
        {
            var cancelSource = new CancellationTokenSource();
            var token = cancelSource.Token;

            Task task = Task.Run(() =>
            {
                LongRunningOperation(token);
            });


            // send signal to cancel execution
            cancelSource.Cancel();

            return task;
        }

        /// <summary>
        /// Dummy processing
        /// </summary>
        private void VisitIntegerNumbers()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
            }
            Debug.Write($"Completed visited upto {int.MaxValue - 1}");
        }

        private void LongRunningOperation(CancellationToken token)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
            }
            Debug.Write($"Completed counting {int.MaxValue} sequentially!");
        }
    }

}
