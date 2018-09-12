using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);

            Func<Task> func3 = Delay3000Async;
            Func<Task> func2 = Delay2000Async;
            Func<Task> func1 = Delay1000Async;

            new Action(async () =>
            {
                await func3();
                await func2();
                await func1();
            }
            )();

            //var funcList = new List<Func<Task>>()
            //{
            //    Delay3000Async,
            //    Delay2000Async,
            //    Delay1000Async
            //};

            //funcList.ForEach(async _ => await _());

            //var tasks = new List<Task>
            //{
            //    Delay3000Async(),
            //    Delay2000Async(),
            //    Delay1000Async()
            //};

            //tasks.ForEach(async _ => await _);


            //var task3 = Delay3000Async();
            //var task2 = Delay2000Async();
            //var task1 = Delay1000Async();

            //new Action(async () =>
            //{
            //    await task3;
            //    await task2;
            //    await task1;
            //})();

            //new Action(async () =>
            //{
            //    await Delay3000Async();
            //    await Delay2000Async();
            //    await Delay1000Async();
            //})();
            Console.WriteLine(@"我执行完了！");
            Console.ReadKey();
        }

        static async Task Delay3000Async()
        {
            await Task.Delay(3000);
            Console.WriteLine(3000);
            Console.WriteLine(DateTime.Now);
        }

        static async Task Delay2000Async()
        {
            await Task.Delay(2000);
            Console.WriteLine(2000);
            Console.WriteLine(DateTime.Now);
        }

        static async Task Delay1000Async()
        {
            await Task.Delay(1000);
            Console.WriteLine(1000);
            Console.WriteLine(DateTime.Now);
        }
    }
}
