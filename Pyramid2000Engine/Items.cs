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
          new Item{ Name = "#bridge_15", LongDescription = Resources.Item_Description_Stone_Bridge },
          new Item{ Name = "#bridge_18", LongDescription = Resources.Item_Description_Stone_Bridge },
          new Item{ Name = "#-3-" },
          new Item{ Name = "#-4-" },
          new Item{ Name = "#-5-" },
          new Item{ Name = "#MACHINE", Location = Location.Room_51, LongDescription = Resources.Item_Description_Vending_Machine },
          new Item{ Name = "#PLANT_A", Location = Location.Room_81, LongDescription = Resources.Item_Description_Tiny_Plant },
          new Item{ Name = "#PLANT_B", LongDescription = Resources.Item_Description_Beanstalk },
          new Item{ Name = "#PLANT_C", Location = Location.Room_81, LongDescription = Resources.Item_Description_Gigantic_Beanstalk },
          new Item{ Name = "#-10-" },
          new Item{ Name = "#SERPENT", Location = Location.Room_16, LongDescription = Resources.Item_Descrption_Serpent },
          new Item{ Name = "#-12-" },
          new Item{ Name = "#-13-" },
          new Item{ Name = "#LAMP_off", Location = Location.Room_2, IsPackable = true, ShortDescription = Resources.Item_Description_Brass_Lantern, LongDescription = Resources.Item_Description_Shiny_Lamp },
          new Item{ Name = "#LAMP_on", IsPackable = true, ShortDescription = Resources.Item_Description_Brass_Lantern, LongDescription = Resources.Item_Description_Shining_Lamp },
          new Item{ Name = "#FOOD", Location = Location.Room_2, IsPackable = true, ShortDescription = Resources.Item_Description_Food, LongDescription = Resources.Item_Description_Food_Here },
          new Item{ Name = "#BOTTLE", Location = Location.Room_2, IsPackable = true, ShortDescription = Resources.Item_Description_Water, LongDescription = Resources.Item_Description_Water_In_Bottle }
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

        public Item GetInputItem(Noun noun, Predicate<Location> locationPredicate)
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
            if (item != null && item.Location is Location.Container)
                item = GetTopItemByName(((Location.Container)item.Location).Item);
            return item;
        }

        public IList<Item> GetAllItems()
        {
            return items.ToList<Item>();
        }

        public IList<Item> GetItemsAtLocation(Location location)
        {
            return items.Where<Item>(item => item.Location == location).ToList<Item>();
        }
    }
}
