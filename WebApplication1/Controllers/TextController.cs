using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("Message")]
    public class TextController : ControllerBase
    {

        private readonly MessageService _Mongos;
        public TextController(MessageService Mongo)
        {
            _Mongos = Mongo;
        }

        [HttpGet("get/all")]
        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _Mongos.GetMessagesAsync();
        }
        [HttpPost("get/chat")]
        public async Task<List<Message>> MessageAsync(string Sender,string Receiver)
        {
            return await _Mongos.GetMessagesAsync(Sender, Receiver);
        }
        [HttpPost("set")]
        public async Task<Message> MessageAsync(MessageStructure message)
        {
            Message m = new Message();

            m.Receiver = new MongoDB.Bson.ObjectId(message.Receiver);
            m.Sender = new MongoDB.Bson.ObjectId(message.Sender);
            m.Text = message.Text;
            m.Read = message.Read;
            m.MessageDate = message.MessageDate;
            

            await _Mongos.SendMessage(m);
            return m;
        }
    }
}