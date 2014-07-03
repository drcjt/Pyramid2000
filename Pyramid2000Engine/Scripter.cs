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

        public bool MoveToRoomX(Location.Room room)
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
            printer.PrintLn(game.CurrentRoom.Description);

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
            var itemsInPack = game.Items.GetItemsAtLocation(Location.Players_Pack);
            if (itemsInPack.Count == 0)
            {
                printer.PrintLn(Resources.Message_Not_Carrying_Anything);
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
                PrintMessageX(Resources.Message_Plant_Has_Deep_Roots);
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
            printer.PrintLn(Resources.Message_OK);
            return true;
        }

        public bool MoveToLastRoom()
        {
            if (game.LastRoom == null)
            {
                printer.PrintLn(Resources.Message_Cant_Go_Back);
                return true;
            }

            return MoveToRoomX(game.LastRoom);
        }

        public bool GetUserInputItem()
        {
            if (inputItem != null)
            {
                if (game.Items.GetTopItemByName(inputItem.Name).Location == Location.Players_Pack)
                {
                    printer.PrintLn(Resources.Message_Already_Carrying);
                    return true;
                }

                if (game.Items.GetItemsAtLocation(Location.Players_Pack).Count > 7)
                {
                    printer.PrintLn(Resources.Message_Cant_Carry_Anymore);
                    return true;
                }
                game.Items.GetTopItemByName(inputItem.Name).Location = Location.Players_Pack;
                printer.PrintLn(Resources.Message_OK);
                return true;
            }
            return false;
        }

        public bool PrintScore()
        {
            var score = 0;
            printer.PrintLn(String.Format(Resources.Message_Score, score));
            printer.PrintLn(String.Format(Resources.Message_Turns_Used, game.TurnCount));

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
