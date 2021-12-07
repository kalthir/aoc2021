using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\advent\input.txt");
            List<int> crabPositions = lines[0].Split(",").Select(x => int.Parse(x)).ToList();
            int position = (int)Math.Ceiling(crabPositions.Average());
            int minFuel = -1;
            for(int i = 0; i < crabPositions.Max(); i ++)
            {
                int fuel = 0;
                foreach (var crabPosition in crabPositions)
                {
                    fuel += calculateFuel(Math.Abs(i - crabPosition));
                }
                
                if(minFuel == -1 || fuel < minFuel)
                {
                    minFuel = fuel;
                }
            }
            
        }

        private static int calculateFuel(int distance)
        {
            int fuel = 0;
            int cost = 1;

            for(int i = 1; i <= distance; i++)
            {
                fuel += cost;
                cost++;
            }

            return fuel;
        }
    }
}
