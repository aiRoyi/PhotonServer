using GameEngine.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Steps;
using Photon.Hive.Plugin;
using GameEngine;
using GameEngine.Messages;

namespace PhotonPlugin.Logger
{
    public class PhotonPluginLogger : IGameEngineLogger
    {
        public IPluginHost PluginHost { get; private set; }

        public GameMessageHandler GameMessageHandler { get; }

        public PhotonPluginLogger(IPluginHost host, GameMessageHandler handler)
        {
            PluginHost = host;
            GameMessageHandler = handler;
        }

        public void LogDebug(string message)
        {
            PluginHost.LogDebug(message);
            GameMessageHandler(new MessageDebug
            {
                Message = message
            });
        }

        public void LogError(string message)
        {
            PluginHost.LogError(message);
            GameMessageHandler(new MessageError
            {
                Message = message
            });
        }

        public void LogExecutionTime(StepId stepId, long executionTimeInMilliseconds)
        {
            GameMessageHandler(new MessageDebug
            {
                Message = "[Quest Engine Execution Time] " + stepId + ": " + executionTimeInMilliseconds
            });
            //PluginHost.LogDebug("[Quest Engine Execution Time] " + stepId + ": " + executionTimeInMilliseconds);
        }
    }
}
