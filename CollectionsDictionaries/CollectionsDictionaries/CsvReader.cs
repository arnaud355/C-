﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDictionaries
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }
        

        public Dictionary<string, Country> ReadAllCountries()
        {
            var countriesDict = new Dictionary<string, Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //read header line
                sr.ReadLine();


                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    Country countryDict = ReadCountryFromCsvLine(csvLine);
                    countriesDict.Add(countryDict.Code,countryDict);
                }


            }
            return countriesDict;
        }
        
     
        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            string name;
            string code;
            string region;
            string populationText;

            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    populationText = parts[3];
                    break;
                case 5:
                    name = parts[0] + "," + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    populationText = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }
            //TryParse leaves population=0 if can't parse
            int.TryParse(populationText, out int population);
            return new Country(name, code, region, population);
        }
    }

}

