using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            Country finland = new Country("Finland", "FIN", "Europe", 5_282_223);
            //Like T list, Dictionary start as empty
            //Dictionary<string, Country> countriesDict = new Dictionary<string, Country>();

            //Other way to declare: Le type var is generic, the compiler wil take the fittest
            var countriesDict = new Dictionary<string, Country>();
            //countries.Add("NOR", norway);
            //countries.Add("FIN", finland);

            //Other way to declare:
            countriesDict.Add(norway.Code, norway);
            countriesDict.Add(finland.Code, finland);

            Country selectedCountry = countriesDict["NOR"];
            // Console.WriteLine(selectedCountry.Name);
            // .Values for have the value for an key of the dictionary. A key is always unique
            foreach (var countryD in countriesDict.Values)
                Console.WriteLine(countryD.Name);

            Country england = new Country("England", "ENG", "Europe", 56_000_000);
            Country germany = new Country("Germany", "GER", "Europe", 82_000_000);

            var countriesDict2 = new Dictionary<string, Country>
            {
                {england.Code,england },
                {germany.Code,germany }
            };

            foreach (var item in countriesDict2)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    item.Key, item.Value);
            }

            foreach (var countryD in countriesDict2.Values)
                Console.WriteLine(countryD.Code);

            //Console.WriteLine(countriesDict2["MUS"].Name);
            bool exists = countriesDict2.TryGetValue("MUS", out Country country);
            if (exists)
                Console.WriteLine(country.Name);
            else
                Console.WriteLine("There is no country with the code MUS");


            string filepath = @"C:\Users\arnaud.baleh\source\repos\beginningCollectionsAndArrays\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filepath);
            Dictionary<string, Country> countriesDict3 = reader.ReadAllCountries();

            Console.WriteLine("Which country code do you want to look up?");
            string userInput = Console.ReadLine();

            //I can't rely on user input, hence I use TryGetValue
            bool gotCountry = countriesDict3.TryGetValue(userInput, out Country countryV);
            if (!gotCountry)
                Console.WriteLine($"Sorry, there is no country with code, {userInput}");
            else
                Console.WriteLine($"{countryV.Name} has population {countryV.Population}");
        }

        List<Country> countriesList = reader.ReadAllCountries();


        Console.Write("Enter no. of countries to display> ");
        bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
        if(!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must type in a +ve integer. exiting");
                return;
            }

    int maxToDisplay = userInput;
			for (int i = 0; i< countriesList.Count; i++)
			{
				if (i > 0 && (i % maxToDisplay == 0))
				{
					Console.WriteLine("Hit return to continue, anything else to quit>");
					if (Console.ReadLine() != "")
						break;
				}
                Country country = countriesList[i];
                Console.WriteLine($"{i + 1}: {countryList.Population}");
            }
}           
        
}
