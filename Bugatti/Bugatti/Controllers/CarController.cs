using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bugatti.Controllers
{
    [Route("api/v1/cars")]
    public class CarController : Controller
    {
        #region Bugatti Context
        private readonly BugattiContext context;

        public CarController(BugattiContext context)
        {
            this.context = context;
        }
        #endregion

        #region TEST                    [HTTPGET]       (/api/v1/cars/test)
        [Route("test")]
        [HttpGet]
        public string Test()
        {
            return "Car controller";
        }
        #endregion

        #region GET ALL CARS            [HTTPGET]       (/api/v1/cars)
        [HttpGet]
        public List<Car> GetAllCars(string name, int? startBuildYear, int? page, string sortItem, int lenght = 2, string sortDir = "asc")
        {
            IQueryable<Car> query = context.Cars.Include(coli => coli.CountryList).Include(cr => cr.Creator);

            #region SEARCHING
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(d => d.Name.Contains(name));
            if (startBuildYear.HasValue)
            {
                DateTime tempDate = new DateTime((int)startBuildYear, 1, 1);
                query = query.Where(d => d.StartBuildYear == tempDate);
            }
            #endregion

            #region SORTING
            if (!string.IsNullOrWhiteSpace(sortItem))
            {
                switch (sortItem)
                {
                    case "Id":
                        if (sortDir == "asc")
                            query = query.OrderBy(d => d.Id);
                        else if (sortDir == "desc")
                            query = query.OrderByDescending(d => d.Id);
                        break;
                    case "Name":
                        if (sortDir == "asc")
                            query = query.OrderBy(d => d.Name);
                        else if (sortDir == "desc")
                            query = query.OrderByDescending(d => d.Name);
                        break;
                    case "StartBuildYear":
                        if (sortDir == "asc")
                            query = query.OrderBy(d => d.StartBuildYear);
                        else if (sortDir == "desc")
                            query = query.OrderByDescending(d => d.StartBuildYear);
                        break;
                }
            }
            #endregion

            #region PAGING
            if (page.HasValue)
            {
                query = query.Skip(page.Value);
            }
            query = query.Take(lenght);
            #endregion


            return query.ToList();
        }
        #endregion

        #region GET SPECIFIC CAR        [HTTPGET]       (/api/v1/cars/{id})
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCar(int id)
        {
            var car = context.Cars.Find(id);
            if (car == null)
                return NotFound();
            return Ok(car);
        }
        #endregion

        #region CREATE NEW CAR          [HTTPPOST]      (/api/v1/cars)        
        [HttpPost]
        public IActionResult CreateCar([FromBody]Car newCar)
        {
            //Car toevoegen in DB, Id wordt ook toegekend
            context.Cars.Add(newCar);
            context.SaveChanges();
            //stuur result 201 met car als content
            return Created("", newCar);
        }
        #endregion

        #region DELETE SPECIFIC CAR     [HTTPDELETE]    (/api/v1/cars/{id})
        [Route("{id}")]
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
        #endregion      

        #region PATCH CAR               [HTTPPATCH]     (/api/v1/cars)
        [HttpPatch]
        public IActionResult PatchCar([FromBody] Car updateCar)
        {
            var orgCar = context.Cars.Find(updateCar.Id);
            if (orgCar == null)
                return NotFound();

            // ADD IF STRUCTURE WITH ALL PROPERTIES
            

            context.SaveChanges();
            return Ok(orgCar);
        }
        #endregion

        //Not Working -> can't give creator  
        #region UPDATE CAR               [HTTPPUT]       (/api/v1/cars)
        [HttpPut]
        public IActionResult UpdateCar([FromBody] Car updateCar)
        {
            var orgCar = context.Cars.Find(updateCar.Id);
            if (orgCar == null)
                return NotFound();

            orgCar.Name = updateCar.Name;
            orgCar.Creator = updateCar.Creator;

            context.SaveChanges();
            return Ok(orgCar);
        }
        #endregion
    }
}