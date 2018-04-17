using GameEngine.Input;
using GameEngine.Messages;
using Google.Protobuf;
using Protobuf.C2S;
using Protobuf.S2C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protobuf.Util
{
    public static class ProtobufSerializerUtil
    {
        private static Dictionary<MessageCode, Func<GameMessage, byte[]>> _gameMessageSerializerLookups =
            new Dictionary<MessageCode, Func<GameMessage, byte[]>>()
            {
                { MessageCode.Error, SerializeError},
                { MessageCode.GameResult, SerializeGameResult},
                { MessageCode.Debug, SerializerMessageDebug },
            };

        private static Dictionary<InputId, Func<GameInput, byte[]>> _gameInputSerializerLookups =
            new Dictionary<InputId, Func<GameInput, byte[]>>()
            {
                { InputId.StartGame, SerializerQuestInputStartGame },
            };

        public static byte[] Serialize(GameMessage message)
        {
            if(_gameMessageSerializerLookups.ContainsKey(message.Code))
            {
                return _gameMessageSerializerLookups[message.Code](message);
            }
            return null;
        }

        public static byte[] Serialize(GameInput message)
        {
            if(_gameInputSerializerLookups.ContainsKey(message.InputId))
            {
                return _gameInputSerializerLookups[message.InputId](message);
            }
            return null;
        }

        private static byte[] SerializerQuestInputStartGame(GameInput inputMessage)
        {
            InputStartGame msg = (InputStartGame)inputMessage;

            StartGame proto = new StartGame();
            proto.Title = msg.Title;

            var data = proto.ToByteArray();
            return data;
        }

        private static byte[] SerializeError(GameMessage message)
        {
            MessageError msg = (MessageError)message;

            ProtoMessageError proto = new ProtoMessageError();
            proto.ErrorCode = (ProtoQuestEngineError)msg.ErrorCode;
            proto.Message = msg.Message;

            var data = proto.ToByteArray();
            return data;
        }

        private static byte[] SerializerMessageDebug(GameMessage message)
        {
            MessageDebug msg = (MessageDebug)message;

            ProtoMessageDebug proto = new ProtoMessageDebug();
            proto.Message = msg.Message;

            var data = proto.ToByteArray();
            return data;
        }

        private static byte[] SerializeGameResult(GameMessage message)
        {
            MessageGameResult msg = (MessageGameResult)message;

            GameResult proto = new GameResult();
            proto.IsWin = msg.IsWin;

            var data = proto.ToByteArray();
            return data;
        }
    }
}
