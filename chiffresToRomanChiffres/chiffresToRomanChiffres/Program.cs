using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace chiffresToRomanChiffres
{
    class Program
    {
        static string ComparatorModulo(string numberString)
        {
            int inputChiffre = Convert.ToInt32(numberString);
            int restant = inputChiffre;
            bool iteration = true;
            float divisibleF = 0;
            int divisible = 0;
            List<string> RomanLetters = new List<string>();

            while (iteration)
            {
                
                if(restant >= 1000)
                {
                    if (restant == 1000)
                    {
                        RomanLetters.Add("M");
                        restant = 0;
                    }
                    else
                    {
                        divisibleF = restant / 1000;
                        divisible = Convert.ToInt32(Math.Round(divisibleF));
                        for(int i = 0;i < divisible;i++)
                        {
                            RomanLetters.Add("M");
                        }
                       
                        restant = restant % 1000;
                    }
                }
                if (restant < 1000 && restant >= 500)
                {
                    if (restant == 500)
                    {
                        RomanLetters.Add("D");
                        restant = 0;
                        
                    }
                    else
                    {
                        divisibleF = restant / 500;
                        divisible = Convert.ToInt32(Math.Round(divisibleF));
                        for (int i = 0; i < divisible; i++)
                        {
                            RomanLetters.Add("D");
                        }
                        restant = restant % 500;
                    }
                }
                if (restant < 500 && restant >= 100)
                {
                    if (restant == 100)
                    {
                        RomanLetters.Add("C");
                        
                        restant = 0;
                    }
                    else
                    {
                        divisibleF = restant / 100;
                        divisible = Convert.ToInt32(Math.Round(divisibleF));
                        for (int i = 0; i < divisible; i++)
                        {
                            RomanLetters.Add("C");
                        }
                        restant = restant % 100;
                    }
                }
                if (restant < 100 && restant >= 50)
                {
                    if (restant == 50)
                    {
                        RomanLetters.Add("L");
                        restant = 0;         
                        
                    }
                    else
                    {
                        divisibleF = restant / 50;
                        divisible = Convert.ToInt32(Math.Round(divisibleF));
                        for (int i = 0; i < divisible; i++)
                        {
                            RomanLetters.Add("L");
                        }
                        restant = restant % 50;
                    }
                }
                if (restant < 50 && restant >= 10)
                {
                    if (restant == 10)
                    {
                        RomanLetters.Add("X");
                       
                        restant = 0;
                    }
                    else
                    {
                        divisibleF = restant / 10;
                        divisible = Convert.ToInt32(Math.Round(divisibleF));
                        for (int i = 0; i < divisible; i++)
                        {
                            RomanLetters.Add("X");
                        }
                        restant = restant % 10;
                    }
                }
                if (restant < 10 && restant >= 5)
                {
                    if(restant == 9)
                    {
                        RomanLetters.Add("IX");

                        restant = 0;
                    }
                    else if (restant == 5)
                    {
                        RomanLetters.Add("V");
                       
                        restant = 0;
                    }
                    else
                    {
                        divisibleF = restant / 5;
                        divisible = Convert.ToInt32(Math.Round(divisibleF));
                        for (int i = 0; i < divisible; i++)
                        {
                            RomanLetters.Add("V");
                        }
                        restant = restant % 5;
                    }
                }
                if (restant < 5 && restant >= 1)
                {
                    if (restant == 1)
                    {
                        RomanLetters.Add("I");
                        
                        restant = 0;
                    }
                    else if (restant == 4)
                    {
                        RomanLetters.Add("IV");

                        restant = 0;
                    }
                    else
                    {
                        divisibleF = restant / 1;
                        divisible = Convert.ToInt32(Math.Round(divisibleF));
                        for (int i = 0; i < divisible; i++)
                        {
                            RomanLetters.Add("I");
                        }
                        restant = restant % 1;
                    }
                }
                if (restant <= 0)
                {
                    iteration = false;
                }
            }

            //string romanNumber = RomanLetters.ToString();
            string romanNumber = string.Join("", RomanLetters);
            return romanNumber;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number to convert to Roman number: ");
            string inputChiffre = Console.ReadLine();
            
            var dictionaryRomanLetter = new Dictionary<string, int>();
            dictionaryRomanLetter.Add("I", 1);
            dictionaryRomanLetter.Add("V", 5);
            dictionaryRomanLetter.Add("X", 10);
            dictionaryRomanLetter.Add("L", 50);
            dictionaryRomanLetter.Add("C", 100);
            dictionaryRomanLetter.Add("D", 500);
            dictionaryRomanLetter.Add("M", 1000);

            string RomanLetters = "";

            /*
            // Loop over pairs with foreach.
            foreach (KeyValuePair<string, int> pair in dictionaryRomanLetter)
            {
                Console.WriteLine("Matchboard : {0}, {1}", pair.Key, pair.Value);
            }*/
           
            
            RomanLetters = ComparatorModulo(inputChiffre);

            Console.WriteLine(RomanLetters);
           
       
        }
    }
}
