using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Pyramid2000Engine
{
    public delegate bool Script(Scripter scripter);

    public class Scripter
    {
        private IPrinter printer;
        private Game game;

        public Item inputItem { get; set; }

        public Scripter(IPrinter printer, Game game)
        {
            this.printer = printer;
            this.game = game;
        }

        public bool MoveToRoomX(String room)
        {
            game.LastRoom = game.CurrentRoom;
            game.CurrentRoom = room;
            Look();

            return true;
        }

        public bool PrintMessageX(String message)
        {
            printer.PrintLn(message);
            return true;
        }

        public bool PrintRoomDescription()
        {
            Look();
            return true;
        }

        public void Look()
        {
            var room = Room.Rooms[game.CurrentRoom];
            printer.PrintLn(room.Description);

            var itemsInRoom = game.Items.GetItemsAtLocation(game.CurrentRoom);
            foreach (var item in itemsInRoom)
            {
                if (item.LongDescription != null)
                {
                    printer.PrintLn(item.LongDescription);
                }
            }
        }

        public bool PrintInventory()
        {
            var itemsInPack = game.Items.GetItemsAtLocation("pack");
            if (itemsInPack.Count == 0)
            {
                printer.PrintLn("YOU'RE NOT CARRYING ANYTHING.");
            }
            else
            {
                foreach (var item in itemsInPack)
                {
                    printer.PrintLn(item.ShortDescription);
                }
            }

            return true;
        }

        private bool UserInputItemIs(string itemName)
        {
            return itemName == inputItem.Name;
        }

        public bool GetScript()
        {
            if (UserInputItemIs("#PLANT_A"))
            {
                PrintMessageX("THE PLANT HAS EXCEPTIONALLY DEEP ROOTS AND CANNOT BE PULLED FREE");
                return true;
            }
            if (UserInputItemIs("#BIRD"))
            {
                return false;
            }
            if (UserInputItemIs("#VASE_pillow"))
            {
                return false;
            }
            if (UserInputItemIs("#stream_56"))
            {
                return false;
            }
            if (UserInputItemIs("#PILLOW"))
            {
                return false;
            }

            return GetUserInputItem();
        }

        public bool DropScript()
        {
            if (UserInputItemIs("#VASE_solo"))
            {

            }
            return DropUserInputItem();
        }

        public bool DropUserInputItem()
        {
            game.Items.GetTopItemByName(inputItem.Name).Location = game.CurrentRoom;
            printer.PrintLn("OK");
            return true;
        }

        public bool MoveToLastRoom()
        {
            if (game.LastRoom == null)
            {
                printer.PrintLn("SORRY, BUT I NO LONGER SEEM TO REMEMBER HOW IT WAS YOU GOT HERE.");
                return true;
            }

            return MoveToRoomX(game.LastRoom);
        }

        public bool GetUserInputItem()
        {
            if (inputItem != null)
            {
                if (game.Items.GetTopItemByName(inputItem.Name).Location == "pack")
                {
                    printer.PrintLn("YOU ARE ALREADY CARRYING IT.");
                    return true;
                }

                if (game.Items.GetItemsAtLocation("#pack").Count > 7)
                {
                    printer.PrintLn("YOU CAN'T CARRY ANYTHING MORE. YOU'LL HAVE TO DROP SOMETHING FIRST.");
                    return true;
                }
                game.Items.GetTopItemByName(inputItem.Name).Location = "pack";
                printer.PrintLn("OK");
                return true;
            }
            return false;
        }

        public bool ParseScript(String[] script)
        {
            var ptr = 0;
            while (ptr < script.Length)
            {
                string com = script[ptr++];
                string x = null;
                string y = null;

                int parameterCount = 0;

                if (com.IndexOf('X') >= 0)
                {
                    x = script[ptr++];
                    parameterCount++;
                }
                if (com.IndexOf('Y') >= 0)
                {
                    y = script[ptr++];
                    parameterCount++;
                }

                Type[] parameterTypes = new Type[parameterCount];
                for(int parameterIndex = 0; parameterIndex < parameterCount; parameterIndex++)
                {
                    parameterTypes[parameterIndex] = Type.GetType("System.String");
                }

                Object[] parameters = new Object[parameterCount];
                if (x != null)
                {
                    parameters[0] = x;
                }
                if (y != null)
                {
                    parameters[x != null ? 1 : 0] = y;
                }

                Type myType = GetType();
                MethodInfo scriptMethod = myType.GetRuntimeMethod(com, parameterTypes);

                bool scriptResult = (bool)(scriptMethod.Invoke(this, parameters));
                if (!scriptResult)
                {
                    return false;
                }
            }

            return true;
        }

        public bool PrintScore()
        {
            var score = 0;
            printer.PrintLn(String.Format("YOU HAVE SCORED {0} OUT OF 220.", score));
            printer.PrintLn(String.Format("USING {0} TURNS.", game.TurnCount));

            return true;
        }

        public bool Quit()
        {
            PrintScore();

            game.GameOver = true;

            return true;
        }
    }
}
