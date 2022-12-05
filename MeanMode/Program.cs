using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading;

namespace MeanMode
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public static bool MeanMode(int[] array)
        {
            return computeMode(array) == computeAverage(array);
        }

        // TODO
        private static double computeAverage(int[] array)
        {
            double sum = 0;

            foreach (var i in array)
            {
                sum += i;
            }

            double mean = sum / array.Length;
            return mean;
        }

        // TODO
        private static double? computeMode(int[] array)
        {
            var numberCounts = new Dictionary<double, double>();

            //placeholders for future usage
            double max_value = 0;
            double max_key = 0;

            //initial value for new words added to dictionary
            double initial = 1;

            foreach (var number in array)
            {
                // Will check if the dictionary has the key already. This potentially qualifies for a mode.
                if (numberCounts.ContainsKey(number))
                {
                    numberCounts[number] = numberCounts[number] + 1;

                    //Replaces the previous top maximum value and key with the current one.
                    if (numberCounts[number] > max_value)
                    {
                        max_value = numberCounts[number];
                        max_key = number;
                    }

                    continue;
                }

                numberCounts.Add(number, initial);
            }

            return max_key; //return mode
        }
    }
}
   