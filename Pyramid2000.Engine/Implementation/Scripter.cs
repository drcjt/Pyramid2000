using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Scripter : IScripter
    {
        private IPrinter _printer;
        private IItems _items;
        private IRooms _rooms;
        private IPlayer _player;
        private IGameState _gameState;
        private ISettings _settings;

        public Scripter(IPrinter printer, IItems items, IRooms rooms, IPlayer player, IGameState gameState, ISettings settings)
        {
            _settings = settings;
            _printer = new Printer(printer, _settings);
            _items = items;
            _rooms = rooms;
            _player = player;
            _gameState = gameState;
        }

        public bool MoveToRoomX(string roomID)
        {
            var lightNearby = false;
            if (_gameState.LastRoom != null && _rooms.IsRoomLit(_gameState.LastRoom))
            {
                lightNearby = true;
            }
            if (_rooms.IsRoomLit(roomID))
            {
                lightNearby = true;
            }

            if (!lightNearby)
            {
                var rand = GetRandomByte();
                if (rand >= 103)
                {
                    _printer.PrintLn(Resources.FellIntoPit);
                    PlayerDied();
                    return true;
                }
            }

            _gameState.LastRoom = _player.CurrentRoom;
            _player.CurrentRoom = roomID;
            Look();

            var chest = _items.GetExactItemByName("#CHEST");
            if (chest.Location == "")
            {
                var pack = _items.GetItemsAtLocation("pack");
                List<Item> packTreasureItems = new List<Item>();
                foreach (var packItem in pack)
                {
                    if (packItem.Treasure)
                    {
                        packTreasureItems.Add(packItem);
                    }
                }

                if (packTreasureItems.Count > 1)
                {
                    foreach (var packTreasureItem in packTreasureItems)
                    {
                        packTreasureItem.Location = "room_53";
                    }
                    _printer.PrintLn(Resources.MummyStealsTreasures);
                    chest.Location = "room_53";
                }
            }

            return true;
        }

        public bool AssertItemXIsInPack(string itemID)
        {
            var item = _items.GetTopItemByName(itemID);
            return (item.Location == "pack");
        }

        public bool AssertItemXIsInCurrentRoom(string itemID)
        {
            var item = _items.GetTopItemByName(itemID);
            return (item.Location == _player.CurrentRoom);
        }

        public bool AssertItemXIsInCurrentRoomOrPack(string itemID)
        {
            return AssertItemXIsInCurrentRoom(itemID) || AssertItemXIsInPack(itemID);
        }

        public bool PrintMessageX(string message)
        {
            _printer.PrintLn(message);
            return true;
        }

        public bool PrintRoomDescription()
        {
            Look();
            return true;
        }

        public bool MoveItemXToRoomY(string itemID, string roomID)
        {
            var item = _items.GetExactItemByName(itemID);
            item.Location = roomID;
            return true;
        }

        public bool Quit()
        {
            PrintScore();
            _gameState.GameOver = true;
            return true;
        }

        public bool PlayerDied()
        {
            if (_settings.Trs80Mode)
            {
                // TODO WHAT CAN USER DO TO BE REINCARNATED?
                _printer.PrintLn(Resources.GottenKilled);
                _printer.PrintLn(Resources.TryToReincarnate);
                // TODO need to get user input here as to what to do
            }
            if (_settings.Trs80Mode)
            {
                // TODO IN TRS-80 VERSION IT LOOKS LIKE DYING SUBTRACTS FROM YOUR SCORE - NEED TO WORK THIS OUT
                PrintScoreImpl(-10);
            }
            _gameState.GameOver = true;
            return true;
        }

        public bool MoveItemXToLocationY(string itemID, string locationID)
        {
            var itemX = _items.GetExactItemByName(itemID);
            itemX.Location = locationID;
            _printer.PrintLn(Resources.Ok);
            return true;
        }

        public bool MoveItemXToCurrentRoom(string itemID)
        {
            var itemX = _items.GetExactItemByName(itemID);
            itemX.Location = _player.CurrentRoom;
            return true;
        }

        public bool PrintScore()
        {
            return PrintScoreImpl(0);
        }

        private bool PrintScoreImpl(int initialScore)
        {
            var score = initialScore;

            var items = _items.GetAllItems();
            foreach (var item in items)
            {
                if (item.Treasure)
                {
                    var topItem = _items.GetTopItemByName(item.Name);
                    if (topItem.Location == "room_2")
                    {
                        score += 20;
                    }
                    else if (topItem.Location == "pack")
                    {
                        score += 5;
                    }
                }
            }

            _printer.PrintLn(String.Format(Resources.YouHaveScored, score, _gameState.TurnCount));

            return true;
        }

        public bool AssertItemXMatchesUserInput(string itemID)
        {
            return (itemID == (inputItem != null ? inputItem.Name : null));
        }

        public bool GetUserInputItem()
        {
            if (inputItem == null)
            {
                return false;
            }
            if (!inputItem.Packable)
            {
                _printer.PrintLn(Resources.DontBeRidiculous);
                return true;
            }
            if (_items.GetTopItemByName(inputItem.Name).Location == "pack")
            {
                _printer.PrintLn(Resources.AlreadyCarryingIt);
                return true;
            }
            var items = _items.GetItemsAtLocation("pack");
            if (items.Count > 7)
            {
                _printer.PrintLn(Resources.CantCarryAnymore);
                return true;
            }
            _items.GetTopItemByName(inputItem.Name).Location = "pack";
            _printer.PrintLn(Resources.Ok);
            return true;
        }

        public bool GetItemXFromRoom(string itemID)
        {
            if (itemID == null)
            {
                return false;
            }
            var items = _items.GetItemsAtLocation("pack");
            if (!inputItem.Packable)
            {
                _printer.PrintLn(Resources.DontBeRidiculous);
                return true;
            }
            if (items.Count > 7)
            {
                _printer.PrintLn(Resources.CantCarryAnymore);
                return true;
            }
            var itemX = _items.GetExactItemByName(itemID);
            itemX.Location = "pack";
            _printer.PrintLn(Resources.Ok);
            return true;
        }

        public bool PrintInventory()
        {
            var items = _items.GetItemsAtLocation("pack");
            if (items.Count == 0)
            {
                _printer.PrintLn(Resources.NotCarryingAnything);
            }
            else
            {
                if (_settings.Trs80Mode)
                {
                    _printer.PrintLn(Resources.YouAreHolding);
                }
                foreach (var item in items)
                {
                    _printer.PrintLn(item.ShortDescription);
                }
            }
            return true;
        }

        public bool DropUserInputItem()
        {
            if (inputItem == null)
            {
                return false;
            }
            _items.GetTopItemByName(inputItem.Name).Location = _player.CurrentRoom;
            _printer.PrintLn(Resources.Ok);
            return true;
        }

        public bool DropItemX(string itemID)
        {
            var itemX = _items.GetExactItemByName(itemID);
            itemX.Location = _player.CurrentRoom;
            _printer.PrintLn(Resources.Ok);
            return true;
        }

        public bool PrintOK()
        {
            _printer.PrintLn(Resources.Ok);
            return true;
        }

        public bool JumpToTopOfGameLoop()
        {
            if (_settings.Trs80Mode)
            {
                _printer.PrintLn("Oh, no!  I lost my compass. I no longer seem to know which way is north!");

                // Run through scripts for all rooms and roll north, south, east, west directions by random offset

                // Generate random number from 0-3
                int random = GetRandomByte();
                random = random & 3;

                /* If script is a "_n", "_e", "_s", "_w" script then
                   Add random number to direction, taking
                            "_n" as 1
                            "_e" as 2
                            "_s" as 3
                            "_w" as 4
                   And result with 0x03
                   Change original room script using new number interpreting
                            0 as "_w"
                            1 as "_n"
                            2 as "_e"
                            3 as "_s"
                */


                foreach (var roomName in _rooms.GetRoomNames())
                {
                    var reKeyedCommands = new Dictionary<Function, List<object>>();
                    var keysToDelete = new List<Function>();

                    var room = _rooms.GetRoom(roomName);
                    var commands = room.Commands;
                    foreach (var key in commands.Keys)
                    {
                        if (key == Function.North || key == Function.East || key == Function.South || key == Function.West)
                        {
                            var currentKeyIndex = 0;
                            switch (key)
                            {
                                case Function.North: currentKeyIndex = 1; break;
                                case Function.East: currentKeyIndex = 2; break;
                                case Function.South: currentKeyIndex = 3; break;
                                case Function.West: currentKeyIndex = 4; break;
                            }
                            var newKeyIndex = currentKeyIndex + random;
                            newKeyIndex = newKeyIndex & 3;

                            Function newKey = Function.North;
                            switch (newKeyIndex)
                            {
                                case 0: newKey = Function.West; break;
                                case 1: newKey = Function.North; break;
                                case 2: newKey = Function.East; break;
                                case 3: newKey = Function.South; break;
                            }

                            keysToDelete.Add(key);
                            reKeyedCommands.Add(newKey, commands[key]);
                        }
                    }
                    foreach (var keyToDelete in keysToDelete)
                    {
                        commands.Remove(keyToDelete);
                    }
                    foreach (var kvp in reKeyedCommands)
                    {
                        commands.Add(kvp.Key, kvp.Value);
                    }
                }
            }
            return true;
        }

        public bool AssertRandomIsGreaterThanX(string number)
        {
            var val = GetRandomByte();
            if (Convert.ToByte(number) <= val)
            {
                _printer.PrintLn(Resources.CrawledAroundBackToMainPassage);
                Look();
                return true;
            }
            return false;
        }

        public bool MoveToRoomXIfItWasLastRoom(string roomID)
        {
            if (roomID == _gameState.LastRoom)
            {
                return MoveToRoomX(roomID);
            }
            else
            {
                return false;
            }
        }

        public bool MoveToLastRoom()
        {
            if (string.IsNullOrEmpty(_gameState.LastRoom))
            {
                _printer.PrintLn(Resources.NoLongerRememberHowYouGotHere);
            }
            return MoveToRoomX(_gameState.LastRoom);
        }

        public bool AssertPackIsEmptyExceptForEmerald()
        {
            var items = _items.GetItemsAtLocation("pack");
            if (items.Count == 0) return true;
            if (items.Count > 1) return false;
            if (items[0].Name != "#EMERALD") return false;
            return true;
        }

        private bool abortScript;
        public bool SubScriptXAbortIfPass(List<object> script)
        {
            var handled = ParseScriptRec(script);
            if (!handled)
            {
                return true;
            }
            abortScript = true;
            return true;
        }

        public bool Look()
        {
            var room = _rooms.GetRoom(_player.CurrentRoom);

            if (_rooms.IsRoomLit(_player.CurrentRoom))
            {
                _printer.PrintLn(room.Description);
                var itemsInRoom = _items.GetItemsAtLocation(_player.CurrentRoom);
                foreach (var item in itemsInRoom)
                {
                    if (!string.IsNullOrEmpty(item.LongDescription))
                    {
                        _printer.PrintLn(item.LongDescription);
                    }
                }
            }
            else
            {
                _printer.PrintLn(Resources.ItsPitchDark);
            }

            return true;
        }

        private IItem inputItem;

        public bool ParseScript(List<object> script, IItem item)
        {
            inputItem = item;
            abortScript = false;
            return ParseScriptRec(script);
        }

        public bool ParseScriptRec(List<object> script)
        {
            var ptr = 0;
            while (ptr < script.Count)
            {
                if (abortScript)
                {
                    return true;
                }

                var com = script[ptr++] as string;

                object paramX = null;
                object paramY = null;
                if (com.IndexOf("X") >= 0)
                {
                    paramX = script[ptr++];
                }
                if (com.IndexOf("Y") >= 0)
                {
                    paramY = script[ptr++];
                }

                object[] parameters = null;
                if (paramX == null && paramY == null)
                {
                    parameters = null;
                }
                else if (paramX != null && paramY == null)
                {
                    parameters = new object[] { paramX };
                }
                else if (paramX != null && paramY != null)
                {
                    parameters = new object[] { paramX, paramY };
                }

                Type scripterType = this.GetType();
                MethodInfo method = scripterType.GetTypeInfo().GetDeclaredMethod(com);
                if (method != null)
                {
                    object result = method.Invoke(this, parameters);
                    if (!((bool)result))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static Random _random = new Random();
        public byte GetRandomByte()
        {
            return (byte)(_random.Next(Byte.MaxValue + 1));
        }
    }
}
