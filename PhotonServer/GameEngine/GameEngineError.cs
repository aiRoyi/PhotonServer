using GameEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public enum GameEngineError
    {
        InvalidInput,
        RuntimeError,
    }

    [Serializable]
    public class GameEngineException : Exception
    {
        public GameEngineError ErrorCode { get; set; }

        public GameEngineException(GameEngineError errorCode)
        {
            ErrorCode = errorCode;
        }

        public GameEngineException(GameEngineError errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
            Source = "Game Engine";
        }
    }

    [Serializable]
    public class InvalidGameInput: GameEngineException
    {
        public InvalidGameInput(InputId receivedInput, InputId expectedInput)
            : base(GameEngineError.InvalidInput, "[Quest Engine] Received input " + receivedInput + " but expected " + expectedInput)
        {
        }
    }
}
