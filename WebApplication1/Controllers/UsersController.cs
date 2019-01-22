using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly MessageContext Database;
        private readonly UserService Mongos;

        public UsersController(UserService serv)
        {
            Mongos = serv;
      
        }
        // GET: api/<controller>
        [HttpGet("get/all")]
        public async Task<List<Users>> GetUsers()
        {
            return await Mongos.GetAync() ;
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Users>> GetUser(int ID)
        {
            var User = await Database.MessageUsers.FindAsync(ID);
            if(User == null)
            {
                return NotFound();
            }
            return  User;
        }
        //Post GetAUser
        [HttpPost("get/User")]
        public async Task<ActionResult<Users>> GetUser(Users userNam)
        {
            
            var user = await Database.MessageUsers.FirstOrDefaultAsync(u => u.UserName == userNam.UserName);
            if(user == null)
            {
                return NotFound();
            }
         
            
            return user;
        }
        //Post Log in; 
        [HttpPost("set/user")]
        public async Task<Users> SetUser(Users user)
        {

            return await Mongos.CreatUser(user);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
