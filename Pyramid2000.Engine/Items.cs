using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine
{
    public class Items : IItems
    {
        private Item[] _itemData = new Item[] 
        {
            new Item() { Name = "#bridge_15", Location = "", Packable = false, Treasure = false, LongDescription = Resources.BridgeAppears},
            new Item() { Name = "#bridge_18", Location = "", Packable = false, Treasure = false, LongDescription = Resources.BridgeAppears},
            new Item() { Name = "#-3-", Location = "", Packable = false, Treasure = false },
            new Item() { Name = "#-4-", Location = "", Packable = false, Treasure = false },
            new Item() { Name = "#-5-", Location = "", Packable = false, Treasure = false },
            new Item() { Name = "#MACHINE", Location = "room_51", Packable = false, Treasure = false, LongDescription = Resources.VendingMachine },
            new Item() { Name = "#PLANT_A", Location = "room_81", Packable = false, Treasure = false, LongDescription = Resources.PlantMurmuring },
            new Item() { Name = "#PLANT_B", Location = "", Packable = false, Treasure = false, LongDescription = Resources.PlantBellowing },
            new Item() { Name = "#PLANT_C", Location = "", Packable = false, Treasure =  false, LongDescription = Resources.GiganticBeanStalk },
            new Item() { Name = "#-10-", Location = "", Packable = false, Treasure = false },
            new Item() { Name = "#SERPENT", Location = "room_16", Packable = false, Treasure = false, LongDescription = Resources.BarredBySerpent },
            new Item() { Name = "#-12-", Location = "", Packable = false, Treasure = false },
            new Item() { Name = "#-13-", Location = "", Packable = false, Treasure = false },
            new Item() { Name = "#LAMP_off", Location = "room_2", Packable = true, Treasure = false, ShortDescription = Resources.BrassLantern, LongDescription = Resources.ShinyBrassLamp },
            new Item() { Name = "#LAMP_on", Location = "", Packable = true, Treasure = false, ShortDescription = Resources.BrassLantern, LongDescription = Resources.LampShining, Time = 310 },
            new Item() { Name = "#BOX", Location = "room_8", Packable = true, Treasure = false, ShortDescription = Resources.StatueBox, LongDescription = Resources.DiscardedStatueBox },
            new Item() { Name = "#SCEPTER", Location = "room_9", Packable = true, Treasure = false, ShortDescription = "SCEPTER", LongDescription = "A THREE FOOT SCEPTER WITH AN ANKH ON AN END LIES NEARBY." },
            new Item() { Name = "#PILLOW", Location = "room_72", Packable = true, Treasure = false, ShortDescription = "VELVET PILLOW", LongDescription = "A SMALL VELVET PILLOW LIES ON THE FLOOR." },
            new Item() { Name = "#BIRD", Location = "room_11", Packable = true, Treasure = false, ShortDescription = "THERE IS A BIRD STATUE IN THE BOX.", LongDescription = "A STATUE OF THE BIRD GOD IS SITTING HERE." },
            new Item() { Name = "#BIRD_boxed", Location = "", Packable = false, Treasure = false, ShortDescription = "THERE IS A BIRD STATUE IN THE BOX.", LongDescription = "THERE IS A BIRD STATUE IN THE BOX." },
            new Item() { Name = "#POTTERY", Location = "", Packable = false, Treasure = false, LongDescription = "THE FLOOR IS LITTERED WITH WORTHLESS SHARDS OF POTTERY." },
            new Item() { Name = "#PEARL", Location = "", Packable = true, Treasure = true, ShortDescription = "GLISTENING PEARL", LongDescription = "OFF TO ONE SIDE LIES A GLISTENING PEARL!" },
            new Item() { Name = "#SARCOPH_full", Location = "room_61", Packable = true, Treasure = false, ShortDescription = "SARCOPHAGUS >GROAN<", LongDescription = "THERE IS A SARCOPHAGUS HERE WITH IT'S COVER TIGHTLY CLOSED." },
            new Item() { Name = "#SARCOPH_empty", Location = "", Packable = true, Treasure = false, ShortDescription = "SARCOPHAGUS >GROAN<", LongDescription = "THERE IS A SARCOPHAGUS HERE WITH IT'S COVER TIGHTLY CLOSED." },
            new Item() { Name = "#MAGAZINES", Location = "room_59", Packable = true, Treasure = false, ShortDescription = @"""EGYPTIAN WEEKLY""", LongDescription = @"THERE ARE A FEW RECENT ISSUES OF ""EGYPTIAN WEEKLY"" MAGAZINE HERE." },
            new Item() { Name = "#FOOD", Location = "room_2", Packable = true, Treasure = false, ShortDescription = "TASTY FOOD", LongDescription = "THERE IS FOOD HERE." },
            new Item() { Name = "#BOTTLE", Location = "room_2", Packable = true, Treasure = false, ShortDescription = "SMALL BOTTLE", LongDescription = "THERE IS A BOTTLE HERE." },
            new Item() { Name = "#WATER", Location = "#BOTTLE", Packable = true, Treasure = false, ShortDescription = "WATER IN THE BOTTLE", LongDescription = "THERE IS WATER IN THE BOTTLE." },
            new Item() { Name = "#-29-", Location = "", Packable = false, Treasure = false },
            new Item() { Name = "#stream_56", Location = "room_56", Packable = false, Treasure = false },
            new Item() { Name = "#EMERALD", Location = "room_76", Packable = true, Treasure = true, ShortDescription = "EGG-SIZED EMERALD", LongDescription = "THERE IS AN EMERALD HERE THE SIZE OF A PLOVER'S EGG!" },
            new Item() { Name = "#VASE_pillow", Location = "", Packable = true, Treasure = true, ShortDescription = "VASE\n", LongDescription = "THE VASE IS NOW RESTING, DELICATELY, ON A VELVET PILLOW." },
            new Item() { Name = "#VASE_solo", Location = "room_73", Packable = true, Treasure = true, ShortDescription = "VASE", LongDescription = "THERE IS A DELICATE, PRECIOUS, VASE HERE!" },
            new Item() { Name = "#KEY", Location = "room_68", Packable = true, Treasure = true, ShortDescription = "JEWELED KEY", LongDescription = "THERE IS A JEWEL-ENCRUSTED KEY HERE!" },
            new Item() { Name = "#BATTERIES_fresh", Location = "", Packable = true, Treasure = false, ShortDescription = "BATTERIES", LongDescription = "THERE ARE FRESH BATTERIES HERE." },
            new Item() { Name = "#BATTERIES_worn", Location = "", Packable = true, Treasure = false, ShortDescription = "BATTERIES", LongDescription = "SOME WORN-OUT BATTERIES HAVE BEEN DISCARDED NEARBY." },
            new Item() { Name = "#GOLD", Location = "room_14", Packable = true, Treasure = true, ShortDescription = "LARGE GOLD NUGGET", LongDescription = "THERE IS A LARGE SPARKLING NUGGET OF GOLD HERE!" },
            new Item() { Name = "#DIAMONDS", Location = "room_17", Packable = true, Treasure = true, ShortDescription = "SEVERAL DIAMONDS", LongDescription = "THERE ARE DIAMONDS HERE!" },
            new Item() { Name = "#SILVER", Location = "room_25", Packable = true, Treasure = true, ShortDescription = "SILVER BARS", LongDescription = "THERE ARE BARS OF SILVER HERE!" },
            new Item() { Name = "#JEWELRY", Location = "room_18", Packable = true, Treasure = true, ShortDescription = "PRECIOUS JEWELRY", LongDescription = "THERE IS PRECIOUS JEWELRY HERE!" },
            new Item() { Name = "#COINS", Location = "room_24", Packable = true, Treasure = true, ShortDescription = "RARE COINS", LongDescription = "THERE ARE MANY COINS HERE!" },
            new Item() { Name = "#CHEST", Location = "", Packable = true, Treasure = true, ShortDescription = "TREASURE CHEST", LongDescription = "THE PHARAOH'S TREASURE CHEST IS HERE!" },
            new Item() { Name = "#NEST", Location = "room_71", Packable = true, Treasure = true, ShortDescription = "GOLDEN EGGS", LongDescription = "THERE IS A LARGE NEST HERE, FULL OF GOLDEN EGGS!" },
            new Item() { Name = "#LAMP_dead", Location = "", Packable = true, Treasure = false, ShortDescription = "BRASS LANTERN", LongDescription = "THERE IS A SHINY BRASS LAMP NEARBY." }
        };

        public Item GetExactItemByName(string name)
        {
            for (var x = 0; x < _itemData.Length; x++)
            {
                if (_itemData[x].Name == name)
                {
                    return _itemData[x];
                }
            }

            return null;
        }

        public Item GetTopItemByName(string name)
        {
            var item = GetExactItemByName(name);
            if (!string.IsNullOrEmpty(item.Location) && item.Location.StartsWith("#"))
            {
                item = GetTopItemByName(item.Location);
            }

            return item;
        }

        public Item[] GetAllItems()
        {
            return _itemData;
        }

        public IList<Item> GetItemsAtLocation(string location)
        {
            IList<Item> items = new List<Item>();

            for (var x = 0; x < _itemData.Length; x++)
            {
                if (GetTopItemByName(_itemData[x].Name).Location == location)
                {
                    items.Add(_itemData[x]);
                }
            }

            return items;
        }
    }
}
