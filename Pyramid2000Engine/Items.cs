using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000Engine
{
    public class Items : IItems
    {
        private Item[] items = new Item[] {
          new Item{ Name = "#bridge_15", LongDescription = "A STONE BRIDGE NOW SPANS THE BOTTOMLESS PIT." },
          new Item{ Name = "#bridge_18", LongDescription = "A STONE BRIDGE NOW SPANS THE BOTTOMLESS PIT." },
          new Item{ Name = "#-3-" },
          new Item{ Name = "#-4-" },
          new Item{ Name = "#-5-" },
          new Item{ Name = "#MACHINE", Location = "room_51", LongDescription = "THERE IS A MASSIVE VENDING MACHINE HERE. THE INSTRUCTIONS ON IT READ \"DROP COINS HERE TO RECEIVE FRESH BATTERIES\"." },
          new Item{ Name = "#PLANT_A", Location = "room_81", LongDescription = "THERE IS A TINY PLANT IN THE PIT, MURMURING \"WATER, WATER, ...\"" },
          new Item{ Name = "#PLANT_B", LongDescription = "THERE IS A TWELVE FOOT BEAN STALK STRETCHING UP OUT OF THE PIT, BELLOWING \"WATER... WATER...\"" },
          new Item{ Name = "#PLANT_C", Location = "room_81", LongDescription = "THERE IS A GIGANTIC BEAN STALK STRETCHING ALL THE WAY UP TO THE HOLE." },
          new Item{ Name = "#-10-" },
          new Item{ Name = "#SERPENT", Location = "room_16", LongDescription = "A HUGE GREEN FIERCE SERPENT BARS THE WAY!" },
          new Item{ Name = "#-12-" },
          new Item{ Name = "#-13-" },
          new Item{ Name = "#LAMP_off", Location = "room_2", IsPackable = true, ShortDescription = "BRASS LANTERN", LongDescription = "THERE IS A SHINY BRASS LAMP NEARBY." },
          new Item{ Name = "#LAMP_on", IsPackable = true, ShortDescription = "BRASS LANTERN", LongDescription = "THERE IS A LAMP SHINING NEARBY." },
          new Item{ Name = "#FOOD", Location = "room_2", IsPackable = true, ShortDescription = "TASTY FOOD", LongDescription = "THERE IS FOOD HERE." },
          new Item{ Name = "#BOTTLE", Location = "room_2", IsPackable = true, ShortDescription = "WATER IN THE BOTTLE", LongDescription = "THERE IS WATER IN THE BOTTLE." }
        };

        private IDictionary<Noun, string[]> NounItemMap = new Dictionary<Noun, string[]>();

        public Items()
        {
            NounItemMap.Add(Noun.Lamp, new string[] { "#LAMP_off", "#LAMP_ON", "#LAMP_dead" });
            NounItemMap.Add(Noun.Box, new string[] { "#BOX" });
            NounItemMap.Add(Noun.Scepter, new string[] { "#SCEPTER" });
            NounItemMap.Add(Noun.Bird, new string[] { "#BIRD", "#BIRD_boxed" });
            NounItemMap.Add(Noun.Pillow, new string[] { "#PILLOW" });
            NounItemMap.Add(Noun.Sarcophagus, new string[] { "#SARCOPH_full", "#SARCOPH_empty" });
            NounItemMap.Add(Noun.Magazines, new string[] { "#MAGAZINES" });
            NounItemMap.Add(Noun.Food, new string[] { "#FOOD" });
            NounItemMap.Add(Noun.Bottle, new string[] { "#BOTTLE" });
            NounItemMap.Add(Noun.Water, new string[] { "#WATER", "#STREAM_56" });
            NounItemMap.Add(Noun.Plant, new string[] { "#PLANT_A", "#PLANT_B", "#PLANT_C" });
            NounItemMap.Add(Noun.Machine, new string[] { "#MACHINE" });
            NounItemMap.Add(Noun.Batteries, new string[] { "#BATTERIES_fresh", "#BATTERIES_worn" });
            NounItemMap.Add(Noun.Gold, new string[] { "#GOLD" });
            NounItemMap.Add(Noun.Diamonds, new string[] { "#DIAMOONDS" });
            NounItemMap.Add(Noun.Silver, new string[] { "#SILVER" });
            NounItemMap.Add(Noun.Jewelry, new string[] { "#JEWELRY" });
            NounItemMap.Add(Noun.Coins, new string[] { "#COINS" });
            NounItemMap.Add(Noun.Chest, new string[] { "#CHEST" });
            NounItemMap.Add(Noun.Nest, new string[] { "#NEST" });
            NounItemMap.Add(Noun.Key, new string[] { "#KEY" });
            NounItemMap.Add(Noun.Vase, new string[] { "#VASE_pillow", "#VASE_solo" });
            NounItemMap.Add(Noun.Pottery, new string[] { "#POTTERY" });
            NounItemMap.Add(Noun.Emerald, new string[] { "#EMERALD" });
            NounItemMap.Add(Noun.Pearl, new string[] { "#PEARL" });
        }

        public Item GetInputItem(Noun noun, Predicate<string> locationPredicate)
        {
            foreach (var itemName in NounItemMap[noun])
            {
                var item = GetItemByName(itemName);
                if (item != null)
                {
                    var packItem = GetTopItemByName(item.Name);
                    if (packItem != null)
                    {
                        if (locationPredicate(packItem.Location))
                        {
                            return item;
                        }
                    }
                }
            }
            return null;
        }

        public Item GetItemByName(string name)
        {
            return items.SingleOrDefault<Item>(item => item.Name == name);
        }

        public Item GetTopItemByName(string name)
        {
            var item = GetItemByName(name);
            if (item != null && item.Location[0] == '#')
                item = GetTopItemByName(item.Location);
            return item;
        }

        public IList<Item> GetAllItems()
        {
            return items.ToList<Item>();
        }

        public IList<Item> GetItemsAtLocation(string location)
        {
            return items.Where<Item>(item => item.Location == location).ToList<Item>();
        }
    }
}
