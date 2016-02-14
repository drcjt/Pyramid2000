using System.Collections.Generic;

using Pyramid2000.Engine.Interfaces;

namespace Pyramid2000.Engine
{
    public class GameState : IGameState
    {
        public string LastRoom { get; set; }
        public int TurnCount { get; set; }
        public bool GameOver { get; set; }
        public int BatteryLife { get; set; }

        public IList<IAchievement> GetAchievements() { return _awardedAchievements;  }

        private IList<IAchievement> _awardedAchievements = new List<IAchievement>();

        public void AwardAchievement(IAchievement achievement)
        {
            if (!_awardedAchievements.Contains(achievement))
            {
                _awardedAchievements.Add(achievement);
                if (AchievementAwarded != null)
                {
                    AchievementAwarded(achievement);
                }
            }
        }

        public event AwardAchievementHandler AchievementAwarded;        
    }
}
