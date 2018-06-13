using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MountainWalkerWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MountainWalkerWebAPI.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AchivementsController : Controller
    {
        private readonly UserContext _context;

        public AchivementsController(UserContext context)
        {
            _context = context;
        }

        //Return all users
		// GET: api/Achievements/GetAchievements
        [HttpGet]
        public IEnumerable<Achievement> GetAchievements()
        {
            return _context.Achievement;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
