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

        #region TEST                        [HTTPGET]       (/api/v1/creators/test)
        [Route("test")]
        [HttpGet]
        public string Test()
        {
            return "creator controller";
        }
        #endregion

        #region GET ALL CREATORS            [HTTPGET]       (/api/v1/creators)
        [HttpGet]
        public List<Creator> GetAllCreators()
        {
            return context.Creators.ToList();
        }
        #endregion

        #region GET SPECIFIC CREATOR        [HTTPGET]       (/api/v1/creators/{id})
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

        #region CREATE NEW CREATOR          [HTTPPOST]      (/api/v1/creators)        
        [HttpPost]
        public IActionResult CreateCreator([FromBody]Creator newCreator)
        {
            //Car toevoegen in DB, Id wordt ook toegekend
            context.Creators.Add(newCreator);
            context.SaveChanges();
            //stuur result 201 met car als content
            return Created("", newCreator);
        }
        #endregion

        #region DELETE SPECIFIC CREATOR     [HTTPDELETE]    (/api/v1/creators/{id})
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteCreator(int id)
        {
            var creator = context.Creators.Find(id);
            if (creator == null)
                return NotFound();
            //delete creator
            context.Creators.Remove(creator);
            context.SaveChanges();
            //default correct deletion response code 204
            return NoContent();
        }
        #endregion

        #region PATCH CREATOR                   [HTTPPATCH]     (/api/v1/creators)
        [HttpPatch]
        public IActionResult PatchCreator([FromBody] Creator updateCreator)
        {
            var orgCreator = context.Creators.Find(updateCreator.Id);
            if (orgCreator == null)
                return NotFound();

           
            context.SaveChanges();
            return Ok(orgCreator);
        }
        #endregion
    }
}