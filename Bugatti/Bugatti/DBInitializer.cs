using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;

namespace Bugatti
{
    public class DBInitializer
    {
        public static void Initialize( BugattiContext context)
        {
            //Delete DB if it exists
            context.Database.EnsureDeleted();
            //Create the DB if not yet exists
            context.Database.EnsureCreated();

            /*
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public ICollection<Car> Cars { get; set; }
           */ 

        //Are there any Creators created?
            if (!context.Creators.Any())
            {
                //create new Creators
                var creator1 = new Creator()
                {
                    FirstName = "Ettore",
                    LastName = "Bugatti"
                };
                var creator2 = new Creator()
                {
                    FirstName = "Jean",
                    LastName = "Bugatti"
                };
                var creator3 = new Creator()
                {
                    FirstName = "Jozef",
                    LastName = "Kaban"
                };
                var creator4 = new Creator()
                {
                    FirstName = "Achim",
                    LastName = "Anscheidt"
                };
                var creator5 = new Creator()
                {
                    FirstName = "Étienne",
                    LastName = "Salomé"
                };
                //add Creators to collection of Creators
                context.Creators.Add(creator1);
                context.Creators.Add(creator2);
                context.Creators.Add(creator3);
                context.Creators.Add(creator4);
                context.Creators.Add(creator5);
                //save all the changes to the DB
                //context.SaveChanges();
            }
            
            //Are there any cars created?
            if (!context.Cars.Any())
            {
                //create new cars
                var car1 = new Car()
                {
                    Type = "57sc",
                    Name = "Atlantic",
                    Creator = context.Creators.Find(2) //doesn't work
                };
                var car2 = new Car()
                {
                    Type = "50",
                    Name = "Royale",
                    Creator = context.Creators.Find(1) //doesn't work
                };
                var car3 = new Car()
                {
                    Type = "grand Sport",
                    Name = "Veyron",
                    //Creator =
                };
                var car4 = new Car()
                {
                    Type = "super Sport",
                    Name = "Veyron",
                    //Creator =
                };
                var car5 = new Car()
                {
                    Type = "grans Sport vitesse",
                    Name = "Veyron",
                    //Creator =
                };
                var car6 = new Car()
                {
                    Type = "",
                    Name = "Chiron",
                    //Creator =
                };
                var car7 = new Car()
                {
                    Type = "super sport",
                    Name = "chiron",
                    //Creator =
                };
                var car8 = new Car()
                {
                    Type = "",
                    Name = "la voiture noire",
                    //Creator =
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
                //save all the changes to the DB
                context.SaveChanges();
            }
        
        }
    }
}
