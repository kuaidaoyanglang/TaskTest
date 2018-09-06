using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTestForCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            worker.ParallelInit();
            var t = worker.Init();
            t.Wait();
            Console.ReadKey();
        }
    }

    public class Worker
    {
        public async Task<bool> Init()
        {
            var series = Enumerable.Range(1, 5).ToList();
            var tasks = new List<Task<Tuple<int, bool>>>();
            foreach (var i in series)
            {
                Console.WriteLine("Starting Process {0}", i);
                tasks.Add(DoWorkAsync(i));
            }
            foreach (var task in await Task.WhenAll(tasks))
            {
                if (task.Item2)
                {
                    Console.WriteLine("Ending Process {0}", task.Item1);
                }
            }
            return true;
        }

        public async Task<Tuple<int, bool>> DoWorkAsync(int i)
        {
            Console.WriteLine("working..{0}", i);
            await Task.Delay(1000);
            return Tuple.Create(i, true);
        }

        public bool ParallelInit()
        {
            var series = Enumerable.Range(1, 5).ToList();
            Parallel.ForEach(series, i =>
            {
                Console.WriteLine("Starting Process {0}", i);
                DoWorkAsync(i);
                Console.WriteLine("Ending Process {0}", i);
            });
            return true;
        }
    }
}
