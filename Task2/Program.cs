using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(new ParallelOptions() { MaxDegreeOfParallelism = 2, TaskScheduler = new MyTaskScheduler() }, Method1, Method2);
            
        }
        static void Method1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("* ");
                Thread.Sleep(50);
            }
        }
        static void Method2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("+ ");
                Thread.Sleep(50);
            }
        }
    }
    class MyTaskScheduler : TaskScheduler
    {
        Queue<Task> queue = new Queue<Task>();
        AutoResetEvent resetEvent = new AutoResetEvent(true);

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            throw new NotImplementedException();
        }

        protected override void QueueTask(Task task)
        {
            queue.Enqueue(task);
            ThreadPool.RegisterWaitForSingleObject(resetEvent, (object state, bool timedOut) => TryExecuteTask(queue.Dequeue()), null, 0, true);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }
    }
}
