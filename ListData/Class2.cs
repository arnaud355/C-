﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ListData
{
	class CsvReader
	{
		private string _csvFilePath;

		public CsvReader(string csvFilePath)
		{
			this._csvFilePath = csvFilePath;
		}

		public List<Country> ReadAllCountries()
		{
			List<Country> countries = new List<Country>();

			using (StreamReader sr = new StreamReader(_csvFilePath))
			{
				// read header line
				sr.ReadLine();

				string csvLine;
				while ((csvLine = sr.ReadLine()) != null)
				{
					countries.Add(ReadCountryFromCsvLine(csvLine));
				}
			}

			return countries;
		}

		public void RemoveCommaCountries(List<Country> countries)
		{
			// This removes countries with commas using the RemoveAll() method
			// countries.RemoveAll(x => x.Name.Contains(','));

			// this removes countries with commas in a for loop (correctly, counting backwards)
			for (int i = countries.Count - 1; i >= 0; i--)
			{
				if (countries[i].Name.Contains(','))
					countries.RemoveAt(i);
			}
		}


		public Country ReadCountryFromCsvLine(string csvLine)
		{
			string[] parts = csvLine.Split(',');
			string name;
			string code;
			string region;
			string popText;
			switch (parts.Length)
			{
				case 4:
					name = parts[0];
					code = parts[1];
					region = parts[2];
					popText = parts[3];
					break;
				case 5:
					name = parts[0] + ", " + parts[1];
					name = name.Replace("\"", null).Trim();
					code = parts[2];
					region = parts[3];
					popText = parts[4];
					break;
				default:
					throw new Exception($"Can't parse country from csvLine: {csvLine}");
			}

			// TryParse leaves population=0 if can't parse
			int.TryParse(popText, out int population);
			return new Country(name, code, region, population);
		}


	}
}

