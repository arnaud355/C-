using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class StringHandler
    {
        /*A static class have static methods, no instances can't be create
         * It's a sealed class, hence no inheritage possible.
         * you call methods static for a static class, with nameOfStaticClass.HerMethod();
        */
        
        /*For have an extension method, you need a static class, an extension method
        can be call directly by an instance of others classes, rather than write
        the name of the static class and the name of the extension method.
        you need to add this for the parameter, for point from address object to the instance of some class*/

        /*
         * extension method or static method:
         * is the primary parameter an instance ?
         * instance of a string for example
         * does the method operate logicaly on that instance ?
         * is it desirable for the method to appear in intelliSence for that type ?
         * 
         * If yes for the 3 it preferable extension method
         */

        //Inserts spaces before each capital letter in a string
        public static string InsertSpaces(this string source)
        {
            string result = string.Empty;

            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach(char letter in source)
                {
                    if (Char.IsUpper(letter))
                    {
                        //Trim any spaces already there
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }
            }
            //Trim method delete space at the beginning and the and of sentence
            result = result.Trim();
            return result;
        }
    }
}
