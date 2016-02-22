using System;

using Pyramid2000.Engine.Interfaces;
using Pyramid2000.Engine.Implementation;

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
        private IResources Resources { get; set; }

        public Game(IPlayer player, IPrinter printer, IParser parser, IScripter scripter, IRooms rooms, IDefaultScripter defaultScripter, IItems items, IGameState gameState, IResources resources = null)
        {
            _player = player;
            _printer = printer;
            _parser = parser;
            _scripter = scripter;
            _rooms = rooms;
            _defaultScripter = defaultScripter;
            _items = items;
            _gameState = gameState;
            if (resources != null)
            {
                Resources = resources;
            }
            else
            {
                Resources = new Resources();
            }

            _gameState.BatteryLife = 310;
        }

        public void ProcessPlayerInput(string input)
        {
            if (input != null)
            {
                if (!_gameState.AskToReincarnate)
                {
                    var commands = input.Split(';');
                    foreach (var command in commands)
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

                    // Only print a prompt for more input if the player is not being asked to reincarnate and hasn't died
                    if (!_gameState.AskToReincarnate && !_gameState.GameOver)
                    {
                        _printer.Print(Resources.Prompt);
                    }
                }
                else
                {
                    _scripter.ProcessReincarnation(input);
                }
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

        public string State
        {
            get
            {
                return Save();
            }
            set
            {
                Load(value);
            }
        }

        private string Save()
        {
            string state = "";
            var items = _items.GetAllItems();
            foreach (var item in items)
            {
                var locationOfItem = item.Location;
                if (locationOfItem.IndexOf("room_") == 0)
                {
                    locationOfItem = locationOfItem.Substring(4);
                }
                state += locationOfItem + ",";
            }

            state = "LOAD " + state + _player.CurrentRoom + "," + _gameState.LastRoom + "," + _gameState.TurnCount + "," + _gameState.GameOver + "," + _gameState.BatteryLife;

            return state;
        }

        private bool Load(string state)
        {
            // strip off the "LOAD " bit
            state = state.Substring(5);

            var splitstate = state.Split(',');

            int index = 0;
            var items = _items.GetAllItems();
            foreach (var item in items)
            {
                var locationofitem = splitstate[index];
                if (locationofitem.Length > 0 && locationofitem[0] == '_')
                {
                    locationofitem = "room" + locationofitem;
                }
                items[index].Location = locationofitem;

                index++;
            }

            _player.CurrentRoom = splitstate[index++];
            if (splitstate[index].Length == 0)
            {
                _gameState.LastRoom = null;
            }
            else
            {
                _gameState.LastRoom = splitstate[index];
            }
            index++;

            _gameState.TurnCount = Convert.ToInt32(splitstate[index++]);
            _gameState.GameOver = Convert.ToBoolean(splitstate[index++]);
            _gameState.BatteryLife = Convert.ToInt32(splitstate[index++]);

            _printer.Clear();

            _printer.PrintLn("");
            _scripter.Look();
            _printer.Print(Resources.Prompt);

            return true;
        }
    }
}
