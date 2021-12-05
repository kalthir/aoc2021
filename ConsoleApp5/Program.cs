using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\advent\input.txt");
            List<Line> lineLines = new List<Line>();

            foreach (var line in lines)
            {
                var points = line.Replace(" -> ", ",").Split(",").Select(x => int.Parse(x)).ToArray();
                //if (points[0] == points[2] || points[1] == points[3])
                //{
                    lineLines.Add(new Line(points[0], points[1], points[2], points[3]));
                //}      
            }

            var group = lineLines.SelectMany(x => x.points).GroupBy(x => x).Select(x => new { Key = x.Key, Count = x.Count() });
            var z = group.Where(x => x.Count > 1).Count();
        }

        public class Line {

            public List<Tuple<int, int>> points;

            public Line(int x1, int y1, int x2, int y2)
            {
                points = new List<Tuple<int, int>>();
                points.Add(Tuple.Create(x1, y1));

                while(x1 != x2 || y1 != y2)
                {
                    if(x1 > x2)
                    {
                        x1--;
                    } else if (x1 < x2)
                    {
                        x1++;
                    }

                    if(y1 > y2)
                    {
                        y1--;
                    } else if (y1 < y2)
                    {
                        y1++;
                    }

                    points.Add(Tuple.Create(x1, y1));
                }
            }

        }
    }
}
