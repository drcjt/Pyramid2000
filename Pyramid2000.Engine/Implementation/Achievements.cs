using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine.Implementation
{
    public class Achievements
    {
        public static IAchievement EnterThePyramid = new Achievement("Enter the pyramid", "Try not to get lost in the desert");
        public static IAchievement GetTheScepterAndBirdBox = new Achievement("Get the bird box and scepter", "Note that you have to pick up the bird box before getting the scepter");
        public static IAchievement DriveAwayTheSerpent = new Achievement("Drive away the serpent", "Try using the bird");
        public static IAchievement GetDiamondsGoldAndJewelery = new Achievement("Get the Diamonds, Gold and Jewelery", "The mummy will take them all but this is necessary to make the chest appear");
        public static IAchievement GetCoinsAndSilverToEntrance = new Achievement("Get Coins and Silver to Pyramid Entrance");

        private static IDictionary<string, IAchievement> _achievements = new Dictionary<string, IAchievement>();

        static Achievements()
        {
            _achievements.Add("EnterPyramid", EnterThePyramid);
            _achievements.Add("GetBird", GetTheScepterAndBirdBox);
            _achievements.Add("DefeatSerpent", DriveAwayTheSerpent);
            _achievements.Add("GetDiamondsGoldJewelery", GetDiamondsGoldAndJewelery);
            _achievements.Add("GetCoinsAndSilver", GetCoinsAndSilverToEntrance);
        }

        public static IAchievement GetAchievement(string AchievementId)
        {
            return _achievements[AchievementId];
        }

        public static IList<IAchievement> GetAllAchievements()
        {
            var achievements = new List<IAchievement>();
            achievements.Add(EnterThePyramid);
            achievements.Add(GetTheScepterAndBirdBox);
            achievements.Add(DriveAwayTheSerpent);
            achievements.Add(GetDiamondsGoldAndJewelery);
            achievements.Add(GetCoinsAndSilverToEntrance);

            return achievements;
        }
    }
}
