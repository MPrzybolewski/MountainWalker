﻿using System;
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

namespace MountainWalkerWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        //Return all users
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        //This method returns true when login and password match
        // GET: api/Users/login?password=password
        [HttpGet("{login}")]
        public string CheckLogin(string login, string password)
        {
            var users = _context.Users;
            password = CalculateHash(password);
            foreach (var item in users)
            {
                if (item.Login.Equals(login))
                {                   
                    if(CalculateHash(item.Password).Equals(CalculateHash(password)))
                    {
                        return "true";
                    }
                }
            }
            return "false";
        }

        //Updates user
        // PUT: api/Users
        [HttpPut]
        public async Task<string> PutUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return "false";
            }

            if (user.Id != user.Id)
            {
                return "false";
            }

            user.Password = CalculateHash(user.Password);

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return "true";
            }
            catch (DbUpdateConcurrencyException)
            {
                int temp = user.Id ?? default(int);
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
        public async Task<string> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return "false";
            }

            user.Id = null;

            if(!CheckData(user))
            {
                return "false";
            }

            user.Password = CalculateHash(user.Password);
            _context.Users.Add(user);


            try
            {
                await _context.SaveChangesAsync();
                return "true";
            } catch (Exception e)
            {
                return e.Message.ToString();
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

            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
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
            return _context.Users.Any(e => e.Id == id);
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

        private bool CheckData(User user)
        {
            if ((user.Login.Length<3) || (user.Password.Length<6) || (user.Email.Length<6) || (user.Name.Length<3) || (user.Surname.Length<3))
            {
                return false;
            }

            if (!IsValidEmail(user.Email))
            {
                return false;
            }
            return true;
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