using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Messages
{
    [Serializable]
    public enum MessageCode : byte
    {
        Error = 0,
        GameResult = 1,
        Debug = 99,
    }

    public abstract class GameMessage
    {
        public MessageCode Code { get; }

        public GameMessage(MessageCode code)
        {
            this.Code = code;
        }
    }
}
