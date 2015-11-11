using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class Items : IItems
    {
        private IPlayer _player;

        public Items(IPlayer player)
        {
            _player = player;
            CreateItems();
        }

        private void CreateItems()
        {
            _itemData = new Item[]
            {
                new Item(_player) { Name = "#bridge_15", Location = "", Packable = false, Treasure = false, LongDescription = Resources.BridgeAppears},
                new Item(_player) { Name = "#bridge_18", Location = "", Packable = false, Treasure = false, LongDescription = Resources.BridgeAppears},
                new Item(_player) { Name = "#-3-", Location = "", Packable = false, Treasure = false },
                new Item(_player) { Name = "#-4-", Location = "", Packable = false, Treasure = false },
                new Item(_player) { Name = "#-5-", Location = "", Packable = false, Treasure = false },
                new Item(_player) { Name = "#MACHINE", Location = "room_51", Packable = false, Treasure = false, LongDescription = Resources.VendingMachine },
                new Item(_player) { Name = "#PLANT_A", Location = "room_81", Packable = false, Treasure = false, LongDescription = Resources.PlantMurmuring },
                new Item(_player) { Name = "#PLANT_B", Location = "", Packable = false, Treasure = false, LongDescription = Resources.PlantBellowing },
                new Item(_player) { Name = "#PLANT_C", Location = "", Packable = false, Treasure =  false, LongDescription = Resources.GiganticBeanStalk },
                new Item(_player) { Name = "#-10-", Location = "", Packable = false, Treasure = false },
                new Item(_player) { Name = "#SERPENT", Location = "room_16", Packable = false, Treasure = false, LongDescription = Resources.BarredBySerpent },
                new Item(_player) { Name = "#-12-", Location = "", Packable = false, Treasure = false },
                new Item(_player) { Name = "#-13-", Location = "", Packable = false, Treasure = false },
                new Item(_player) { Name = "#LAMP_off", Location = "room_2", Packable = true, Treasure = false, ShortDescription = Resources.BrassLantern, LongDescription = Resources.ShinyBrassLamp },
                new Item(_player) { Name = "#LAMP_on", Location = "", Packable = true, Treasure = false, ShortDescription = Resources.BrassLantern, LongDescription = Resources.LampShining, Time = 310 },
                new Item(_player) { Name = "#BOX", Location = "room_8", Packable = true, Treasure = false, ShortDescription = Resources.StatueBox, LongDescription = Resources.DiscardedStatueBox },
                new Item(_player) { Name = "#SCEPTER", Location = "room_9", Packable = true, Treasure = false, ShortDescription = Resources.Scepter, LongDescription = Resources.ThreeFootScepter },
                new Item(_player) { Name = "#PILLOW", Location = "room_72", Packable = true, Treasure = false, ShortDescription = Resources.Pillow, LongDescription = Resources.SmallVelvetPillow },
                new Item(_player) { Name = "#BIRD", Location = "room_11", Packable = true, Treasure = false, ShortDescription = Resources.StatueInBox, LongDescription = Resources.StatueOfBirdGod },
                new Item(_player) { Name = "#BIRD_boxed", Location = "", Packable = false, Treasure = false, ShortDescription = Resources.BirdBoxed, LongDescription = Resources.BirdBoxedLongDesc },
                new Item(_player) { Name = "#POTTERY", Location = "", Packable = false, Treasure = false, LongDescription = Resources.FloorLitteredWithShards },
                new Item(_player) { Name = "#PEARL", Location = "", Packable = true, Treasure = true, ShortDescription = Resources.GlisteningPearl, LongDescription = Resources.GlisteningPearlLongDesc },
                new Item(_player) { Name = "#SARCOPH_full", Location = "room_61", Packable = true, Treasure = false, ShortDescription = Resources.Sarcophagus, LongDescription = Resources.SarcophagusLongDesc },
                new Item(_player) { Name = "#SARCOPH_empty", Location = "", Packable = true, Treasure = false, ShortDescription = Resources.Sarcophagus, LongDescription = Resources.SarcophagusLongDesc },
                new Item(_player) { Name = "#MAGAZINES", Location = "room_59", Packable = true, Treasure = false, ShortDescription = Resources.Magazine, LongDescription = Resources.MagazineLongDesc },
                new Item(_player) { Name = "#FOOD", Location = "room_2", Packable = true, Treasure = false, ShortDescription = Resources.Food, LongDescription = Resources.FoodLongDesc },
                new Item(_player) { Name = "#BOTTLE", Location = "room_2", Packable = true, Treasure = false, ShortDescription = Resources.Bottle, LongDescription = Resources.BottleLongDesc },
                new Item(_player) { Name = "#WATER", Location = "#BOTTLE", Packable = true, Treasure = false, ShortDescription = Resources.Water, LongDescription = Resources.WaterLongDesc },
                new Item(_player) { Name = "#-29-", Location = "", Packable = false, Treasure = false },
                new Item(_player) { Name = "#stream_56", Location = "room_56", Packable = false, Treasure = false },
                new Item(_player) { Name = "#EMERALD", Location = "room_76", Packable = true, Treasure = true, ShortDescription = Resources.Emerald, LongDescription = Resources.EmeraldLongDesc },
                new Item(_player) { Name = "#VASE_pillow", Location = "", Packable = true, Treasure = true, ShortDescription = Resources.Vase, LongDescription = Resources.VasePillowLongDesc },
                new Item(_player) { Name = "#VASE_solo", Location = "room_73", Packable = true, Treasure = true, ShortDescription = Resources.Vase, LongDescription = Resources.VaseSoloLongDesc },
                new Item(_player) { Name = "#KEY", Location = "room_68", Packable = true, Treasure = true, ShortDescription = Resources.Key, LongDescription = Resources.KeyLongDesc },
                new Item(_player) { Name = "#BATTERIES_fresh", Location = "", Packable = true, Treasure = false, ShortDescription = Resources.Batteries, LongDescription = Resources.BatteriesFreshLongDesc },
                new Item(_player) { Name = "#BATTERIES_worn", Location = "", Packable = true, Treasure = false, ShortDescription = Resources.Batteries, LongDescription = Resources.BatteriesWornLongDesc },
                new Item(_player) { Name = "#GOLD", Location = "room_14", Packable = true, Treasure = true, ShortDescription = Resources.Gold, LongDescription = Resources.GoldLongDesc },
                new Item(_player) { Name = "#DIAMONDS", Location = "room_17", Packable = true, Treasure = true, ShortDescription = Resources.Diamonds, LongDescription = Resources.DiamondsLongDesc },
                new Item(_player) { Name = "#SILVER", Location = "room_25", Packable = true, Treasure = true, ShortDescription = Resources.Silver, LongDescription = Resources.SilverLongDesc },
                new Item(_player) { Name = "#JEWELRY", Location = "room_18", Packable = true, Treasure = true, ShortDescription = Resources.Jewelry, LongDescription = Resources.JewelryLongDesc },
                new Item(_player) { Name = "#COINS", Location = "room_24", Packable = true, Treasure = true, ShortDescription = Resources.Coins, LongDescription = Resources.CoinsLongDesc },
                new Item(_player) { Name = "#CHEST", Location = "", Packable = true, Treasure = true, ShortDescription = Resources.Chest, LongDescription = Resources.ChestLongDesc },
                new Item(_player) { Name = "#NEST", Location = "room_71", Packable = true, Treasure = true, ShortDescription = Resources.Nest, LongDescription = Resources.NestLongDesc },
                new Item(_player) { Name = "#LAMP_dead", Location = "", Packable = true, Treasure = false, ShortDescription = Resources.BrassLantern, LongDescription = Resources.ShinyBrassLamp },
            };
        }

        private Item[] _itemData;

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
