using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Messages
{
    public class MessageGameResult : GameMessage
    {
        public bool IsWin { get; set; }

        public MessageGameResult() : base(MessageCode.GameResult)
        {
        }
    }
}
