using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayValue();
            Console.Write("Myclass End");
            Console.Read();
        }


        public static Task<double> GetValueAsync(double num1, double num2)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    num1 = num1 / num2;

                }
                return num1;


            });
        }
        public static async void DisplayValue()
        {
            double result = await GetValueAsync(1234.5, 1.01);

            Console.Write("Value is:" + result);

        }
    }
}
