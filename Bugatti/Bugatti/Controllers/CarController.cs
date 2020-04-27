using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bugatti.Controllers
{
    [Route("api/v1/cars")]
    public class CarController : Controller
    {
        private readonly BugattiContext context;

        public CarController(BugattiContext context)
        {
            this.context = context;
        }

        //this action is accessible via the url(route): http://localhost:44335/api/v1/cars/test
        [Route("test")]
        [HttpGet]
        public string Test()
        {
            return "Car controller";
        }

        //this action is accessible via the url (route): http://localhost:44335/api/v1/cars
        [HttpGet]
        public List<Car> GetAllCars()
        {
            return context.Cars.ToList();
        }

        //------------- Doesn't work
        [HttpPost]
        public IActionResult CreateCar([FromBody]Car newCar)
        {
            //Car toevoegen in DB, Id wordt ook toegekend
            context.Cars.Add(newCar);
            context.SaveChanges();
            //stuur result 201 met car als content
            return Created("", newCar);
        }
        //-------------

        //this action is accessible via the url (route): http://localhost:44335/api/v1/cars/get/{id}
        [Route("get/{id}")]
        [HttpGet]
        public IActionResult GetCar(int id)
        {
            var car = context.Cars.Find(id);
            if (car == null)
                return NotFound();
            return Ok(car);
        }

        //this action is accessible via the url (route): http://localhost:44335/api/v1/cars/delete/{id}
        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteCar(int id)
        {
            var car = context.Cars.Find(id);
            if (car == null)
                return NotFound();
            //delete car
            context.Cars.Remove(car);
            context.SaveChanges();
            //default correct deletion response code 204
            return NoContent();
        }
        //-------------

        [HttpPut]
        public IActionResult UpdateCar([FromBody] Car updateCar)
        {
            var orgCar = context.Cars.Find(updateCar.Id);
            if (orgCar == null)
                return NotFound();

            orgCar.Type = updateCar.Type;
            orgCar.Name = updateCar.Name;

            context.SaveChanges();
            return Ok(orgCar);
        }


    }
}