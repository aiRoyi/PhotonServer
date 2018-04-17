using GameEngine.Input;
using GameEngine.Logger;
using GameEngine.Messages;
using GameEngine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public delegate void GameMessageHandler(GameMessage engineMessage);

    public class GameEngine
    {
        public StepId CurrentStepId { get; set; }

        public GameMessageHandler GameMessageHandler { get; }

        public IGameEngineLogger Logger { get; private set; }

        private Dictionary<StepId, Step> _steps;

        private Dictionary<StepId, Step> _stepExecutor;

        private Dictionary<InputId, StepId> _inputs;

        private bool _isGameOver;

        public GameEngine(GameMessageHandler hander, IGameEngineLogger logger)
        {
            GameMessageHandler = hander;
            Logger = logger;
            CurrentStepId = StepId.StartGame;
            ConfigureStepsAndInputs();
        }

        public void SendInput(GameInput input)
        {
            Task.Run(() => RunSimulation(input));
        }

        private void RunSimulation(GameInput input)
        {
            if(input.GetType() == typeof(InputStartGame))
            {
                var inputStartGame = (InputStartGame)input;
                _stepExecutor = _steps;
            }
            if (_isGameOver)
            {
                if (input.InputId == InputId.StartGame)
                {
                    CurrentStepId = StepId.StartGame;

                    _isGameOver = false;
                }
                else
                {
                    return;
                }
            }
            if (_inputs.ContainsKey(input.InputId))
            {
                CurrentStepId = _inputs[input.InputId];
                LoopSimulation(input);
            }
            else
            {
                Logger.LogError("[Quest Engine] No step id found for input id: " + input.InputId);
            }
        }

        private void LoopSimulation(GameInput input = null)
        {
            do
            {
                _stepExecutor[CurrentStepId].Logger = Logger;
                _stepExecutor[CurrentStepId].Start(input);
                CurrentStepId = _stepExecutor[CurrentStepId].NextStep();
                input = null;
            }
            while (CurrentStepId != StepId.None && _stepExecutor[CurrentStepId].RequiredInputId == InputId.None);
        }

        private void ConfigureStepsAndInputs()
        {
            _steps = new Dictionary<StepId, Step>()
            {
                { StepId.StartGame, new StartGameStep(GameMessageHandler) },
                { StepId.EndGame, new EndGameStep(GameMessageHandler) }
            };

            _inputs = new Dictionary<InputId, StepId>()
            {
                { InputId.StartGame, StepId.StartGame }
            };
        }
    }
}
