using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Input;
using GameEngine.Messages;

namespace GameEngine.Steps
{
    public class EndGameStep : Step
    {
        public EndGameStep(GameMessageHandler hander) : base(hander, StepId.EndGame)
        {
        }

        public override StepId NextStep()
        {
            return StepId.None;
        }

        protected override void Execute()
        {
        }
    }
}
