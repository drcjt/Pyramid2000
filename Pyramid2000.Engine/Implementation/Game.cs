using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Game : IGame
    {
        private IPlayer _player;
        private IPrinter _printer;
        private IParser _parser;
        private IScripter _scripter;
        private IRooms _rooms;
        private IDefaultScripter _defaultScripter;
        private IItems _items;
        private IGameState _gameState;
        private ISettings _settings;

        public Game(IPlayer player, IPrinter printer, IParser parser, IScripter scripter, IRooms rooms, IDefaultScripter defaultScripter, IItems items, IGameState gameState, ISettings settings)
        {
            _settings = settings;

            _player = player;
            _printer = printer;
            _parser = parser;
            _scripter = scripter;
            _rooms = rooms;
            _defaultScripter = defaultScripter;
            _items = items;
            _gameState = gameState;

            _gameState.BatteryLife = 310;
        }

        public void ProcessPlayerInput(string input)
        {
            if (input != null)
            {
                var commands = input.Split(';');
                foreach(var command in commands)
                {
                    var parsedCommand = _parser.ParseInput(command);
                    if (parsedCommand == null)
                    {
                        _printer.Print(": ");
                        return;
                    }

                    var handled = false;

                    var room = _rooms.GetRoom(_player.CurrentRoom);
                    if (room.Commands != null && room.Commands.ContainsKey(parsedCommand.Function))
                    {
                        var script = room.Commands[parsedCommand.Function];
                        handled = _scripter.ParseScript(script, parsedCommand.Item);
                    }

                    if (!handled)
                    {
                        var script = _defaultScripter.GetDefaultScript(parsedCommand.Function);
                        if (script != null)
                        {
                            handled = _scripter.ParseScript(script, parsedCommand.Item);
                        }
                    }
                    
                    if (!handled)
                    {
                        _printer.PrintLn(Resources.DontKnowHowToApplyWord);
                    }

                    DoAfterPlayerTurn();
                }

                _printer.Print(Resources.Prompt);
            }
        }

        private void DoAfterPlayerTurn()
        {
            _gameState.TurnCount++;

            var lamp = _items.GetExactItemByName("#LAMP_on");
            if (!string.IsNullOrEmpty(lamp.Location))
            {
                _gameState.BatteryLife--;
                if (_gameState.BatteryLife == 0)
                {
                    if (!TryChangeBatteries())
                    {
                        var lampDead = _items.GetExactItemByName("#LAMP_dead");
                        lampDead.Location = lamp.Location;
                        lamp.Location = null;
                        _printer.PrintLn(Resources.LampOutOfPower);
                    }
                }
                else if (_gameState.BatteryLife == 20)
                {
                    _printer.PrintLn(Resources.LampGettingDim);
                }
            }
            if (_gameState.BatteryLife <= 10)
            {
                TryChangeBatteries();
            }
        }

        private bool TryChangeBatteries()
        {
            var batteries = _items.GetExactItemByName("#BATTERIES_fresh");
            if (batteries.Location == "pack")
            {
                _printer.PrintLn(Resources.LampGettingDimChangingBatteries);
                _gameState.BatteryLife = 310;
                batteries.Location = null;
                batteries = _items.GetExactItemByName("#BATTERIES_worn");
                batteries.Location = "pack";
                return true;
            }
            return false;
        }

        public void Init()
        {
            _printer.PrintLn(Resources.Welcome);
            _printer.PrintLn("");
            _scripter.Look();
            _printer.Print(Resources.Prompt);
        }
    }
}
