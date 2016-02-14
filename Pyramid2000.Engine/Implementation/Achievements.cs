using System.Collections.Generic;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine.Implementation
{
    public class Achievements
    {
        public static IAchievement EnterThePyramid = new Achievement("Enter the pyramid", "Try not to get lost in the desert");
        public static IAchievement GetTheScepterAndBirdBox = new Achievement("Get the bird", "Try using the box to keep it in, but maybe the bird doesn't like something else...");
        public static IAchievement DriveAwayTheSerpent = new Achievement("Drive away the serpent", "Serpent's don't like animals with feathers");
        public static IAchievement TreasureStolen = new Achievement("Treasure Stolen", "Having treasure stolen isn't always bad, try looking in the maze");
        public static IAchievement FindTreasure = new Achievement("Find some treasure", "Once found return it to the pyramid entrance");
        public static IAchievement UsePanel = new Achievement("Use the panel", "Panel's aren't in the pyramid to look nice - try and do something with it!");
        public static IAchievement MakeBridgeAppear = new Achievement("Bottomless pit", "Maybe waving something will help you to get across");


        private static IDictionary<string, IAchievement> _achievements = new Dictionary<string, IAchievement>();

        static Achievements()
        {
            _achievements.Add("EnterPyramid", EnterThePyramid);
            _achievements.Add("GetBird", GetTheScepterAndBirdBox);
            _achievements.Add("DefeatSerpent", DriveAwayTheSerpent);
            _achievements.Add("TreasureStolen", TreasureStolen);
            _achievements.Add("FindTreasure", FindTreasure);
            _achievements.Add("UsePanel", UsePanel);
            _achievements.Add("MakeBridgeAppear", MakeBridgeAppear);
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
            achievements.Add(TreasureStolen);
            achievements.Add(FindTreasure);
            achievements.Add(UsePanel);
            achievements.Add(MakeBridgeAppear);

            return achievements;
        }
    }
}
