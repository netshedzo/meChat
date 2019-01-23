using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using WebApplication1.Models;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Services
{
    public class MessageService
    {
        private readonly IMongoCollection<Message> _Message;
       

        public MessageService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("PeopleDb"));
            var Database = client.GetDatabase("PeopleDb");
            _Message = Database.GetCollection<Message>("MessageCollection");
        }


        public  async  Task<Message> SendMessage(Message  msg)
        {
            await _Message.InsertOneAsync(msg);
            return msg;
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _Message.Find(_Message => true).ToListAsync();
        }
        public async Task<List<Message>> GetMessagesAsync(string SenderID, string ReceiverID)
        {
            var userMain = new ObjectId(SenderID);
            var Receiver = new ObjectId(ReceiverID);

            var Result = _Message.Find(m => (m.Sender == userMain && m.Receiver == Receiver && m.DeleteS == false) || (m.Sender == Receiver && m.Receiver == userMain && m.DeleteR == false )).ToListAsync();
            
            if(Result == null)
            {
                return null;
            }

            return  await Result;
        }
    }
}
