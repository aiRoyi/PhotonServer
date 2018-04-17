using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Messages
{
    public class MessageDebug : GameMessage
    {
        public string Message { get; set; }

        public MessageDebug() : base(MessageCode.Debug)
        {
            Message = "";
        }
    }
}
