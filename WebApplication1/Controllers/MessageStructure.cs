using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class MessageStructure
    {
       
        public string Text { get; set; }
       
        public DateTime MessageDate { get; set; }
        
        public bool Read { get; set; }
        
        public string Sender { get; set; }
      
        public string Receiver { get; set; }
        
        public bool DeleteS { get; set; }
        
        public bool DeleteR { get; set; }
    }
}
