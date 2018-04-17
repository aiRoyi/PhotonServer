using GameEngine.Input;
using GameEngine.Logger;
using GameEngine.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Steps
{
    public enum StepId
    {
        None,
        StartGame,
        EndGame
    }
    public abstract class Step
    {
        public InputId RequiredInputId { get; }

        public GameInput StepInput { get; private set; }

        public IGameEngineLogger Logger { get; set; }

        public StepId StepId { get; }

        protected GameMessageHandler DispatchMessage { get; }

        protected Step(GameMessageHandler hander, StepId stepId, InputId requiredInputId = InputId.None)
        {
            RequiredInputId = requiredInputId;
            StepId = stepId;
            DispatchMessage = hander;
        }

        public void Start(GameInput input)
        {
            StepInput = input;
            if (RequiredInputId != InputId.None && StepInput == null)
            {
                if (StepInput == null)
                    Logger.LogError("[" + StepId + "] No input received");
                else
                    throw new InvalidGameInput(StepInput.InputId, RequiredInputId);
            }
            else
            {
                LogDebug("[Execute Step][" + StepId.ToString() + "]");
                Execute();
            }
        }

        protected void LogDebug(string message)
        {
            Logger.LogDebug(message);
            DispatchMessage(new MessageDebug { Message = message });
        }

        protected abstract void Execute();

        public abstract StepId NextStep();
    }
}
