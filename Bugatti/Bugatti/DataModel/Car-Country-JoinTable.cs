using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bugatti
{
    public class Car_Country_JoinTable
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
