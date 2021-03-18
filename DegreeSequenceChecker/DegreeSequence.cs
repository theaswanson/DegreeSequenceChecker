using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DegreeSequenceChecker
{
    public class DegreeSequence
    {
        public readonly List<int> Sequence;
        public readonly List<string> Errors;
        public readonly AdjacencyMatrix AdjacencyMatrix;
        public bool IsGraphical => !Errors.Any();

        public DegreeSequence(string input)
        {
            Sequence = Parse(input);
            SortSequence(Sequence);
            Errors = GetErrors(Sequence);
            if (!Errors.Any())
            {
                AdjacencyMatrix = new AdjacencyMatrix(Sequence);
            }
            else
            {
                AdjacencyMatrix = null;
            }
        }

        private List<string> GetErrors(List<int> degreeSequence)
        {
            var errors = new List<string>();

            if (ContainsNegativeDegrees(degreeSequence))
                errors.Add("Contains negative degrees.");

            if (!DegreeSumIsEven(degreeSequence))
                errors.Add("The sum of the degrees is not even.");

            if (!GreatestDegreeIsGood(degreeSequence))
                errors.Add("The greatest degree is too large.");

            if (!PassesAlgorithm(degreeSequence))
                errors.Add("Does not pass the Degree Sequence Algorithm.");

            return errors;
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

        private bool ContainsNegativeDegrees(List<int> degreeSequence)
        {
            return degreeSequence.Any(x => x < 0);
        }

        private bool DegreeSumIsEven(List<int> degreeSequence)
        {
            return degreeSequence.Sum() % 2 == 0;
        }

        private bool GreatestDegreeIsGood(List<int> degreeSequence)
        {
            return !(degreeSequence[0] > degreeSequence.Count);
        }

        private bool PassesAlgorithm(List<int> degreeSequence)
        {
            var reducedSequence = ReduceSequence(degreeSequence);
            return !reducedSequence.Any(x => x != 0);
        }
    }
}
