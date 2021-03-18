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
                if (!degreeSequence.IsGraphical)
                {
                    Console.WriteLine("The degree sequence is not graphical due to the following:");
                    foreach (var error in degreeSequence.Errors)
                        Console.WriteLine(error);
                }
                else
                {
                    Console.WriteLine("The degree sequence is graphical.");
                    Console.WriteLine("Adjacency matrix:");
                    degreeSequence.AdjacencyMatrix.Print();
                }

                Console.WriteLine();
                IO.PrintIntro();

                input = IO.GetInput();
            }
        }
    }
}
