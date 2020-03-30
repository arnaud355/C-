using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MongoDB.Bson;
//using MongoDB.Driver;

namespace ListData
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"C:\Users\arnaud.baleh\source\repos\beginningCollectionsAndArrays\Pop by Largest Final.csv";
			CsvReader reader = new CsvReader(filePath);

			//List<Country> countries = reader.ReadAllCountries();
			Dictionary<string, List<Country>> countries = reader.ReadAllCountries();
			
			foreach(string region in countries.Keys)
			{
				Console.WriteLine(region);
			}

			Console.WriteLine("Which of the above region do you want ?");
			string chosenRegion = Console.ReadLine();

			if(countries.ContainsKey(chosenRegion))
			{

				foreach (Country country in countries[chosenRegion].Take(10))
				{
					Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
				}
			}
			else	
			{
				Console.WriteLine("This is not a valid region");
			}

			//***Start of LINQ section***
			/*
			 foreach(Country country in countries.OrderBy(Name))
			 does not work, you need a delegate or lambda
			 
			It s work:
			foreach (Country country in countries.OrderBy(x=>x.Name).Take(10))
			 */
			 /*
			var filteredCountries = countries.Where(x => !x.Name.Contains(',')).Take(20);

			//Equivalent:
			var filteredCountries2 = from country in countries
									 where !country.Name.Contains(',')
									 select country;
	

			foreach (Country country in filteredCountries2)
			{
				Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
			}
			*/
			//***End of LINQ section***

			/*
			// comment this out to see all countries, without removing the ones with commas
			reader.RemoveCommaCountries(countries);

			Console.Write("Enter no. of countries to display> ");
			bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
			if (!inputIsInt || userInput <= 0)
			{
				Console.WriteLine("You must type in a +ve integer. Exiting");
				return;
			}

			int maxToDisplay = userInput;
			//for (int i = 0; i < countries.Count; i++)
			//When use for loop from the end ? for delete item in index, it s avoid to pass on some items
			for(int i = countries.Count - 1;i >= 0;i--)
			{
				int displayIndex = countries.Count - 1 - i;
				if (displayIndex > 0 && (displayIndex % maxToDisplay == 0))
				{
					Console.WriteLine("Hit return to continue, anything else to quit>");
					if (Console.ReadLine() != "")
						break;
				}

				Country country = countries[i];
				Console.WriteLine($"{displayIndex + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
			}*/
		}
	}
}

