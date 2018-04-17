using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Input
{
    public class InputStartGame : GameInput
    {
        public string Title { get; set; }

        public string Difficulty { get; set; }

        public InputStartGame() : base(InputId.StartGame)
        {
        }
    }
}
