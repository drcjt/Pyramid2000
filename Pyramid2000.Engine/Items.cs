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
            new Item() { Name = "#SCEPTER", Location = "room_9", Packable = true, Treasure = false, ShortDescription = Resources.Scepter, LongDescription = Resources.ThreeFootScepter },
            new Item() { Name = "#PILLOW", Location = "room_72", Packable = true, Treasure = false, ShortDescription = Resources.Pillow, LongDescription = Resources.SmallVelvetPillow },
            new Item() { Name = "#BIRD", Location = "room_11", Packable = true, Treasure = false, ShortDescription = Resources.StatueInBox, LongDescription = Resources.StatueOfBirdGod },
            new Item() { Name = "#BIRD_boxed", Location = "", Packable = false, Treasure = false, ShortDescription = Resources.StatueInBox, LongDescription = Resources.StatueInBox },
            new Item() { Name = "#POTTERY", Location = "", Packable = false, Treasure = false, LongDescription = Resources.FloorLitteredWithShards },
            new Item() { Name = "#PEARL", Location = "", Packable = true, Treasure = true, ShortDescription = Resources.GlisteningPearl, LongDescription = Resources.GlisteningPearlLongDesc },
            new Item() { Name = "#SARCOPH_full", Location = "room_61", Packable = true, Treasure = false, ShortDescription = Resources.Sarcophagus, LongDescription = Resources.SarcophagusLongDesc },
            new Item() { Name = "#SARCOPH_empty", Location = "", Packable = true, Treasure = false, ShortDescription = Resources.Sarcophagus, LongDescription = Resources.SarcophagusLongDesc },
            new Item() { Name = "#MAGAZINES", Location = "room_59", Packable = true, Treasure = false, ShortDescription = Resources.Magazine, LongDescription = Resources.MagazineLongDesc },
            new Item() { Name = "#FOOD", Location = "room_2", Packable = true, Treasure = false, ShortDescription = Resources.Food, LongDescription = Resources.FoodLongDesc },
            new Item() { Name = "#BOTTLE", Location = "room_2", Packable = true, Treasure = false, ShortDescription = Resources.Bottle, LongDescription = Resources.BottleLongDesc },
            new Item() { Name = "#WATER", Location = "#BOTTLE", Packable = true, Treasure = false, ShortDescription = Resources.Water, LongDescription = Resources.WaterLongDesc },
            new Item() { Name = "#-29-", Location = "", Packable = false, Treasure = false },
            new Item() { Name = "#stream_56", Location = "room_56", Packable = false, Treasure = false },
            new Item() { Name = "#EMERALD", Location = "room_76", Packable = true, Treasure = true, ShortDescription = Resources.Emerald, LongDescription = Resources.EmeraldLongDesc },
            new Item() { Name = "#VASE_pillow", Location = "", Packable = true, Treasure = true, ShortDescription = Resources.Vase, LongDescription = Resources.VasePillowLongDesc },
            new Item() { Name = "#VASE_solo", Location = "room_73", Packable = true, Treasure = true, ShortDescription = Resources.Vase, LongDescription = Resources.VaseSoloLongDesc },
            new Item() { Name = "#KEY", Location = "room_68", Packable = true, Treasure = true, ShortDescription = Resources.Key, LongDescription = Resources.KeyLongDesc },
            new Item() { Name = "#BATTERIES_fresh", Location = "", Packable = true, Treasure = false, ShortDescription = Resources.Batteries, LongDescription = Resources.BatteriesFreshLongDesc },
            new Item() { Name = "#BATTERIES_worn", Location = "", Packable = true, Treasure = false, ShortDescription = Resources.Batteries, LongDescription = Resources.BatteriesWornLongDesc },
            new Item() { Name = "#GOLD", Location = "room_14", Packable = true, Treasure = true, ShortDescription = Resources.Gold, LongDescription = Resources.GoldLongDesc },
            new Item() { Name = "#DIAMONDS", Location = "room_17", Packable = true, Treasure = true, ShortDescription = Resources.Diamonds, LongDescription = Resources.DiamondsLongDesc },
            new Item() { Name = "#SILVER", Location = "room_25", Packable = true, Treasure = true, ShortDescription = Resources.Silver, LongDescription = Resources.SilverLongDesc },
            new Item() { Name = "#JEWELRY", Location = "room_18", Packable = true, Treasure = true, ShortDescription = Resources.Jewelry, LongDescription = Resources.JewelryLongDesc },
            new Item() { Name = "#COINS", Location = "room_24", Packable = true, Treasure = true, ShortDescription = Resources.Coins, LongDescription = Resources.Coins },
            new Item() { Name = "#CHEST", Location = "", Packable = true, Treasure = true, ShortDescription = Resources.Chest, LongDescription = Resources.ChestLongDesc },
            new Item() { Name = "#NEST", Location = "room_71", Packable = true, Treasure = true, ShortDescription = Resources.Nest, LongDescription = Resources.NestLongDesc },
            new Item() { Name = "#LAMP_dead", Location = "", Packable = true, Treasure = false, ShortDescription = Resources.BrassLantern, LongDescription = Resources.ShinyBrassLamp }
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
