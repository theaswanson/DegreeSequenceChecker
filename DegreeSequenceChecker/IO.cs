using System;
using System.Collections.Generic;
using System.Text;

namespace DegreeSequenceChecker
{
    public abstract class IO
    {
        public static void PrintIntro()
        {
            Console.WriteLine("Enter a degree sequence of non-negative integers separated by spaces ('q' to quit):");
        }

        public static string GetInput()
        {
            return Console.ReadLine();
        }

        public static void GetKey()
        {
            Console.ReadKey();
        }
    }
}
