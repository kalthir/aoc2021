using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\advent\input_2_1.txt");

            long x = 0, y = 0, z = 0;
            foreach(string line in lines)
            {
                string[] commands = line.Split(' ');
                switch (commands[0])
                {
                    case "forward":
                        x += long.Parse(commands[1]);
                        y += z * long.Parse(commands[1]);
                        break;
                    case "down":                       
                        z += long.Parse(commands[1]);
                        break;
                    case "up":                       
                        z -= long.Parse(commands[1]);                        
                        break;
                }
            }

            var total = x * y;
        }
    }
}
