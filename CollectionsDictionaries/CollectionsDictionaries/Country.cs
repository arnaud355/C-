using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionsDictionaries
{
    class Country
    {
        public string Name { get; }
        public string Code { get; }
        public string Region { get; }
        public int Population { get; }

        public Country(string name, string code, string region, int population)
        {
            this.Name = name;
            this.Code = code;
            this.Region = region;
            this.Population = population;
        }
    }
}


