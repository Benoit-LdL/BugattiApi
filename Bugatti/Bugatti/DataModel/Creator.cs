using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bugatti
{
    public class Creator
    {
        //ALL PROPERTIES:
        // Id, FirstName, LastName, Cars, Birthday, BirthPlace, FirstNameDad, LastNameDad, FirstNameMom, LastNameMom

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Car> Cars { get; set; }

        public DateTime Birthday { get; set; }

        public Country BirthPlace { get; set; }

        public string FirstNameDad { get; set; }

        public string LastNameDad { get; set; }

        public string FirstNameMom { get; set; }

        public string LastNameMom { get; set; }

    }
}
