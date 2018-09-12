using System;
using System.Collections.Generic;

namespace DegreeSequenceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            IO.PrintIntro(); 

            DegreeSequence myDegreeSequence = new DegreeSequence(IO.GetInput());
            myDegreeSequence.Check();

            IO.GetKey();
        }
    }
}
