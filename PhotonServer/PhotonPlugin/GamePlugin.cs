using GameEngine;
using GameEngine.Input;
using GameEngine.Messages;
using Photon.Hive.Plugin;
using PhotonPlugin.Logger;
using Protobuf.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotonPlugin
{
    public class GamePlugin: PluginBase
    {
        public override string Name => "PhotonPlugin";

        public GameEngine.GameEngine GameEngine { get; private set; }

        public string AccountId { get; private set; }

        private bool _isEndGame = false;

        public override void OnCreateGame(ICreateGameCallInfo info)
        {
            base.OnCreateGame(info);
            AccountId = info.Request.GameProperties["accountId"] as string;
            _isEndGame = false;
            GameEngine = new GameEngine.GameEngine(OnGameEngineMessage, new PhotonPluginLogger(base.PluginHost, OnGameEngineMessage));
        }

        public override void OnRaiseEvent(IRaiseEventCallInfo info)
        {
            base.OnRaiseEvent(info);
            try
            {
                var input = DeserializeEvent(info.Request.EvCode, info.Request.Data);

                GameEngine.SendInput(input);

            }
            catch (Exception e)
            {
                ProcessException(e);
            }
        }

        private void ProcessException(Exception e)
        {
            PluginHost.LogError(e);
            PluginHost.LogError(e.StackTrace);

            OnGameEngineMessage(new MessageError
            {
                ErrorCode = GameEngineError.RuntimeError,
                Message = e.StackTrace
            });
        }

        protected virtual GameInput DeserializeEvent(byte eventCode, object eventData)
        {
            return ProtobufDeserializerUtil.DeserializeQuestInput(eventCode, (byte[])eventData);
        }

        private void OnGameEngineMessage(GameMessage message)
        {
            message = BeforeMessageProcessing(message);
            var eventData = ProtobufSerializerUtil.Serialize(message);
            var data = new Dictionary<byte, object>() { { 245, eventData }, { 245, 0 } };

            // Broadcast the message to the client, the event code will be similar to the message code
            if (!_isEndGame || message.GetType() == typeof(MessageGameResult))
                BroadcastEvent((byte)message.Code, data);
        }

        private GameMessage BeforeMessageProcessing(GameMessage message)
        {
            return message.Code != MessageCode.GameResult? message: ProcessWinGameResult(message);
        }

        private GameMessage ProcessWinGameResult(GameMessage message)
        {
            // DO some logic, such as give reward.
            return message;
        }
    }
}
