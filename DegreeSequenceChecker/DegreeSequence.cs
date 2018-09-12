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
            SortSequence();
        }

        public void Check()
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
                Console.WriteLine("This sequence is graphical.");
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

        private void SortSequence()
        {
            degreeSequence.Sort();
            degreeSequence.Reverse();
        }
                
        private void ReduceSequence()
        {
            for (int i = 0; i < degreeSequence.Count - 1; i++)
            {
                int degreeToSubtract = degreeSequence[0];

                degreeSequence[0] = 0;

                int index = 1;
                while (degreeToSubtract > 0)
                {
                    degreeSequence[index]--;
                    degreeToSubtract--;
                    index++;
                }

                SortSequence();
            }
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
            ReduceSequence();

            foreach (int degree in degreeSequence)
            {
                if (degree != 0)
                    return false;
                    
            }

            return true;
        }
    }
}
