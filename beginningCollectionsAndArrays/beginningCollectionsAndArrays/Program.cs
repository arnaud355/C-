using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace beginningCollectionsAndArrays
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             //Creation array
             string[] daysOfWeek =
             {
                 "Monday",
                 "Tuesday",
                 "Wednesday",
                 "Thursday",
                 "Friday",
                 "Saturday",
                 "Friday"
             };

             foreach(string day in daysOfWeek)
             {
                 Console.WriteLine(day);
             }

             Console.WriteLine("Which day do you want to display?");
             Console.WriteLine("(Monday = 1, etc) > ");
             int iDay = int.Parse(Console.ReadLine());

             string chosenDay = daysOfWeek[iDay - 1];
             Console.WriteLine($"That day is {chosenDay}");
             */
            string filePath = @"C:\Users\arnaud.baleh\source\repos\beginningCollectionsAndArrays\Pop by Largest Final.csv";

          
            CsvReader reader = new CsvReader(filePath);
            //Country[] countries = reader.ReadFirstNCountries(10);
            List<Country> countries = reader.ReadAllCountries();
            Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            countries.Insert(lilliputIndex, lilliput);
            countries.RemoveAt(lilliputIndex);

            foreach (Country country in countries)
            {
                Console.WriteLine($"{country.Population}: {country.Name}");
            }
            Console.WriteLine($"{countries.Count} countries");
        }
    }
}
