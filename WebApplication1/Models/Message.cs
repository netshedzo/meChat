using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class Message
    {
        [Key]
        public ObjectId Id { get; set; }
        [BsonElement("Text")]
        public string Text { get; set; }
        [BsonElement("MessageDate")]
        public DateTime MessageDate { get; set; }
        [BsonElement("Read")]
        public bool Read { get; set; }
        [BsonElement("Sender")]
        public ObjectId Sender { get; set; }
        [BsonElement("Receiver")]
        public ObjectId Receiver { get; set; }
        [BsonElement("DeleteS")]
        public bool DeleteS { get; set; }
        [BsonElement("DeleteR")]
        public bool DeleteR { get;set; }
    }
}
