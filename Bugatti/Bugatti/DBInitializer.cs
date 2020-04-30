using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;

namespace Bugatti
{
    public class DBInitializer
    {
        public static void Initialize(BugattiContext context)
        {
            //---TEMPORARY FOR DEBUGGING---
            //Delete DB if it exists
            context.Database.EnsureDeleted();
            //-----------------------------
            //Create the DB if not yet exists
            context.Database.EnsureCreated();

            #region ---CREATORS---
            //ALL PROPERTIES:
            // Id, FirstName, LastName, Cars, Birthday, BirthPlace, FirstNameDad, LastNameDad, FirstNameMom, LastNameMom    


            if (!context.Creators.Any())
            {
                //create new Creators
                var ettore = new Creator()
                {
                    FirstName = "Ettore",
                    LastName = "Bugatti",
                    //cars =,
                    Birthday = new DateTime(1881, 9, 15),
                    FirstNameDad = "Carlo",
                    LastNameDad = "Bugatti",
                    FirstNameMom = "Teresa",
                    LastNameMom = "Lorioli"
                };
                var jean = new Creator()
                {
                    FirstName = "Jean",
                    LastName = "Bugatti",
                    //cars =,
                    Birthday = new DateTime(1909, 1, 15),
                    FirstNameDad = "Ettore",
                    LastNameDad = "Bugatti",
                    FirstNameMom = "Barbara",
                    LastNameMom = "Mascherpa"
                };
                var jozef = new Creator()
                {
                    FirstName = "Jozef",
                    LastName = "Kaban",
                    //cars =,
                    Birthday = new DateTime(1973, 1, 4),
                    FirstNameDad = "/",
                    LastNameDad = "/",
                    FirstNameMom = "/",
                    LastNameMom = "/"
                };
                var achim = new Creator()
                {
                    FirstName = "Achim",
                    LastName = "Anscheidt",
                    //cars =,
                    Birthday = new DateTime(1, 1, 1),
                    FirstNameDad = "/",
                    LastNameDad = "Anscheidt",
                    FirstNameMom = "/",
                    LastNameMom = "/"
                };
                var etienne = new Creator()
                {
                    FirstName = "Étienne",
                    LastName = "Salomé",
                    //cars =,
                    Birthday = new DateTime(1980, 9, 20),
                    FirstNameDad = "/",
                    LastNameDad = "Salomé",
                    FirstNameMom = "/",
                    LastNameMom = "/"
                };
                //add Creators to collection of Creators
                context.Creators.Add(ettore);
                context.Creators.Add(jean);
                context.Creators.Add(jozef);
                context.Creators.Add(achim);
                context.Creators.Add(etienne);
            }
            #endregion

            #region ---CARS---
            //ALL PROPERTIES:
            //  Id, Name, Creator, StartBuildYear, StopBuildYear, Countries, AvrgPrice, Horsepower, MaxSpeed, Weight, Prototype, WorldRecords, TotalBuilt, TotalRaceVictories, SmallDescription
            if (!context.Cars.Any())
            {
                var car1 = new Car()
                {
                    //id
                    Name = "Type 35",
                    //Creator = ,
                    StartBuildYear = new DateTime(1924, 1, 1),
                    StopBuildYear = new DateTime(1931, 1, 1),
                    //Countries = ,
                    AvrgPrice = 2500000,
                    Horsepower = 90,
                    MaxSpeed = 200,
                    Weight = 750,
                    Prototype = false,
                    WorldRecords = 0,
                    TotalBuilt = 38,
                    TotalRaceVictories = 2000,
                    SmallDescription = "..."
                };
                var car2 = new Car()
                {
                    //id
                    Name = "Type 41 Royale",
                    //Creator = ettore,
                    StartBuildYear = new DateTime(1926, 1, 1),
                    StopBuildYear = new DateTime(1933, 1, 1),
                    //Countries = ,
                    AvrgPrice = 9500000,
                    Horsepower = 300,
                    MaxSpeed = 205,
                    Weight = 3125,
                    Prototype = false,
                    WorldRecords = 1,
                    TotalBuilt = 8,
                    TotalRaceVictories = 0,
                    SmallDescription = "..."
                };
                var car3 = new Car()
                {
                    //id
                    Name = "Type 57 s/sc",
                    //Creator = jean,
                    StartBuildYear = new DateTime(1934, 1, 1),
                    StopBuildYear = new DateTime(1940, 1, 1),
                    //Countries = ,
                    AvrgPrice = 1400000,
                    Horsepower = 180,
                    MaxSpeed = 200,
                    Weight = 950,
                    Prototype = false,
                    WorldRecords = 0,
                    TotalBuilt = 685,
                    TotalRaceVictories = 0,
                    SmallDescription = "..."
                };
                var car4 = new Car()
                {
                    //id
                    Name = "Type 57 Aérolithe",
                    //Creator = jean,
                    StartBuildYear = new DateTime(1935, 1, 1),
                    StopBuildYear = new DateTime(1935, 1, 1),
                    //Countries = ,
                    AvrgPrice = 0,
                    Horsepower = 180,
                    MaxSpeed = 200,
                    Weight = 0,
                    Prototype = true,
                    WorldRecords = 0,
                    TotalBuilt = 1,
                    TotalRaceVictories = 0,
                    SmallDescription = "..."
                };
                var car5 = new Car()
                {
                    //id
                    Name = "Type 57 s(c) atlantic",
                    //Creator = jean,
                    StartBuildYear = new DateTime(1936, 1, 1),
                    StopBuildYear = new DateTime(1938, 1, 1),
                    //Countries = ,
                    AvrgPrice = 40000000,
                    Horsepower = 200,
                    MaxSpeed = 200,
                    Weight = 950,
                    Prototype = false,
                    WorldRecords = 1,
                    TotalBuilt = 4,
                    TotalRaceVictories = 0,
                    SmallDescription = "..."
                };
                var car6 = new Car()
                {
                    //id
                    Name = "veyron super sport",
                    //Creator = jozef,
                    StartBuildYear = new DateTime(2005, 1, 1),
                    StopBuildYear = new DateTime(2015, 1, 1),
                    //Countries = ,
                    AvrgPrice = 2000000,
                    Horsepower = 1200,
                    MaxSpeed = 431,
                    Weight = 1838,
                    Prototype = false,
                    WorldRecords = 1,
                    TotalBuilt = 30,
                    TotalRaceVictories = 0,
                    SmallDescription = "..."
                };
                var car7 = new Car()
                {
                    //id
                    Name = "chiron super sport",
                    //Creator = achim,
                    StartBuildYear = new DateTime(2019, 1, 1),
                    StopBuildYear = new DateTime(1, 1, 1),
                    //Countries = ,
                    AvrgPrice = 3500000,
                    Horsepower = 1500,
                    MaxSpeed = 490,
                    Weight = 1995,
                    Prototype = false,
                    WorldRecords = 1,
                    TotalBuilt = 30,
                    TotalRaceVictories = 0,
                    SmallDescription = "..."
                };
                var car8 = new Car()
                {
                    //id
                    Name = "La voiture noir",
                    //Creator = etienne,
                    StartBuildYear = new DateTime(2019, 1, 1),
                    StopBuildYear = new DateTime(1, 1, 1),
                    //Countries = ,
                    AvrgPrice = 16000000,
                    Horsepower = 1500,
                    MaxSpeed = 420,
                    Weight = 0,
                    Prototype = false,
                    WorldRecords = 1,
                    TotalBuilt = 1,
                    TotalRaceVictories = 0,
                    SmallDescription = "..."
                };
                //add car to collection of cars
                context.Cars.Add(car1);
                context.Cars.Add(car2);
                context.Cars.Add(car3);
                context.Cars.Add(car4);
                context.Cars.Add(car5);
                context.Cars.Add(car6);
                context.Cars.Add(car7);
                context.Cars.Add(car8);
            }
            #endregion

            #region ---COUNTRIES---
            if (!context.Countries.Any())
            {

                var country1 = new Country()
                {
                    //id
                    Name = "Italy",
                    //CreatorList = ,
                    //CarList = ,
                    InEU = true
                };
                var country2 = new Country()
                {
                    //id
                    Name = "France",
                    //CreatorList = ,
                    //CarList = ,
                    InEU = true
                };
                var country3 = new Country()
                {
                    //id
                    Name = "Germany",
                    //CreatorList = ,
                    //CarList = ,
                    InEU = true
                };
                //add country to collection of countries
                context.Countries.Add(country1);
                context.Countries.Add(country2);
                context.Countries.Add(country3);
                //save all the changes to the DB
                context.SaveChanges();
            }
            
            #endregion
        }
    }
}
