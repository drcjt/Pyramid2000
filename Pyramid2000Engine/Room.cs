using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000Engine
{
    public class Room
    {
        public string Description { get; private set; }
        public bool Lit { get; private set; }
        public IDictionary<Verb, Script> Commands = new Dictionary<Verb, Script>();

        public Room(string description)
        {
            Description = description;
        }

        public static IDictionary<String, Room> Rooms = new Dictionary<String, Room>();

        static Room()
        {
            Rooms["room_1"] = new Room("YOU ARE STANDING BEFORE THE ENTRANCE OF A PYRAMID. AROUND YOU IS A DESERT.");
            Rooms["room_1"].Lit = true;
            Rooms["room_1"].Commands.Add(Verb.North, new Script(s => s.MoveToRoomX("room_2")));
            Rooms["room_1"].Commands.Add(Verb.East, new Script(s => s.MoveToRoomX("room_3")));
            Rooms["room_1"].Commands.Add(Verb.South, new Script(s => s.MoveToRoomX("room_4")));
            Rooms["room_1"].Commands.Add(Verb.West, new Script(s => s.MoveToRoomX("room_5")));

            Rooms["room_2"] = new Room("YOU ARE STANDING IN THE ENTRANCE OF THE PYRAMID. A HOLE IN THE FLOOR LEADS TO A PASSAGE BENEATH THE SURFACE.");
            Rooms["room_2"].Lit = true;
            Rooms["room_2"].Commands.Add(Verb.South, new Script(s => s.MoveToRoomX("room_1")));
            Rooms["room_2"].Commands.Add(Verb.Down, new Script(s => s.MoveToRoomX("room_7")));
            Rooms["room_2"].Commands.Add(Verb.Out, new Script(s => s.MoveToRoomX("room_1")));
            Rooms["room_2"].Commands.Add(Verb.Panel, new Script(s => s.MoveToRoomX("room_26")));

            Rooms["room_3"] = new Room("YOU ARE IN THE DESERT.");
            Rooms["room_3"].Lit = true;
            Rooms["room_3"].Commands.Add(Verb.North, new Script(s => s.MoveToRoomX("room_6")));
            Rooms["room_3"].Commands.Add(Verb.East, new Script(s => s.MoveToRoomX("room_3")));
            Rooms["room_3"].Commands.Add(Verb.South, new Script(s => s.MoveToRoomX("room_4")));
            Rooms["room_3"].Commands.Add(Verb.West, new Script(s => s.MoveToRoomX("room_1")));

            Rooms["room_4"] = new Room("YOU ARE IN THE DESERT.");
            Rooms["room_4"].Lit = true;
            Rooms["room_4"].Commands.Add(Verb.North, new Script(s => s.MoveToRoomX("room_1")));
            Rooms["room_4"].Commands.Add(Verb.East, new Script(s => s.MoveToRoomX("room_3")));
            Rooms["room_4"].Commands.Add(Verb.South, new Script(s => s.MoveToRoomX("room_4")));
            Rooms["room_4"].Commands.Add(Verb.West, new Script(s => s.MoveToRoomX("room_5")));

            Rooms["room_5"] = new Room("YOU ARE IN THE DESERT.");
            Rooms["room_5"].Lit = true;
            Rooms["room_5"].Commands.Add(Verb.North, new Script(s => s.MoveToRoomX("room_6")));
            Rooms["room_5"].Commands.Add(Verb.East, new Script(s => s.MoveToRoomX("room_1")));
            Rooms["room_5"].Commands.Add(Verb.South, new Script(s => s.MoveToRoomX("room_4")));
            Rooms["room_5"].Commands.Add(Verb.West, new Script(s => s.MoveToRoomX("room_5")));

            Rooms["room_6"] = new Room("YOU ARE IN THE DESERT.");
            Rooms["room_6"].Lit = true;
            Rooms["room_6"].Commands.Add(Verb.North, new Script(s => s.MoveToRoomX("room_6")));
            Rooms["room_6"].Commands.Add(Verb.East, new Script(s => s.MoveToRoomX("room_3")));
            Rooms["room_6"].Commands.Add(Verb.South, new Script(s => s.MoveToRoomX("room_1")));
            Rooms["room_6"].Commands.Add(Verb.West, new Script(s => s.MoveToRoomX("room_5")));

            Rooms["room_7"] = new Room("YOU ARE IN A SMALL CHAMBER BENEATH A HOLE FROM THE SURFACE. A LOW CRAWL LEADS INWARDS TO THE WEST. HIEROGLYPHICS ON THE WALL TRANSLATE, \"CURSE ALL WHO ENTER THIS SACRED CRYPT.\"");
            Rooms["room_7"].Lit = true;
            Rooms["room_7"].Commands.Add(Verb.Up, new Script(s => s.MoveToRoomX("room_2")));
            Rooms["room_7"].Commands.Add(Verb.Out, new Script(s => s.MoveToRoomX("room_2")));
        }
    }
}
