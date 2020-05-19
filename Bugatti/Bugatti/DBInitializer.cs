using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bugatti.Controllers;
using Microsoft.AspNetCore.Mvc;
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

            //Cars
            Car t35 = null, t41 = null, t57 = null, aero = null, atl = null, veyr = null, chir = null, noire = null;
            //Creators
            Creator jean = null, ettore = null, jozef = null, achim = null, etienne = null;
            //countries
            Country italy = null, france = null, germany = null;
            //car countries
            Car_Country_JoinTable atl_FR = null, atl_DE = null;

            #region ---CREATORS---
            //ALL PROPERTIES:
            // Id, FirstName, LastName, Cars, Birthday, BirthPlace, FirstNameDad, LastNameDad, FirstNameMom, LastNameMom    
            if (!context.Creators.Any())
            {
                //create new Creators
                ettore = new Creator()
                {
                    FirstName = "Ettore",
                    LastName = "Bugatti",
                    //cars =,
                    Birthday = new DateTime(1881, 9, 15),
                    BirthPlace = italy,
                    FirstNameDad = "Carlo",
                    LastNameDad = "Bugatti",
                    FirstNameMom = "Teresa",
                    LastNameMom = "Lorioli"
                };
                jean = new Creator()
                {
                    FirstName = "Jean",
                    LastName = "Bugatti",
                    //cars =,
                    Birthday = new DateTime(1909, 1, 15),
                    BirthPlace = france,
                    FirstNameDad = "Ettore",
                    LastNameDad = "Bugatti",
                    FirstNameMom = "Barbara",
                    LastNameMom = "Mascherpa"
                };
                jozef = new Creator()
                {
                    FirstName = "Jozef",
                    LastName = "Kaban",
                    //cars =,
                    Birthday = new DateTime(1973, 1, 4),
                    BirthPlace = germany,
                    FirstNameDad = "/",
                    LastNameDad = "/",
                    FirstNameMom = "/",
                    LastNameMom = "/"
                };
                achim = new Creator()
                {
                    FirstName = "Achim",
                    LastName = "Anscheidt",
                    //cars =,
                    Birthday = new DateTime(1, 1, 1),
                    BirthPlace = germany,
                    FirstNameDad = "/",
                    LastNameDad = "Anscheidt",
                    FirstNameMom = "/",
                    LastNameMom = "/"
                };
                etienne = new Creator()
                {
                    FirstName = "Étienne",
                    LastName = "Salomé",
                    //cars =,
                    Birthday = new DateTime(1980, 9, 20),
                    BirthPlace = france,
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
                //save all the changes to the DB
                context.SaveChanges();
            }
            #endregion

            #region ---CARS---
            //ALL PROPERTIES:
            //  Id, Name, Creator, StartBuildYear, StopBuildYear, Countries, AvrgPrice, Horsepower, MaxSpeed, Weight, Prototype, WorldRecords, TotalBuilt, TotalRaceVictories, SmallDescription

            if (!context.Cars.Any())
            {
                t35 = new Car()
                {
                    //id
                    Name = "Type 35",
                    Creator = ettore,
                    StartBuildYear = new DateTime(1924, 1, 1),
                    StopBuildYear = new DateTime(1931, 1, 1),
                    //Countries = List<Country>(france, italy);
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
                t41 = new Car()
                {
                    //id
                    Name = "Type 41 Royale",
                    Creator = ettore,
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
                t57 = new Car()
                {
                    //id
                    Name = "Type 57 s/sc",
                    Creator = jean,
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
                aero = new Car()
                {
                    //id
                    Name = "Type 57 Aérolithe",
                    Creator = jean,
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
                atl = new Car()
                {
                    //id
                    Name = "Type 57 s(c) atlantic",
                    Creator = jean,
                    StartBuildYear = new DateTime(1936, 1, 1),
                    StopBuildYear = new DateTime(1938, 1, 1),
                    //CountryList = tempList,
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
                veyr = new Car()
                {
                    //id
                    Name = "veyron super sport",
                    Creator = jozef,
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
                chir = new Car()
                {
                    //id
                    Name = "chiron super sport",
                    Creator = achim,
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
                noire = new Car()
                {
                    //id
                    Name = "La voiture noir",
                    Creator = etienne,
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
                context.Cars.Add(t35);
                context.Cars.Add(t41);
                context.Cars.Add(t57);
                context.Cars.Add(aero);
                context.Cars.Add(atl);
                context.Cars.Add(veyr);
                context.Cars.Add(chir);
                context.Cars.Add(noire);
                //save all the changes to the DB
                context.SaveChanges();
            }
            #endregion

            

            #region ---COUNTRIES---

            if (!context.Countries.Any())
            {

                italy = new Country()
                {
                    //id
                    Name = "Italy",
                    //CreatorList = ,
                    //CarList = ,
                    InEU = true
                };
                france = new Country()
                {
                    //id
                    Name = "France",
                    //CreatorList = ,
                    //CarList = ,
                    InEU = true
                };
                germany = new Country()
                {
                    //id
                    Name = "Germany",
                    //CreatorList = ,
                    //CarList = ,
                    InEU = true
                };
                //add country to collection of countries
                context.Countries.Add(italy);
                context.Countries.Add(france);
                context.Countries.Add(germany);
                //save all the changes to the DB
                context.SaveChanges();
            }
            #endregion

            #region ---CAR-COUNTRIES---

            if (!context.CarCountries.Any())
            {
                atl_FR = new Car_Country_JoinTable()
                {
                    CarId = atl.Id,
                    Car = atl,
                    CountryId = france.Id,
                    Country = france
                    
                };
                atl_DE = new Car_Country_JoinTable()
                {
                    CarId = atl.Id,
                    Car = atl,
                    CountryId = germany.Id,
                    Country = germany
                };
            }
            context.CarCountries.Add(atl_FR);
            context.CarCountries.Add(atl_DE);
            //save all the changes to the DB
            context.SaveChanges();
            #endregion

            
            #region ADD COUNTRIES TO CARS
            List<Car_Country_JoinTable> tempList = new List<Car_Country_JoinTable>();
            tempList.Add(atl_FR);
            tempList.Add(atl_DE);
            atl.CountryList = tempList;

            //context.Cars.Update(atl);
            //save all the changes to the DB
            context.SaveChanges();
            #endregion
            
        }
    }
}
