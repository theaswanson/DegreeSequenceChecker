using System;
using System.Collections.Generic;
using System.Text;

namespace DegreeSequenceChecker
{
    public class DegreeSequence
    {
        List<int> degreeSequence;

        public DegreeSequence()
        {
            degreeSequence = new List<int>();
        }

        public DegreeSequence(string input)
        {
            degreeSequence = GetSequenceFromString(input);
            SortSequence(degreeSequence);
        }

        public bool Check()
        {
            bool isGraphical = true;

            if (containsNegativeDegrees())
            {
                Console.WriteLine("This sequence is not graphical because contains negative degrees.");
                isGraphical = false;
            }

            if (!degreeSumIsEven())
            {
                Console.WriteLine("This sequence is not graphical because the sum of the degrees is not even.");
                isGraphical = false;
            }

            if (!greatestDegreeIsGood())
            {
                Console.WriteLine("This sequence is not graphical because the greatest degree is too large.");
                isGraphical = false;
            }

            if (!passesAlgorithm())
            {
                Console.WriteLine("This sequence is not graphical because it does not pass the Degree Sequence Algorithm.");
                isGraphical = false;
            }

            if (isGraphical)
            {
                Console.WriteLine("This sequence is graphical.");
                return true;
            }
            else
                return false;
                
        }

        public void Draw()
        {
            if (!Check())
                return;

            List<int> sequence = new List<int>(degreeSequence);

            int[,] adjacencyMatrix = new int[sequence.Count, sequence.Count];

            for (int i = 0; i < sequence.Count; i++)
            {
                int degreeToSubtract = sequence[i];

                sequence[i] = 0;

                for (int j = i; degreeToSubtract > 0 && j < sequence.Count; j++)
                {
                    if (i == j)
                        adjacencyMatrix[i, i] = 0;
                    else if (sequence[j] > 0)
                    {
                        sequence[j]--;
                        adjacencyMatrix[i, j] = 1;
                        adjacencyMatrix[j, i] = 1;
                        degreeToSubtract--;
                    }
                    else
                    {
                        adjacencyMatrix[i, j] = 0;
                    }
                }
            }

            Console.WriteLine("Adjacency Matrix:\n");
            for (int i = 0; i < sequence.Count; i++)
            {
                for (int j = 0; j < sequence.Count; j++)
                {
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private List<int> GetSequenceFromString(string input)
        {
            string[] degrees = input.Split(' ');

            List<int> degreeSequence = new List<int>();

            foreach (string number in degrees)
            {
                int convertedNum = 0;

                if (Int32.TryParse(number, out convertedNum))
                    degreeSequence.Add(convertedNum);
            }

            return degreeSequence;
        }

        private void SortSequence(List<int> sequence)
        {
            sequence.Sort();
            sequence.Reverse();
        }
                
        private List<int> ReduceSequence(List<int> degreeSequence)
        {
            List<int> reducedSequence = new List<int>(degreeSequence);

            for (int i = 0; i < reducedSequence.Count; i++)
            {
                int degreeToSubtract = reducedSequence[0];

                reducedSequence[0] = 0;

                int index = 1;
                while (degreeToSubtract > 0 && index < reducedSequence.Count)
                {
                    reducedSequence[index]--;
                    degreeToSubtract--;
                    index++;
                }

                SortSequence(reducedSequence);
            }

            return reducedSequence;
        }

        private bool containsNegativeDegrees()
        {
            foreach (int degree in degreeSequence)
            {
                if (degree < 0)
                    return true;
            }
            
            return false;
        }

        private bool degreeSumIsEven()
        {
            int degreeSum = 0;

            foreach (int degree in degreeSequence)
                degreeSum += degree;

            if (degreeSum % 2 == 0)
                return true;
            else
                return false;
                
        }

        private bool greatestDegreeIsGood()
        {
            if (degreeSequence[0] <= degreeSequence.Count - 1)
                return true;
            else
                return false;
                
        }

        private bool passesAlgorithm()
        {
            List<int> reducedSequence = ReduceSequence(degreeSequence);

            foreach (int degree in reducedSequence)
            {
                if (degree != 0)
                    return false;
            }

            return true;
        }
    }
}
