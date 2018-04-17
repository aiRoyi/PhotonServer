using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Input
{
    public enum InputId : byte
    {
        None = 0,
        StartGame = 1,
    }

    [Serializable]
    public abstract class GameInput
    {
        public InputId InputId { get; }

        public GameInput(InputId inputId)
        {
            InputId = inputId;
        }
    }
}
