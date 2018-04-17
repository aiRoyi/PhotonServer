using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Messages
{
    public class MessageError : GameMessage
    {
        public GameEngineError ErrorCode { get; set; }

        public string Message { get; set; }

        public MessageError() : base(MessageCode.Error)
        {
        }
    }
}
