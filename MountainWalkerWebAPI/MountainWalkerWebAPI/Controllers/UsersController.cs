using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MountainWalkerWebAPI.Models;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MountainWalkerWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        //Return all users
        // GET: api/Users/GetUsers
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        //This method returns true when login and password match
        // POST: api/Users/CheckLogin
        [HttpPost]
        public bool CheckLogin([FromBody] User userCheck)
        {
            var users = _context.Users;
            userCheck.Password = CalculateHash(userCheck.Password);
            foreach (User user in _context.Users)
            {
                if (user.Login.Equals(userCheck.Login))
                {                   
                    if(user.Password.Equals(userCheck.Password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //This method returns name and surname for given login
        // POST: api/Users/GetName
        [HttpPost]
        public string GetName([FromBody] User userr)
        {
            string result;
            foreach (User user in _context.Users)
            {
                if (user.Login.Equals(userr.Login))
                {
                    result = user.Name + " " + user.Surname;
                    return result;
                }
            }
            return "false";
        }
        
		//This method returns ids of achievements for given user
		// POST: api/Users/GetAchievementsForGivenUser
        [HttpPost]
		public IEnumerable<AchivementsToReturn> GetAchievementsForGivenUser([FromBody] User userr)
        {
            int? id = null;
            List<AchivementsToReturn> result = new List<AchivementsToReturn>();
            
            foreach (User user in _context.Users)
            {
                if (user.Login.Equals(userr.Login))
                {
                    id = user.UserID;
                }
            }
            
            foreach(UserAchievement achi in _context.UserAchievement)
            {
                AchivementsToReturn toReturn = new AchivementsToReturn();
                if(achi.UserID == id)
                {
                    toReturn.ID = achi.AchievementID;
                    var temp = _context.Achievement.Single(s => s.AchievementID == achi.AchievementID);
                    toReturn.Name = temp.Name;
                    toReturn.Date = achi.Date;
                    result.Add(toReturn);
                }
            }
            return result;
        }

        //This method returns trail for given user
        // POST: api/Users/GetTrailsForUser
        [HttpPost]
        public IEnumerable<TrailToReturn> GetTrailsForUser([FromBody] User userr)
        {
            int? id = null;
            List<TrailToReturn> result = new List<TrailToReturn>();
            foreach (User user in _context.Users)
            {
                if (user.Login.Equals(userr.Login))
                {
                    id = user.UserID;
                }
            }

            foreach(Trail trail in _context.Trail)
            {
                if(trail.UserID == id)
                {
                    TrailToReturn trailToReturn = new TrailToReturn();
                    trailToReturn.TrailID = trail.TrailID;
                    trailToReturn.Distance = trail.Distance;
                    trailToReturn.StartPoint = trail.StartPoint;
                    trailToReturn.EndPoint = trail.EndPoint;
                    trailToReturn.StartTime = trail.StartTime;
                    trailToReturn.EndTime = trail.EndTime;
                    trailToReturn.Date = trail.Date;

                    foreach(TrailHasTrailPart part in _context.TrailHasTrailPart)
                    {
                        if(part.TrailID == trail.TrailID)
                        {
                            trailToReturn.TrailParts.Add(part.TrailPartID);
                        }
                    }
                    result.Add(trailToReturn);
                }
            }
            return result;
        }

        //Updates data
        // PUT: api/Users
        [HttpPut]
        public async Task<string> PutUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return "false";
            }

            if (user.UserID != user.UserID)
            {
                return "false";
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return "true";
            }
            catch (DbUpdateConcurrencyException)
            {
                int temp = user.UserID ?? default(int);
                if (!UserExists(temp))
                {
                    return "user not exist";
                }
                else
                {
                    return "user exist";
                }
            }
        }

        //Add new user
        // POST: api/Users
        [HttpPost]
        public async Task<bool[]> PostUser([FromBody] User user)
        {
            bool[] result = new bool[6];

            //if (!ModelState.IsValid)
            //{
            //    return false;
            //}

            user.UserID = null;
            result = CheckData(user);
            if (!result[0])
            {
                return result;
            }

            user.Password = CalculateHash(user.Password);
            _context.Users.Add(user);

            try
            {
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
                return result;
            }

        }

        //Add trail for given user
		// POST: api/Users
        [HttpPost]
        public async Task<bool> PostTrail([FromBody] JsonTrail trail, string login)
        {
            Trail trailToSave = new Trail();
            trailToSave.TrailID = null;
            trailToSave.StartTime = Convert.ToDateTime(trail.StartTime);
            trailToSave.EndTime = Convert.ToDateTime(trail.EndTime);
            trailToSave.StartPoint = trail.From;
            trailToSave.Distance = Convert.ToDouble(trail.Distance);
            trailToSave.EndPoint = trail.To;
            trailToSave.Date = Convert.ToDateTime(trail.Date);
            int? id = 9999999;
            
            foreach (User user in _context.Users)
            {
                if (user.Login.Equals(login))
                {
                    id = user.UserID;
                }
            }
            
            trailToSave.UserID = id;
            _context.Trail.Add(trailToSave);
            
            try
            {
                await _context.SaveChangesAsync();
                
                foreach(int _id in trail.Trails)
                {
                    _context.TrailParts.Add(new TrailPart(_id, "test"));
                }

                foreach(int _id in trail.Trails)
                {
                    _context.TrailHasTrailPart.Add(new TrailHasTrailPart(trailToSave.TrailID, _id));
                }
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

		private bool[] CheckData(User user)
        {
            bool[] result = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                result[i] = true;
            }

            if (user.Login.Length < 3)
            {
                result[0] = false;
                result[3] = false;
            }
            if (user.Name.Length < 2)
            {
                result[0] = false;
                result[1] = false;
            }
            if (user.Surname.Length < 2)
            {
                result[0] = false;
                result[2] = false;
            }
            if (user.Password.Length < 6)
            {
                result[0] = false;
                result[4] = false;
            }
            if (!IsValidEmail(user.Email))
            {
                result[0] = false;
                result[5] = false;
            }
            return result;
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}