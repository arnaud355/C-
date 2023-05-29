// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, World!");

// Check if all alphabet letters are here
static bool IsPangram(string str)
{
    char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    string chaine = new string(alpha);
    chaine = chaine.ToLower();
    char[] alphaMinuscules = chaine.ToCharArray();
    bool nonPresent = true;
    int countAlpha = 0;
    str = str.ToLower();
    char[] tableauStr = str.ToCharArray();
  
    for (int i = 0; i < alphaMinuscules.Length; i++)
    {
        char c = alphaMinuscules[i];
        for (int j = 0; j < tableauStr.Length; j++)
        {
            if (c == tableauStr[j])
            {

                if (nonPresent)
                {
                    nonPresent = false;
                    countAlpha++;
                }
            }

        }
        nonPresent = true;
    }
    Console.WriteLine(countAlpha);
    if (countAlpha == 26)
    {
        return true;
    }

    return false;
}
// Return the unique number in order
static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
{
    //your code here...
    List<T> myList = new List<T>();
    foreach (T item in iterable)
    {
        if (!myList.Contains(item))
        {
            myList.Add(item);
        }
    }
    return myList;
}

/*Check if we can compose a word with str2 with the letters of str1, you need the same 
 quantity of the same letter
 */
static bool Scramble(string str1, string str2)
{
    // your code
    bool[] boolArray = new bool[str2.Length];
   
    bool equal = true;
    char[] charArrStr2 = str2.ToCharArray();
    int indexBoolArray = 0;
    char[] charArrStr1 = str1.ToCharArray();
    int eleNum = 0;
    Dictionary<char, int> DictStr2 = new Dictionary<char, int>();
    Dictionary<char, int> DictStr1 = new Dictionary<char, int>();

    string chaine = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    chaine = chaine.ToLower();
    char[] alphaMinuscules = chaine.ToCharArray();
    int countL = 0;

    foreach (char l in alphaMinuscules)
    {
        foreach(char ch2 in charArrStr2) 
        { 
            if(l == ch2 && !DictStr2.ContainsKey(l))
            {
                countL++;
            }
        }
        DictStr2.Add(l, countL);
        countL = 0;
    }

    foreach (KeyValuePair<char, int> item2 in DictStr2)
    {  
        if (item2.Value == 0)
        {
            DictStr2.Remove(item2.Key);
        }      
    }

    foreach (char l in alphaMinuscules)
    {
        foreach (char ch1 in charArrStr1)
        {
            if (l == ch1 && !DictStr1.ContainsKey(l))
            {
                countL++;
            }
        }
        DictStr1.Add(l, countL);
        countL = 0;
    }

    foreach (KeyValuePair<char, int> item1 in DictStr1)
    {
        if (item1.Value == 0)
        {
            DictStr1.Remove(item1.Key);
        }
    }

    foreach (KeyValuePair<char, int> item in DictStr1)
    {
        Console.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
    }
    
    foreach (KeyValuePair<char, int> item2 in DictStr2)
    {
        if(DictStr1.ContainsKey(item2.Key))
        {
            eleNum = DictStr1[item2.Key];
            
            if (eleNum >= item2.Value)
            {
                boolArray[indexBoolArray] = true;
                indexBoolArray++;               
            }
        }
    }           

    for (int v = 0; v < boolArray.Length; v++)
    {
        
        if (!boolArray[v])
        {
            equal = false;
        }
    }
    return equal;
}

//************************************************
bool pangram = false;
bool pangram2 = false;

pangram = IsPangram("The quick brown fox jumps over the lazy dog.");
pangram2 = IsPangram("The quick brown fox jumps over the lay dog.");
Console.WriteLine("Pangram: " + pangram);
Console.WriteLine(pangram2);

IEnumerable<char> listString = new List<char>();
listString = UniqueInOrder("AAAABBBCCDAABBB");
List<int> listInt = new List<int> { 1, 2, 2, 3, 4, 4, 4, 5, 5 };
IEnumerable<int> uniqueList = UniqueInOrder(listInt);

Console.WriteLine("List string: ABCD" + listString);
foreach (char c in listString)
{
    Console.WriteLine(c);
}
Console.WriteLine("List string:12345 " + uniqueList);
foreach (int i in uniqueList)
{
    Console.WriteLine(i);
}
//*********************

List<int> listEvenNumber = new List<int>();

for(int i = 0; i < 101; i++)
{
    if(i % 2 == 0)
    {
        listEvenNumber.Add(i);
    }
}

for (int i = 0; i < listEvenNumber.Count; i++)
{
    Console.WriteLine(listEvenNumber[i]);
}

for (int i = 0; i < 21; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("Fizzbuzz");
    }
    else if (i % 3 == 0 && i % 5 != 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (i % 3 != 0 && i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}


bool scram = Scramble("cedewaraaossoqqyt", "codewars");
Console.WriteLine(scram);
Console.WriteLine(Scramble("rkqodlw", "world"));
Console.WriteLine("zizou reponse F: ");
Console.WriteLine(Scramble("ggtgegtgngtgalolodizadxz", "zidane"));
Console.WriteLine(Scramble("katas", "steak"));
Console.WriteLine(Scramble("scriptjavx", "javascript"));
Console.WriteLine(Scramble("scriptingjava", "javascript"));
Console.WriteLine(Scramble("scriptsjava", "javascripts"));
Console.WriteLine(Scramble("javgsgtsgtscriptas", "javascript"));
