using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Pyramid2000_StraightPort
{
    public class Scripter : IScripter
    {
        private IPrinter _printer;
        private IItems _items;
        private IRooms _rooms;
        private IPlayer _player;
        private IGameState _gameState;

        public Scripter(IPrinter printer, IItems items, IRooms rooms, IPlayer player, IGameState gameState)
        {
            _printer = printer;
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
                    _printer.PrintLn("YOU FELL INTO A PIT AND BROKE EVERY BONE IN YOUR BODY.");
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
                    _printer.PrintLn(@"SUDDENLY, A MUMMY CREEPS UP BEHIND YOU!! ""I'M THE KEEPER OF THE TOMB"", HE WAILS, ""I TAKE THESE TREASURES AND PUT THEM IN THE CHEST DEEP IN THE MAZE!"" HE GRABS YOUR TREASURE AND VANISHES INTO THE GLOOM.");
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
            // TODO IN TRS-80 VERSION IT LOOKS LIKE DYING SUBTRACTS FROM YOUR SCORE - NEED TO WORK THIS OUT
            _printer.PrintLn("OH DEAR, YOU SEEM TO HAVE GOTTEN YOURSELF KILLED.  I MIGHT BE ABLE TO HELP YOU OUT, BUT I'VE NEVER REALLY DONE THIS BEFORE.");
            _printer.PrintLn("DO YOU WANT ME TO TRY TO REINCARNATE YOU?");
            // TODO WHAT CAN USER DO TO BE REINCARNATED?
            PrintScoreImpl(-10);
            _gameState.GameOver = true;
            return true;
        }

        public bool MoveItemXToLocationY(string itemID, string locationID)
        {
            var itemX = _items.GetExactItemByName(itemID);
            itemX.Location = locationID;
            _printer.PrintLn("OK");
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

            _printer.PrintLn(String.Format("YOU HAVE SCORED {0: 0000;-0000} OUT OF 0220, USING {1:0000} TURNS.", score, _gameState.TurnCount));

            return true;
        }

        public bool AssertItemXMatchesUserInput(string itemID)
        {
            return (itemID == inputItem.Name);
        }

        public bool GetUserInputItem()
        {
            if (!inputItem.Packable)
            {
                _printer.PrintLn("DON'T BE RIDICULOUS!");
                return true;
            }
            if (_items.GetTopItemByName(inputItem.Name).Location == "pack")
            {
                _printer.PrintLn("YOU ARE ALREADY CARRYING IT.");
                return true;
            }
            var items = _items.GetItemsAtLocation("pack");
            if (items.Count > 7)
            {
                _printer.PrintLn("YOU CAN'T CARRY ANYTHING MORE. YOU'LL HAVE TO DROP SOMETHING FIRST.");
                return true;
            }
            _items.GetTopItemByName(inputItem.Name).Location = "pack";
            _printer.PrintLn("OK");
            return true;
        }

        public bool GetItemXFromRoom(string itemID)
        {
            var items = _items.GetItemsAtLocation("pack");
            if (!inputItem.Packable)
            {
                _printer.PrintLn("DON'T BE RIDICULOUS!");
                return true;
            }
            if (items.Count > 7)
            {
                _printer.PrintLn("YOU CAN'T CARRY ANYTHING MORE. YOU'LL HAVE TO DROP SOMETHING FIRST.");
                return true;
            }
            var itemX = _items.GetExactItemByName(itemID);
            itemX.Location = "pack";
            _printer.PrintLn("OK");
            return true;
        }

        public bool PrintInventory()
        {
            var items = _items.GetItemsAtLocation("pack");
            if (items.Count == 0)
            {
                _printer.PrintLn("YOU'RE NOT CARRYING ANYTHING.");
            }
            else
            {
                foreach (var item in items)
                {
                    _printer.PrintLn(item.ShortDescription);
                }
            }
            return true;
        }

        public bool DropUserInputItem()
        {
            _items.GetTopItemByName(inputItem.Name).Location = _player.CurrentRoom;
            _printer.PrintLn("OK");
            return true;
        }

        public bool DropItemX(string itemID)
        {
            var itemX = _items.GetExactItemByName(itemID);
            itemX.Location = _player.CurrentRoom;
            _printer.PrintLn("OK");
            return true;
        }

        public bool PrintOK()
        {
            _printer.PrintLn("OK");
            return true;
        }

        public bool JumpToTopOfGameLoop()
        {
            return true;
        }

        public bool AssertRandomIsGreaterThanX(string number)
        {
            var val = GetRandomByte();
            if (Convert.ToUInt16(number) <= val)
            {
                _printer.PrintLn("YOU HAVE CRAWLED AROUND IN SOME LITTLE HOLES AND WOUND UP BACK IN THE MAIN PASSAGE.");
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
                _printer.PrintLn("SORRY, BUT I NO LONGER SEEM TO REMEMBER HOW IT WAS YOU GOT HERE.");
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

        //TODO SaveGame
        //TODO LoadGame

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
                _printer.PrintLn("IT IS NOW PITCH DARK.  IF YOU PROCEED, YOU WILL LIKELY FALL INTO A PIT.");
            }

            return true;
        }

        private Item inputItem;

        public bool ParseScript(List<object> script, Item item)
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
                object result = method.Invoke(this, parameters);
                if (!((bool)result))
                {
                    return false;
                }
            }

            return true;
        }

        private uint randomSeed = 0x00FACEDE;
        public uint GetRandomByte()
        {
            for (var x = 0; x < 8; x++)
            {
                var a = (randomSeed >> 16) & 255;
                a = a & 0xE1;
                var b = 0U;
                for (var y = 0; y < 8; y++)
                {
                    a = a << 1;
                    if (a > 255)
                    {
                        b += 1;
                        a = a & 255;
                    }
                }


                randomSeed = randomSeed << 1;
                randomSeed = randomSeed & 0x00FFFFFF;
                randomSeed = randomSeed | (b & 1);
            }


            return randomSeed & 255;
        }
    }
}
