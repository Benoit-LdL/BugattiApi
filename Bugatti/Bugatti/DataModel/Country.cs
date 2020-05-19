using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bugatti
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        public bool InEU { get; set; }

        public List<Car_Country_JoinTable> CarList { get; set; }

        public List<Creator> CreatorList { get; set; }


    }
}
