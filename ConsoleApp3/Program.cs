using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\advent\input.txt");

            string oxygen = "", co2 = "";
            for(int i = 0; i < 12; i++)
            {
                int oxygenBit = 0;
                int co2Bit = 0;
                string oxygenCandidate = null;
                string co2Candidate = null;
                foreach (string line in lines)
                {
                    if (line.StartsWith(oxygen))
                    {
                        if(oxygenCandidate == null)
                        {
                            oxygenCandidate = line;
                        } else
                        {
                            oxygenCandidate = string.Empty;
                        }

                        if(line[i] == '1')
                        {
                            oxygenBit++;
                        } else
                        {
                            oxygenBit--;
                        }
                    }

                    if (line.StartsWith(co2))
                    {
                        if (co2Candidate == null)
                        {
                            co2Candidate = line;
                        }
                        else
                        {
                            co2Candidate = string.Empty;
                        }

                        if (line[i] == '1')
                        {
                            co2Bit++;
                        }
                        else
                        {
                            co2Bit--;
                        }
                    }
                }

                if(oxygen.Length < 12)
                {
                    if(!string.IsNullOrEmpty(oxygenCandidate))
                    {
                        oxygen = oxygenCandidate;
                    } else
                    {
                        if (oxygenBit >= 0)
                        {
                            oxygen += "1";
                        }
                        else
                        {
                            oxygen += "0";
                        }
                    }
                }
                
                if(co2.Length < 12)
                {
                    if(!string.IsNullOrEmpty(co2Candidate))
                    {
                        co2 = co2Candidate;
                    } else
                    {
                        if (co2Bit >= 0)
                        {
                            co2 += "0";
                        }
                        else
                        {
                            co2 += "1";
                        }
                    }
                }                
            }            

            var total = Convert.ToInt32(oxygen, 2) * Convert.ToInt32(co2, 2);
        }
    }
}
