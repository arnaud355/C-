using System;

namespace camelCase
{
    class Program
    {
        static string UppercaseFirst(string s,int pos)
        {
            
            char[] a = s.ToCharArray();
            a[pos] = char.ToUpper(a[pos]);
            return new string(a);
        }
        static void camelCase(string name)
        {
            int RawLength = name.Length;
          
            for(int i = RawLength - 1; i >= 0; i--)
            {
                if(name[i] == '-')
                {
                    
                    if (name[i + 1] != '-' && name[i + 1] != '\0')
                    {                       
                        name = UppercaseFirst(name,i + 1);
                    }
                    name = name.Remove(i,1);
                }
                
            }
            //Uppercase for the first letter
            name = UppercaseFirst(name, 0);
            Console.WriteLine(name);
         

        }
        static void Main(string[] args)
        {
            string name1 = "bonne-nouvelle-prime";
            string name2 = "age-utilisateur-moyenne";
            string name3 = "super-nouvelle-promotion";
          
            camelCase(name1);
            camelCase(name2);
            camelCase(name3);
        }
    }
}
