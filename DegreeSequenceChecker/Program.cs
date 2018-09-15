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

            string input = IO.GetInput();

            while (input != "q")
            {
                DegreeSequence myDegreeSequence = new DegreeSequence(input);
                myDegreeSequence.Draw();

                Console.WriteLine();
                IO.PrintIntro();

                input = IO.GetInput();
            }
        }
    }
}
