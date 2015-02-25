using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Game(IPlayer player, IPrinter printer, IParser parser, IScripter scripter, IRooms rooms, IDefaultScripter defaultScripter, IItems items, IGameState gameState)
        {
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
                        _printer.PrintLn("I DON'T KNOW HOW TO APPLY THAT WORD HERE.");
                    }

                    DoAfterPlayerTurn();
                }

                _printer.Print(": ");
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
                        _printer.PrintLn("YOUR LAMP HAS RUN OUT OF POWER.");
                    }
                }
                else if (_gameState.BatteryLife == 20)
                {
                    _printer.PrintLn("YOUR LAMP IS GETTING DIM. YOU'D BEST START WRAPPING THIS UP, UNLESS YOU CAN FIND SOME FRESH BATTERIES. I SEEM TO RECALL THERE IS A VENDING MACHINE IN THE MAZE. BRING SOME COINS WITH YOU.");
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
                _printer.PrintLn("YOUR LAMP IS GETTING DIM. I'M TAKING THE LIBERTY OF REPLACING THE BATTERIES.");
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
            _printer.PrintLn("WELCOME TO PYRAMID!!");
            _printer.PrintLn("");
            _scripter.Look();
            _printer.Print(": ");
        }
    }
}
