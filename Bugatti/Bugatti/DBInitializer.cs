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
            //Create the DB if not yet exists
            context.Database.EnsureCreated();
            //Are there any cars created?
            if (!context.Cars.Any())
            { 
                //create new car
                var car1 = new Car()
                {
                    Type = "57sc",
                    Name = "Atlantic"
                };
                //add car to collection of cars
                context.Cars.Add(car1);
                //save all the changes to the DB
                context.SaveChanges();
            }
        }
    }
}
