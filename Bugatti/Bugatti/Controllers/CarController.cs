﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public List<Car> GetAllCars(string name, int? page, string sortItem, int? amount, string sortDir = "asc")
        {
            IQueryable<Car> query = context.Cars
                .Include(coli => coli.CountryList)
                .ThenInclude(co => co.Country)
                .Include(cr => cr.Creator);

            #region SEARCHING
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(d => d.Name.Contains(name));
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
                    default:
                        if (sortDir == "asc")
                            query = query.OrderBy(d => d.Id);
                        else if (sortDir == "desc")
                            query = query.OrderByDescending(d => d.Id);
                        break;
                }
            }
            #endregion

            #region PAGING
            if (page.HasValue)
            {
                query = query.Skip(page.Value);
            }
            if (amount.HasValue)
            {
                query = query.Take(amount.Value);
            }
            else
            {
                query = query.Take(20);
            }           
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
        //[Authorize]
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
            if (updateCar.Name != orgCar.Name)
            {
                orgCar.Name = updateCar.Name;
            }
            if (updateCar.AvrgPrice != orgCar.AvrgPrice)
            {
                orgCar.AvrgPrice = updateCar.AvrgPrice;
            }
            if (updateCar.Horsepower != orgCar.Horsepower)
            {
                orgCar.Horsepower = updateCar.Horsepower;
            }
            if (updateCar.MaxSpeed != orgCar.MaxSpeed)
            {
                orgCar.MaxSpeed = updateCar.MaxSpeed;
            }
            if (updateCar.Weight != orgCar.Weight)
            {
                orgCar.Weight = updateCar.Weight;
            }
            if (updateCar.Prototype != orgCar.Prototype)
            {
                orgCar.Prototype = updateCar.Prototype;
            }
            if (updateCar.WorldRecords != orgCar.WorldRecords)
            {
                orgCar.WorldRecords = updateCar.WorldRecords;
            }
            if (updateCar.TotalBuilt != orgCar.TotalBuilt)
            {
                orgCar.TotalBuilt = updateCar.TotalBuilt;
            }
            if (updateCar.TotalRaceVictories != orgCar.TotalRaceVictories)
            {
                orgCar.TotalRaceVictories = updateCar.TotalRaceVictories;
            }
            if (updateCar.SmallDescription != orgCar.SmallDescription)
            {
                orgCar.SmallDescription = updateCar.SmallDescription;
            }
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