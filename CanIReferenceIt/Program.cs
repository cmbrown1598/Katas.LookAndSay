using System;
using Katas;

namespace CanIReferenceIt
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new LookAndSayGenerator();
            Console.WriteLine("Generating!");
            var n = m.GenerateLookAndSay("1", 60);
            Console.WriteLine($"Generated {n}");
        }
    }
}
