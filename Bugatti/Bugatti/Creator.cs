using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bugatti
{
    public class Creator
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Car> Cars { get; set; }

        //public DateTime Birthday { get; set; }

        //public int Age { get; set; }

        //public string BirthPlace { get; set; }

        //public string Mothertongue { get; set; }

        //public string NameDad { get; set; }

        //public string NameMom { get; set; }

    }
}
