using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication1.Models;
namespace WebApplication1.Services
{
    public class UserService
    {
        private readonly IMongoCollection<Users> _Users;
        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("PeopleDb"));
            var database = client.GetDatabase("PeopleDb");
            _Users = database.GetCollection<Users>("UserCollection");
        }

        public async Task<List<Users>> GetAync()
        {
            return await _Users.Find(user => true).ToListAsync();
        }

        public Users Get(string ID)
        {
            var docID = new ObjectId(ID);

            return _Users.Find<Users>(user => user.Id == docID).FirstOrDefault();
        
        }
        public Users GetUser(string name)
        {
            return _Users.Find(user => user.UserName == name).FirstOrDefault();
        }

        public async Task<Users> CreatUser(Users user)
        {
          await   _Users.InsertOneAsync(user);
            return  user;
        }

    }

}
