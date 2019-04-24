using System;

namespace BasicAuthGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Basic auth is: {GenerateToken.GetBasicAuth()}");
            Console.ReadKey();
        }
    }
}
