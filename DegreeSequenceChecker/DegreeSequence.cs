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
            degreeSequence = Parse(input);
            SortSequence(degreeSequence);
        }

        public bool Check()
        {
            var isGraphical = true;

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

            var sequence = new List<int>(degreeSequence);

            var adjacencyMatrix = new int[sequence.Count, sequence.Count];

            for (var i = 0; i < sequence.Count; i++)
            {
                var degreeToSubtract = sequence[i];

                sequence[i] = 0;

                var indexesUsed = new List<int>();
                while (degreeToSubtract > 0)
                {
                    var maxDegree = Int32.MinValue;
                    var maxDegreeIndex = 0;

                    for (var j = 0; j < sequence.Count; j++)
                    {
                        if (sequence[j] > maxDegree && !indexesUsed.Contains(j))
                        {
                            maxDegree = sequence[j];
                            maxDegreeIndex = j;
                        }
                    }

                    indexesUsed.Add(maxDegreeIndex);
                    sequence[maxDegreeIndex]--;
                    adjacencyMatrix[i, maxDegreeIndex] = 1;
                    adjacencyMatrix[maxDegreeIndex, i] = 1;
                    degreeToSubtract--;
                }

                /*
                for (var j = i; degreeToSubtract > 0 && j < sequence.Count; j++)
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
                */
            }

            Console.WriteLine("Adjacency Matrix:\n");
            for (var i = 0; i < sequence.Count; i++)
            {
                for (var j = 0; j < sequence.Count; j++)
                {
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private List<int> Parse(string input)
        {
            var degrees = input.Split(' ');
            var degreeSequence = new List<int>();

            foreach (var number in degrees)
            {
                var convertedNum = 0;

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
            var reducedSequence = new List<int>(degreeSequence);

            for (var i = 0; i < reducedSequence.Count; i++)
            {
                var degreeToSubtract = reducedSequence[0];

                reducedSequence[0] = 0;

                var index = 1;
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
            foreach (var degree in degreeSequence)
            {
                if (degree < 0)
                    return true;
            }
            
            return false;
        }

        private bool degreeSumIsEven()
        {
            var degreeSum = 0;

            foreach (var degree in degreeSequence)
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
            var reducedSequence = ReduceSequence(degreeSequence);

            foreach (var degree in reducedSequence)
            {
                if (degree != 0)
                    return false;
            }

            return true;
        }
    }
}
