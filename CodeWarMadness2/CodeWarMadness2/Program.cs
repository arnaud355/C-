// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

/*
Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.

Examples
Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
Kata.PigIt("Hello world !");     // elloHay orldway !
*/
static string PigIt(string str)
{
   
    // Split separated by space
    string[] strArray = str.Split(" ");
    StringBuilder myStringBuilder = new StringBuilder("");
    char tmp = ' ';
    string strWordVar = "";
    int index = 0;
    string pattern = @"[^a-zA-Z0-9\s]";
    Regex rg = new Regex(pattern);

    string input = "Hello How are! you";
    string pattern4 = @"[^a-zA-Z0-9\s]"; // Recherche un caractère spécial (non alphabétique, non numérique et non un espace blanc)
    Regex rg4 = new Regex(pattern4);

    MatchCollection matches = Regex.Matches(input, pattern4);
    List<int> listMatch = new List<int>();

    foreach (Match match in matches)
    {
        Console.WriteLine("Caractère spécial trouvé : " + match.Value + "to index : " + match.Index + rg.IsMatch(match.Value));
    }
  

    foreach (string strWord in strArray)
    {
        tmp = strWord[0];
        strWordVar = strWord.Remove(0,1);
        MatchCollection matches2 = Regex.Matches(strWordVar, pattern);
        
            if (index < strArray.Length - 1)
            {
                myStringBuilder.Append(strWordVar + tmp + "ay" + " ");
            }
            else
            {
                myStringBuilder.Append(strWordVar + tmp + "ay");
            }           
        
        index++;
    }
         
    return myStringBuilder.ToString();
}

static string GoodVsEvil(string good, string evil)
{
    // Split string good by a comma followed by space
    string[] goodArr = good.Split(" ");
    string[] evilArr = evil.Split(" ");

    int[] goodArrInt = Array.ConvertAll(goodArr, s => int.Parse(s));
    int[] evilArrInt = Array.ConvertAll(evilArr, s => int.Parse(s));


    int countGood = 0;
    int countEvil = 0;


    foreach (int i in goodArrInt)
    {
        countGood = countGood + i;
    }

    foreach (int v in evilArrInt)
    {
        countEvil = countEvil + v;
    }
    Console.WriteLine(countGood);
    Console.WriteLine(countEvil);

    if (countGood > countEvil)
    {
        return "Battle Result: Good triumphs over Evil";
    }
    else if (countGood < countEvil)
    {
        return "Battle Result: Evil eradicates all trace of Good";
    }
    else
    {
        return "Battle Result: No victor on this battle field";
    }

}
//**************************************************************************************
string word = PigIt("Pig latin ! is cool");
string word2 = PigIt("This is my string");
string word3 = PigIt("This is my string !");

string refWord = "igPay atinlay siay oolcay";
string refWord2 = "hisTay siay ymay tringsay";


Console.WriteLine(word);
Console.WriteLine(word2);
Console.WriteLine(word3);

Console.WriteLine(GoodVsEvil("1 1 1 1 1 1", "1 1 1 1 1 1 1"));
Console.WriteLine(GoodVsEvil("0 0 0 0 0 10", "0 1 1 1 1 0 0"));