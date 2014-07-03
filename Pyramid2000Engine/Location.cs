using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000Engine
{
    // either a room, an item, or in the player's pack.
    public abstract class Location
    {
        public static Location.Room Room_1 = new Location.Room(Resources.Room_Description_Outside_Pyramid, true);
        public static Location.Room Room_2 = new Location.Room(Resources.Room_Description_Pyramid_Entrance, true);
        public static Location.Room Room_3 = new Location.Room(Resources.Room_Description_In_The_Desert, true);
        public static Location.Room Room_4 = new Location.Room(Resources.Room_Description_In_The_Desert, true);
        public static Location.Room Room_5 = new Location.Room(Resources.Room_Description_In_The_Desert, true);
        public static Location.Room Room_6 = new Location.Room(Resources.Room_Description_In_The_Desert, true);
        public static Location.Room Room_7 = new Location.Room(Resources.Room_Description_Small_Chamber, true);
        public static Location.Room Room_16 = new Location.Room();
        public static Location.Room Room_26 = new Location.Room();
        public static Location.Room Room_51 = new Location.Room();
        public static Location.Room Room_81 = new Location.Room();

        public static Location.Pack Players_Pack = new Location.Pack();

        static Location()
        {
            Room_1.Commands.Add(Verb.North, new Script(s => s.MoveToRoomX(Location.Room_2)));
            Room_1.Commands.Add(Verb.East, new Script(s => s.MoveToRoomX(Location.Room_3)));
            Room_1.Commands.Add(Verb.South, new Script(s => s.MoveToRoomX(Location.Room_4)));
            Room_1.Commands.Add(Verb.West, new Script(s => s.MoveToRoomX(Location.Room_5)));

            Room_2.Commands.Add(Verb.South, new Script(s => s.MoveToRoomX(Location.Room_1)));
            Room_2.Commands.Add(Verb.Down, new Script(s => s.MoveToRoomX(Location.Room_7)));
            Room_2.Commands.Add(Verb.Out, new Script(s => s.MoveToRoomX(Location.Room_1)));
            Room_2.Commands.Add(Verb.Panel, new Script(s => s.MoveToRoomX(Location.Room_26)));

            Room_3.Commands.Add(Verb.North, new Script(s => s.MoveToRoomX(Location.Room_6)));
            Room_3.Commands.Add(Verb.East, new Script(s => s.MoveToRoomX(Location.Room_3)));
            Room_3.Commands.Add(Verb.South, new Script(s => s.MoveToRoomX(Location.Room_4)));
            Room_3.Commands.Add(Verb.West, new Script(s => s.MoveToRoomX(Location.Room_1)));

            Room_4.Commands.Add(Verb.North, new Script(s => s.MoveToRoomX(Location.Room_1)));
            Room_4.Commands.Add(Verb.East, new Script(s => s.MoveToRoomX(Location.Room_3)));
            Room_4.Commands.Add(Verb.South, new Script(s => s.MoveToRoomX(Location.Room_4)));
            Room_4.Commands.Add(Verb.West, new Script(s => s.MoveToRoomX(Location.Room_5)));

            Room_5.Commands.Add(Verb.North, new Script(s => s.MoveToRoomX(Location.Room_6)));
            Room_5.Commands.Add(Verb.East, new Script(s => s.MoveToRoomX(Location.Room_1)));
            Room_5.Commands.Add(Verb.South, new Script(s => s.MoveToRoomX(Location.Room_4)));
            Room_5.Commands.Add(Verb.West, new Script(s => s.MoveToRoomX(Location.Room_5)));

            Room_6.Commands.Add(Verb.North, new Script(s => s.MoveToRoomX(Location.Room_6)));
            Room_6.Commands.Add(Verb.East, new Script(s => s.MoveToRoomX(Location.Room_3)));
            Room_6.Commands.Add(Verb.South, new Script(s => s.MoveToRoomX(Location.Room_1)));
            Room_6.Commands.Add(Verb.West, new Script(s => s.MoveToRoomX(Location.Room_5)));

            Room_7.Commands.Add(Verb.Up, new Script(s => s.MoveToRoomX(Location.Room_2)));
            Room_7.Commands.Add(Verb.Out, new Script(s => s.MoveToRoomX(Location.Room_2)));
        }

        private Location() { }

        public sealed class Room : Location
        {
            public string Description { get; private set; }
            public bool Lit { get; private set; }
            public IDictionary<Verb, Script> Commands { get; set; }
            public Room(string description = "", bool lit = false) 
            {
                this.Description = description;
                this.Lit = lit;
                Commands = new Dictionary<Verb, Script>();
            }
        }

        public sealed class Pack : Location
        {
            public Pack() { }
        }

        public sealed class Container : Location
        {
            public readonly string Item;

            public Container(string item) { this.Item = item; }
        }
    }
}