using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> Options)
            :base (Options)
        {

        }
        public  DbSet<Users> MessageUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
