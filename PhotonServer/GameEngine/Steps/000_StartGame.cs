using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Input;
using GameEngine.Messages;

namespace GameEngine.Steps
{
    public class StartGameStep : Step
    {
        public StartGameStep(GameMessageHandler hander) : base(hander, StepId.StartGame, InputId.StartGame)
        {
        }

        public override StepId NextStep()
        {
            return StepId.EndGame;
        }

        protected override void Execute()
        {
            DispatchMessage(new MessageDebug
            {
                Message = "Start Game"
            });
        }
    }
}
