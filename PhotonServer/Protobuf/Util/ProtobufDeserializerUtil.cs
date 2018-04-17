using GameEngine.Input;
using Google.Protobuf;
using Protobuf.C2S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protobuf.Util
{
    public static class ProtobufDeserializerUtil
    {
        private static Dictionary<C2SMessageType, Func<byte[], GameInput>> _gameInputDeserializerLookups =
            new Dictionary<C2SMessageType, Func<byte[], GameInput>>()
            {
                { C2SMessageType.StartGame, DeserializeStartGame},
            };

        public static GameInput DeserializeQuestInput(byte code, byte[] data)
        {
            try
            {
                C2SMessageType type = (C2SMessageType)code;
                if (_gameInputDeserializerLookups.ContainsKey(type))
                {
                    return _gameInputDeserializerLookups[type](data);
                }
            }
            catch (InvalidProtocolBufferException)
            {

            }
            return null;
        }

        private static GameInput DeserializeStartGame(byte[] data)
        {
            StartGame startGame = StartGame.Parser.ParseFrom(data);
            if (startGame != null)
            {
                InputStartGame inputStartGame = new InputStartGame();
                inputStartGame.Title = startGame.Title;
                inputStartGame.Difficulty = startGame.Difficulty;
                return inputStartGame;
            }
            return null;
        }
    }
}
