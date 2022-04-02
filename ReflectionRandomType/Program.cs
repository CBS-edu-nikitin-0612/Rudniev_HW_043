using System;
using System.Reflection;

namespace ReflectionRandomType
{
    class Program
    {
        static void Main(string[] args)
        {
            Type typeRandom = typeof(Random);
            MethodInfo methodInfo = typeRandom.GetMethod("Next", new Type[] {typeof(int), typeof(int)});
            MethodBody methodBody = methodInfo.GetMethodBody();
            Console.WriteLine(methodBody.ToString());
        }
    }
}
