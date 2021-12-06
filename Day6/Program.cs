using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\advent\input.txt");
            List<long> lanternFish = lines[0].Split(",").Select(x => long.Parse(x)).ToList();
            long[] lanternFishArray = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach(int fish in lanternFish)
            {
                lanternFishArray[fish]++;
            }

            for(int i = 0; i < 256; i++)
            {
                long[] lanternFishArrayNew = new long[9];
                lanternFishArrayNew[0] = lanternFishArray[1];
                lanternFishArrayNew[1] = lanternFishArray[2];
                lanternFishArrayNew[2] = lanternFishArray[3];
                lanternFishArrayNew[3] = lanternFishArray[4];
                lanternFishArrayNew[4] = lanternFishArray[5];
                lanternFishArrayNew[5] = lanternFishArray[6];
                lanternFishArrayNew[6] = lanternFishArray[7] + lanternFishArray[0];
                lanternFishArrayNew[7] = lanternFishArray[8];
                lanternFishArrayNew[8] = lanternFishArray[0];

                lanternFishArray = lanternFishArrayNew;
            }

            var x = lanternFishArray.Sum();
        }
    }
}
