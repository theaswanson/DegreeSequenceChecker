using System;
using System.Collections.Generic;

namespace DegreeSequenceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Degree Sequence Checker");
            IO.PrintIntro();

            var input = IO.GetInput();

            while (input != "q")
            {
                var degreeSequence = new DegreeSequence(input);
                degreeSequence.Draw();

                Console.WriteLine();
                IO.PrintIntro();

                input = IO.GetInput();
            }
        }
    }
}
