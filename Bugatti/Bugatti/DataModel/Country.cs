using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bugatti
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool InEU { get; set; }

        public List<Car_Country_JoinTable> CarList { get; set; }

        public List<Creator> CreatorList { get; set; }


    }
}
