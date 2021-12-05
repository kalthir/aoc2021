using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\advent\input.txt");

            string[] numbers = lines[0].Split(",");
            List<Card> listofCards = new List<Card>();
            Card c = new Card();
            for (int i = 1; i < lines.Length; i++)
            {
               if (i % 6 == 1)
                {
                    listofCards.Add(c);
                    c = new Card();
                    continue;
                }

                string[] line = lines[i].Replace("  ", " ").Trim().Split(" ");
                
                for(int j = 0; j < line.Length; j++)
                {
                    c.addNumber(int.Parse(line[j]), ((i - 2) % 6), j);
                }               
            }

            List<Card> winningboards = new List<Card>();
            for (int x = 0; x < numbers.Length; x++)
            {
                listofCards = listofCards.Except(winningboards).ToList();

                foreach(Card ca in listofCards)
                {
                    var ret = ca.callNumber(int.Parse(numbers[x]));
                    if (ret > -1)
                    {
                        winningboards.Add(ca);
                    }
                }                
            }

            var abc = winningboards.Last().getValue() * winningboards.Last().calledNumbers.Last();
        }

        class Card
        {
            public List<int> cardNumbers;
            public List<int> calledNumbers;
            public int[,] cardNumbersFormatted;

            public Card()
            {
                cardNumbers = new List<int>();
                calledNumbers = new List<int>();
                cardNumbersFormatted = new int[5,5] { { -1, -1,-1,-1,-1 }, { -1, -1,-1,-1,-1 }, { -1, -1,-1,-1,-1 }, { -1, -1,-1,-1,-1 }, { -1, -1,-1,-1,-1 } };         
            }

            public void addNumber(int number, int row, int column)
            {
                cardNumbers.Add(number);
                cardNumbersFormatted[column,row] = number;
            }

            public int callNumber(int number)
            {
                calledNumbers.Add(number);
                if (isBingo())
                {
                    return number * getValue();
                } else
                {
                    return -1;
                }
            }

            public int getValue()
            {
                return cardNumbers.Except(calledNumbers).Sum();
            }

            private bool isBingo()
            {
                bool retVal = true;

                for(int i = 0; i < 5; i++)
                {
                    retVal = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if(cardNumbersFormatted[i,j] == -1 || !calledNumbers.Contains(cardNumbersFormatted[i,j]))
                        {
                            retVal = false;
                            break;
                        }
                    }
                    if (retVal == true)
                        return true;

                    retVal = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (cardNumbersFormatted[j,i] == -1 || !calledNumbers.Contains(cardNumbersFormatted[j,i]))
                        {
                            retVal = false;
                            break;
                        }
                    }
                    if (retVal == true)
                        return true;
                }

                return false;
            }
        }
    }
}
