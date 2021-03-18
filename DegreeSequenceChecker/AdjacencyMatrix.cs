using System;
using System.Collections.Generic;

namespace DegreeSequenceChecker
{
    public class AdjacencyMatrix
    {
        public readonly int[,] Matrix;

        public AdjacencyMatrix(List<int> degreeSequence)
        {
            Matrix = Parse(degreeSequence);
        }

        public void Print()
        {
            for (var i = 0; i < Matrix.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < Matrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(Matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private int[,] Parse(List<int> degreeSequence)
        {
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

            return adjacencyMatrix;
        }
    }
}
