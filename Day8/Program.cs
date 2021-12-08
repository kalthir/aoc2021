using System;
using System.Collections.Generic;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\advent\input.txt");
            int counter = 0;
            int sum = 0;
            int[] digits = new int[] { 1, 4, 7, 8 };
            foreach(string line in lines)
            {
                Dictionary<string, int> stringToInt = new Dictionary<string, int>();

                string[] patterns = line.Split("|")[0].Trim().Split(" ").Select(x => String.Concat(x.OrderBy(y =>y))).OrderBy(x => x.Length).ToArray();
                string[] output = line.Split("|")[1].Trim().Split(" ").Select(x => String.Concat(x.OrderBy(y => y))).ToArray();

                string one = patterns[0];
                stringToInt.Add(one, 1);

                string seven = patterns[1];
                stringToInt.Add(seven, 7);

                string four = patterns[2];
                stringToInt.Add(four, 4);

                string eight = patterns.Last();
                stringToInt.Add(eight, 8);

                var three = patterns.Single(x => x.Length == 5 && x.Contains(one[0]) && x.Contains(one[1]));
                stringToInt.Add(three, 3);

                var five = patterns.Single(x => x.Length == 5 && x.Except(four).Count() == 2 && x != three);
                stringToInt.Add(five, 5);

                var two = patterns.Single(x => x.Length == 5 && x != three && x != five);
                stringToInt.Add(two, 2);

                var nine = patterns.Single(x => x.Length == 6 && x.Except(four).Count() == 2);
                stringToInt.Add(nine, 9);

                var zero = patterns.Single(x => x.Length == 6 && x.Intersect(seven).Count() == 3 && x != nine);
                stringToInt.Add(zero, 0);

                var six = patterns.Single(x => x.Length == 6 && x != nine && x != zero);
                stringToInt.Add(six, 6);

                var localSum = 0;
                foreach(var outputDigit in output)
                {
                    localSum = localSum * 10 + stringToInt[outputDigit];
                    if (digits.Contains(stringToInt[outputDigit]))
                        counter++;
                }

                sum += localSum;
            }
        }
    }
}
