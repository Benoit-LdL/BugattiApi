using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bugatti
{
    public class Car
    {

        //ALL PROPERTIES:
        //  Id, Name, Creator, StartBuildYear, StopBuildYear, Countries, AvrgPrice, Horsepower, MaxSpeed, Torque, Weight, Prototype, WorldRecords, TotalBuilt, TotalRaceVictories, SmallDescription

        public int Id { get; set; }

        public string Name { get; set; }

        public Creator Creator { get; set; }

        public DateTime StartBuildYear { get; set; }

        public DateTime StopBuildYear { get; set; }

        public List<Car_Country_JoinTable> CountryList { get; set; }

        public float AvrgPrice { get; set; }

        public int Horsepower { get; set; }

        public int MaxSpeed { get; set; }

        public float Weight { get; set; }

        public bool Prototype { get; set; }

        public int TotalBuilt { get; set; }

        public int WorldRecords { get; set; }

        public int TotalRaceVictories { get; set; }

        public string SmallDescription { get; set; }

       
    }
}
