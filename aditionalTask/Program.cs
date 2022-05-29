using System;
using System.Linq;
using System.Threading.Tasks;

namespace aditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = RandomIntArrays(1000000);
            var list = array.AsParallel().Where(el => el % 2 == 1).ToList();
            Parallel.ForEach(list, el => Console.Write(el + " "));
            Console.WriteLine("Array length = " + list.Count);
        }
        static int[] RandomIntArrays(int length)
        {
            Random random = new Random();
            int[] array = new int[length];

            Parallel.For(0, array.Length, i => array[i] = random.Next(0, 10));
            return array;
        }
    }
}

