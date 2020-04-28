using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bugatti.Controllers
{
    [Route("api/v1/creators")]
    public class CreatorController : Controller
    {
        #region Bugatti Context
        private readonly BugattiContext context;

        public CreatorController(BugattiContext context)
        {
            this.context = context;
        }
        #endregion

        #region TEST [HTTPGET] (/api/v1/creators/test)
        [Route("test")]
        [HttpGet]
        public string Test()
        {
            return "creator controller";
        }
        #endregion

        #region GET ALL CREATORS [HTTPGET] (/api/v1/creators)
        [HttpGet]
        public List<Creator> GetAllCreators()
        {
            return context.Creators.ToList();
        }
        #endregion

        #region GET SPECIFIC CREATOR [HTTPGET] (/api/v1/creators/{id})
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCreator(int id)
        {
            var creator = context.Creators.Find(id);
            if (creator == null)
                return NotFound();
            return Ok(creator);
        }
        #endregion

        #region DELETE SPECIFIC CREATOR [HTTPDELETE] (/api/v1/creators/delete/{id})
        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteCreator(int id)
        {
            var creator = context.Creators.Find(id);
            if (creator == null)
                return NotFound();
            //delete car
            context.Creators.Remove(creator);
            context.SaveChanges();
            //default correct deletion response code 204
            return NoContent();
        }
        #endregion

    }
}