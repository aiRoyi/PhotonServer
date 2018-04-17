using GameEngine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Logger
{
    public interface IGameEngineLogger
    {
        void LogDebug(string message);

        void LogError(string message);

        void LogExecutionTime(StepId stepId, long executionTimeInMilliseconds);
    }
}
